using System.Linq.Expressions;
using Illegible_Cms_V2.Identity.Domain.Roles;
using Illegible_Cms_V2.Shared.SharedServices.Specifications;

namespace Illegible_Cms_V2.Identity.Application.Specifications.Roles
{
    public class DuplicateRoleSpecification : Specification<Role>
    {
        private readonly string _title;

        public DuplicateRoleSpecification(string title)
        {
            _title = title;
        }

        public override Expression<Func<Role, bool>> ToExpression()
        {
            return role => role.Title.ToLower() == _title.ToLower();
        }
    }
}
