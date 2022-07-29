namespace Illegible_Cms_V2.Server.Application.Models.Base.Weblog;

public class WeblogPostCategoryModel
{
    public int Id { get; set; }
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }

    public ICollection<WeblogPostModel> WeblogPostModels { get; set; }
}