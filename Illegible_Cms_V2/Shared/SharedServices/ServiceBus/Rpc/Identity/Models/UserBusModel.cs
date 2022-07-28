namespace Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity.Models
{
    public class UserBusModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string SecurityStamp { get; set; }
        public IEnumerable<PermissionBusModel> Permissions { get; set; }
    }
}