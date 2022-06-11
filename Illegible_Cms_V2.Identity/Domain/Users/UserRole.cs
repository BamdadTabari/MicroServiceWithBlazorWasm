﻿using Illegible_Cms_V2.Shared.BasicShared.Models;
using StackExchange.Redis;

namespace Illegible_Cms_V2.Identity.Domain.Users
{
    public class UserRole : IEntity
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        #region Management

        public int CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigations

        public User User { get; set; }
        //public Role Role { get; set; }
        public User Creator { get; set; }

        #endregion
    }
}