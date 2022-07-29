using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Server.Domain.Weblog;

public class WeblogPostCategory: IEntity
{
    public int Id { get; set; }
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }

    #region Management

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }

    #endregion

    public ICollection<WeblogPost> WeblogPosts { get; set; }
}