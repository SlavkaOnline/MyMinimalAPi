using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.Calc;

public class GetSum : IRegisterEndpoint<CalcGroup>
{
    public static RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost("/sum", Sum)
            .WithOpenApi()
            .WithSummary("Получить сумму");
    }
    
    public static Results<NotFound, Ok<CalsResult>> Sum([FromBody] Arguments args)
    {
        return TypedResults.Ok(new CalsResult(args.A + args.B));
    }
}