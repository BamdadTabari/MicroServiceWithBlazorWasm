﻿using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;

namespace Illegible_Cms_V2.Identity.Application.Models.Base.Users
{
    public class UserRoleModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public int CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }

        public UserModel User { get; set; }
        public RoleModel Role { get; set; }
        public UserModel Creator { get; set; }
    }
}