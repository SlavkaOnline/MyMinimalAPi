using System.Reflection;

namespace MyMinimalAPI.Infra;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterEndpointsFromAssembly(this IEndpointRouteBuilder builder,
        Assembly assembly)
    {
        var groups = assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false }) 
            .Select(t => new
            {
                ImplementationType = t,
                Interface = t.GetInterfaces() 
                    .SingleOrDefault(i => i.IsGenericType && 
                                          i.GetGenericTypeDefinition() == typeof(IRegisterEndpoint<>))
            })
            .Where(x => x.Interface != null) 
            .GroupBy( 
                x => x.Interface!.GetGenericArguments()[0], 
                x => x.ImplementationType 
            );
        
        foreach (var group in groups)
        {
            var rgb = GetRouteGroupBuilder(builder, group.Key); 
            foreach (var type in group) 
            {
                RegisterGroupEndpoints(rgb, type);
            }
        }
    }

    private static RouteGroupBuilder GetRouteGroupBuilder(IEndpointRouteBuilder builder, Type type)
    {
        var method = type.GetMethod(
            nameof(IRegisterGroup.ConfigureBuilder),
            BindingFlags.Public | BindingFlags.Static,
            [typeof(RouteGroupBuilder)]
        );

       return (RouteGroupBuilder)method?.Invoke(null, [builder])!;
    }

    private static void RegisterGroupEndpoints(
        RouteGroupBuilder routeGroupBuilder,
        Type endpoint)
    {
        var method = endpoint.GetMethod(
            "RegisterEndpoint",
            BindingFlags.Public | BindingFlags.Static,
            [typeof(RouteGroupBuilder)]
        );

        method?.Invoke(null, [routeGroupBuilder]);
    }
}