namespace MyMinimalAPI.Infra;

public interface IRegisterEndpoint<TGroup>
where TGroup : IGroupEndpoint
{
    public static abstract RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder);
}