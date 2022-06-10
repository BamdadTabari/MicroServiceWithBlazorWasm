using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;

namespace Illegible_Cms_V2.Identity.Application.Models.Base.Roles
{
    public class RoleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Name { get; set; }
        public List<PermissionModel> Permissions { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int CreatorId { get; set; }
        public int UpdaterId { get; set; }

        public string CreatorName { get; set; }
        public string UpdaterName { get; set; }
    }
}
