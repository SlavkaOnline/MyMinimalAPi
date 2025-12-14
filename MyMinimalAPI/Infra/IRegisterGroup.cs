namespace MyMinimalAPI.Infra;

/// <summary>
/// Регистратор группы
/// </summary>
public interface IRegisterGroup
{
    /// <summary>
    /// Сконфигурировать билдер группы
    /// </summary>
    /// <returns></returns>
    public static abstract RouteGroupBuilder ConfigureBuilder(IEndpointRouteBuilder builder);
}