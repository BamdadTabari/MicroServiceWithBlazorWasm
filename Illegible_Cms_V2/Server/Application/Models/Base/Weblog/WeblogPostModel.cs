namespace Illegible_Cms_V2.Server.Application.Models.Base.Weblog;

public class WeblogPostModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }

    public WeblogPostCategoryModel WeblogPostCategoryModel { get; set; }
}