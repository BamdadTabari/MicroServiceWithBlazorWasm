namespace Illegible_Cms_V2.Identity.Application.Models.Base.Permissions
{
    public class PermissionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreatedAt { get; set; }
    }   
}
