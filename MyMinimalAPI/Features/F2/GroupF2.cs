using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.F2;

public class GroupF2 : IGroupEndpont
{
    static RouteGroupBuilder IGroupEndpont.GetRouteGroupBuilder(IEndpointRouteBuilder builder)
    {
        return builder.MapGroup("F2")
            .WithTags("F2 group");
    }
}