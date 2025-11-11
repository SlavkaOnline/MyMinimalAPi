namespace MyMinimalAPI.Infra;

public interface IRegisterGroup
{
    public static abstract RouteGroupBuilder GetBuilder(IEndpointRouteBuilder builder);
}