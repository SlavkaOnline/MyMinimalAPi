using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.Chat;

public class GetEcho : IRegisterEndpoint<ChatGroup>
{
    public static RouteHandlerBuilder RegisterEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapGet("/echo", Echo)
            .WithOpenApi()
            .WithSummary("Вернуть тоже самое");
    }
    
    public static Results<NotFound, Ok<object>> Echo([FromQuery] string str)
    {
        return TypedResults.Ok<object>(new {Str = str});
    }
}