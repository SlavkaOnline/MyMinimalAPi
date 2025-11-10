using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.Calc;

public class GetMultiplication: IRegisterEndpoint<CalcGroup>
{
    public static RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost("/multiplication", Multiplication)
            .WithOpenApi()
            .WithSummary("Получить произведение");
    }
    
    public static Results<NotFound, Ok<CalsResult>> Multiplication([FromBody] Arguments args)
    {
        return TypedResults.Ok<CalsResult>(new CalsResult(args.A * args.B));
    }
}