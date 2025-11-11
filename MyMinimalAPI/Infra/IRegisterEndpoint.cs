namespace MyMinimalAPI.Infra;

// ReSharper disable once UnusedTypeParameter
public interface IRegisterEndpoint<TGroup>
where TGroup : IRegisterGroup
{
    public static abstract RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder);
}