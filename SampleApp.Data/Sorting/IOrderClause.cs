using System.Linq.Expressions;

namespace SampleApp.Data.Sorting
{
    public interface IOrderClause<TEntity>
    {
        Expression<Func<TEntity, object>> Expression { get; }
        bool IsAscending { get; }
    }
}
