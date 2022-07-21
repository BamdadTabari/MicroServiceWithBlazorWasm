using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Shared.SharedServices.Specifications;
using System.Linq.Expressions;

namespace Illegible_Cms_V2.Server.Application.Specifications.Weblog
{
    public class DuplicateWeblogPostCategorySpecificstion : Specification<WeblogPostCategory>
    {
        private readonly string _title;

        public DuplicateWeblogPostCategorySpecificstion(string title)
        {
            _title = title;
        }

        public override Expression<Func<WeblogPostCategory, bool>> ToExpression()
        {
            return user => user.CategoryTitle.ToLower() == _title.ToLower();
        }
    }
}
