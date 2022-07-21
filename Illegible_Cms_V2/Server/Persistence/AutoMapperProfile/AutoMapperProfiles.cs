using AutoMapper;
using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Server.Domain.Weblog;

namespace Illegible_Cms_V2.Server.Persistence.AutoMapperProfile
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<WeblogPost, WeblogPostModel>().ReverseMap();

            CreateMap<WeblogPostCategory, WeblogPostCategoryModel>().ReverseMap();
        }
    }
}
