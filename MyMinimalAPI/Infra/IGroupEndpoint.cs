namespace MyMinimalAPI.Infra;

public interface IGroupEndpoint
{
    public static abstract RouteGroupBuilder GetRouteGroupBuilder(IEndpointRouteBuilder builder);
}