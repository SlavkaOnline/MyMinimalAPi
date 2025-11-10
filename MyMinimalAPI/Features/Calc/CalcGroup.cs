using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.Calc;

public class CalcGroup : IGroupEndpoint
{
    public static RouteGroupBuilder GetRouteGroupBuilder(IEndpointRouteBuilder builder)
    {
        return builder
            .MapGroup("calc")
            .WithTags("Calculation");
    }
}