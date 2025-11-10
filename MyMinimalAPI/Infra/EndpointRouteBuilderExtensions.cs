using System.Reflection;

namespace MyMinimalAPI.Infra;

public static class EndpointRouteBuilderExtensions
{

    public static void RegisterEndpointsFromAssembly(this IEndpointRouteBuilder builder,
        Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t is {IsClass: true, IsAbstract: false} && t.GetInterfaces().Any(i => i == typeof(IRegisterEndpoint<>)));

        var groups = types.GroupBy(x => x.GetGenericArguments()[1]);

        foreach (var group in groups)
        {
            var rgb = GetRouteGroupBuilder(builder, group.Key);
            foreach (var type in group)
            {
                RegisterGroupEndpoints(builder, rgb, type);
            }
        }
    }

    private static RouteGroupBuilder GetRouteGroupBuilder(IEndpointRouteBuilder builder, Type type)
    {
        var method = type.GetMethod(
            nameof(IGroupEndpont.GetRouteGroupBuilder),
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