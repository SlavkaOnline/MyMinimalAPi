using MyMinimalAPI.Infra;

namespace MyMinimalAPI.Features.Chat;

public class ChatRegisterGroup : IRegisterGroup
{
    public static RouteGroupBuilder ConfigureBuilder(IEndpointRouteBuilder builder)
    {
        return builder.MapGroup("chant")
            .WithTags("Chanting");
    }
}