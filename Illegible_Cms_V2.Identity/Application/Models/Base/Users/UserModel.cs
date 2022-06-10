using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Application.Models.Base.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Mobile { get; set; }
        public bool IsMobileConfirmed { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }
        public bool IsLockedOut { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname { get; set; }
        public string LatinFirstName { get; set; }
        public string LatinLastName { get; set; }
        public string NationalCode { get; set; }
        public UserState State { get; set; }

        public string WorkTelephone { get; set; }
        public string WorkFax { get; set; }
        public string WorkAddress { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<RoleModel> Roles { get; set; }
    }
}
