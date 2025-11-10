namespace MyMinimalAPI.Infra;

public interface IGroupEndpont
{
    public static abstract RouteGroupBuilder GetRouteGroupBuilder(IEndpointRouteBuilder builder);
}