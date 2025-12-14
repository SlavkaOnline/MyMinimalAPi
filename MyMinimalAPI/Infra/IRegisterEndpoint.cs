namespace MyMinimalAPI.Infra;

/// <summary>
/// Регистратор конечной точки в рамках группы <see cref="TGroup"/>
/// </summary>
/// <typeparam name="TGroup">Группа конечных точек</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IRegisterEndpoint<TGroup>
where TGroup : IRegisterGroup
{
    /// <summary>
    /// Зарегистрировать конечную точку
    /// </summary>
    /// <returns></returns>
    public static abstract RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder);
}