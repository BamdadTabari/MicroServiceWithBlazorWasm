using System.Linq.Expressions;

namespace Illegible_Cms_V2.Shared.SharedServices.Specifications;

public class OrSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        _right = right;
        _left = left;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();

        var orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);

        return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
    }
}