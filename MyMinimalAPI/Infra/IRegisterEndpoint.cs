namespace MyMinimalAPI.Infra;

public interface IRegisterEndpoint<TGroup>
where TGroup : IGroupEndpont
{
    public static abstract RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder);
}