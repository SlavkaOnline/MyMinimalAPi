using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.Chat;

public class ChatGroup : IGroupEndpoint
{
    public static RouteGroupBuilder GetRouteGroupBuilder(IEndpointRouteBuilder builder)
    {
        return builder.MapGroup("chant")
            .WithTags("Chanting");
    }
}