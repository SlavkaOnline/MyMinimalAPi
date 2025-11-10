using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.F2;

public class GetMultiplication: IRegisterEndpoint<GroupF2>
{
    public static RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost("/multiplication", Multiplication)
            .WithOpenApi()
            .WithSummary("Получить сумму");
    }
    
    public static Results<NotFound, Ok<SumResult>> Multiplication([FromBody] Arguments args)
    {
        return TypedResults.Ok<SumResult>(new SumResult(args.A * args.B));
    }
}