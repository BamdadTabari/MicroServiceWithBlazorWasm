﻿using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Domain.Claims;

namespace Illegible_Cms_V2.Identity.Application.Models.Base.Claims
{
    public class ClaimModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ClaimType Type { get; set; }
        public string Value { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatorId { get; set; }
        public int UpdaterId { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }

        public UserModel User { get; set; }
        public UserModel Creator { get; set; }

    }
}