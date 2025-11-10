using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.F2;

public class GetSum : IRegisterEndpoint<GroupF2>
{
    
    public static RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost("/sum", Sum)
            .WithOpenApi()
            .WithSummary("Получить сумму");
    }
    
    public static Results<NotFound, Ok<SumResult>> Sum([FromBody] Arguments args)
    {
        return TypedResults.Ok(new SumResult(args.A + args.B));
    }
}