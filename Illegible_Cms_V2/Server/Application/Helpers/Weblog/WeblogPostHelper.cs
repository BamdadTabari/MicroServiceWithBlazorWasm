using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;
using Illegible_Cms_V2.Server.Domain.Weblog;

namespace Illegible_Cms_V2.Server.Application.Helpers.Weblog
{
    public static class WeblogPostHelper
    {
        private static WeblogPost AddWeblogPost(CreateWeblogPostCommand command) => new WeblogPost()
        {
            Title = command.Title,
            Summery = command.Summery,
            TextContent = command.TextContent
        };
    }
}
