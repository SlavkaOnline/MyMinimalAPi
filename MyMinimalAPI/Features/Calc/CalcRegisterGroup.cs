using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.Calc;

public class CalcRegisterGroup : IRegisterGroup
{
    public static RouteGroupBuilder GetBuilder(IEndpointRouteBuilder builder)
    {
        return builder
            .MapGroup("calc")
            .WithTags("Calculation");
    }
}