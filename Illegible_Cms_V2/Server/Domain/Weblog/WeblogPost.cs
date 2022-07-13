using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Server.Domain.Weblog
{
    public class WeblogPost : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summery { get; set; }
        public string TextContent { get; set; }
    }
}
