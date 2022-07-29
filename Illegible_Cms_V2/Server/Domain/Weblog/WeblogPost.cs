using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Server.Domain.Weblog;

public class WeblogPost : IEntity
{
    public int Id { get; set; }
    public int WeblogPostCategoryId { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }

    #region Management

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }
    #endregion

    #region Navigations

    public WeblogPostCategory WeblogPostCategory { get; set; }

    #endregion
}