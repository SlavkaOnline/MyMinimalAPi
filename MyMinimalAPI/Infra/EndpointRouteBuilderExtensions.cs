using System.Reflection;

namespace MyMinimalAPI.Infra;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterEndpointsFromAssembly(this IEndpointRouteBuilder builder,
        Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t is {IsClass: true, IsAbstract: false} && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRegisterEndpoint<>)));
        
        var groups = types.GroupBy(GetGenericType);

        foreach (var group in groups)
        {
            var rgb = GetRouteGroupBuilder(builder, group.Key);
            foreach (var type in group)
            {
                RegisterGroupEndpoints(builder, rgb, type);
            }
        }

        static Type GetGenericType(Type type)
        {
            var i =  type.GetInterfaces().Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRegisterEndpoint<>));
            return i.GetGenericArguments()[0];
        }
    }

    private static RouteGroupBuilder GetRouteGroupBuilder(IEndpointRouteBuilder builder, Type type)
    {
        var method = type.GetMethod(
            nameof(IGroupEndpoint.GetRouteGroupBuilder),
            BindingFlags.Public | BindingFlags.Static,
            new[] {typeof(RouteGroupBuilder)}
        );

       return  (RouteGroupBuilder)method?.Invoke(null, new object[] {builder});
    }
    
    public static void RegisterGroupEndpoints(
        IEndpointRouteBuilder builder,
        RouteGroupBuilder routeGroupBuilder,
        Type endpoint)
    {
        var method = endpoint.GetMethod(
            "RegisterEndpoint",
            BindingFlags.Public | BindingFlags.Static,
            new[] {typeof(RouteGroupBuilder)}
        );

        method?.Invoke(null, new object[] {routeGroupBuilder});
    }
}