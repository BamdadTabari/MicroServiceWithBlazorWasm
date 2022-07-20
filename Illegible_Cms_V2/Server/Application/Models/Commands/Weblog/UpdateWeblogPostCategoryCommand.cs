using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Server.Application.Models.Commands.Weblog
{
    public class UpdateWeblogPostCategoryCommand
    {
        public UpdateWeblogPostCategoryCommand(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryIcon { get; set; }

        public RequestInfo RequestInfo { get; set; }
    }
}
