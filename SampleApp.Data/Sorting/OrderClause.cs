using System.Linq.Expressions;

namespace SampleApp.Data.Sorting
{
    public record OrderClause<TEntity> : IOrderClause<TEntity>
    {
        public required Expression<Func<TEntity, object>> Expression { get; init; }
        public bool IsAscending { get; init; } = true;
    }
}
