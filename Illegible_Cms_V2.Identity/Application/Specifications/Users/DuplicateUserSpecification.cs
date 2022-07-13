using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.SharedServices.Specifications;
using System.Linq.Expressions;

namespace Illegible_Cms_V2.Identity.Application.Specifications.Users
{
    public class DuplicateUserSpecification : Specification<User>
    {
        private readonly string _username;

        public DuplicateUserSpecification(string username)
        {
            _username = username;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Username.ToLower() == _username.ToLower();
        }
    }
}
