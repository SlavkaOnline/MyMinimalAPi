using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.F1;

public class GroupF1 : IGroupEndpont
{
    static RouteGroupBuilder IGroupEndpont.GetRouteGroupBuilder(IEndpointRouteBuilder builder)
    {
        return builder.MapGroup("F1")
            .WithTags("F1 group");
    }
}