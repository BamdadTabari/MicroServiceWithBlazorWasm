using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Shared.SharedServices.Specifications;
using System.Linq.Expressions;

namespace Illegible_Cms_V2.Server.Application.Specifications.Weblog
{
    public class DuplicateWeblogPostSpecification: Specification<WeblogPost>
    {
        private readonly string _title;

        public DuplicateWeblogPostSpecification(string title)
        {
            _title = title;
        }

        public override Expression<Func<WeblogPost, bool>> ToExpression()
        {
            return user => user.Title.ToLower() == _title.ToLower();
        }
    }
}
