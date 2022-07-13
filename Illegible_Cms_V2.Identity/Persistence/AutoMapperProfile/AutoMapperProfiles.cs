using AutoMapper;
using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Domain.Permissions;
using Illegible_Cms_V2.Identity.Domain.Roles;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Persistence.AutoMapperProfile
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PermissionModel, Permission>().ReverseMap();

            CreateMap<RoleModel, Role>().ReverseMap();

            CreateMap<UserModel, User>().ReverseMap();

            CreateMap<UserRoleModel, UserRole>().ReverseMap();
        }
    }
}
