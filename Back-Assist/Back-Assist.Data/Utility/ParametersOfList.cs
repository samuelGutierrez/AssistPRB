using System.Linq.Expressions;

namespace Back_Assist.Data.Utility
{
    public class ParametersOfList<TEntity>
    {
        public int Skip { get; }
        public int Take { get; }
        public Expression<Func<TEntity, bool>> filter { get; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; }
        public Expression<Func<TEntity, object>> Include { get; }

        public ParametersOfList(int Skip, int Take, Expression<Func<TEntity, bool>> filter,
                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy,
                        Expression<Func<TEntity, object>> Include)
        {
            this.filter = filter;
            this.Skip = Skip;
            this.Take = Take;
            this.OrderBy = OrderBy;
            this.Include = Include;
        }

        public ParametersOfList(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null,
                               Expression<Func<TEntity, object>> Include = null)
        {
            this.filter = filter;
            Skip = -1;
            Take = -1;
            this.OrderBy = OrderBy;
            this.Include = Include;
        }
        public ParametersOfList(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null)
        {
            this.filter = filter;
            Skip = -1;
            Take = -1;
            this.OrderBy = OrderBy;
            Include = null;
        }

        public ParametersOfList(Expression<Func<TEntity, bool>> filter,
                                Expression<Func<TEntity, object>> Include)
        {
            this.filter = filter;
            Skip = -1;
            Take = -1;
            this.OrderBy = null;
            this.Include = Include;
        }
        public ParametersOfList(Expression<Func<TEntity, bool>> filter)
        {
            this.filter = filter;
            Skip = -1;
            Take = -1;
            this.OrderBy = null;
            Include = null;
        }

        public ParametersOfList(int Skip, int Take, Expression<Func<TEntity, bool>> filter = null)
        {
            this.Skip = Skip;
            this.Take = Take;
            this.filter = filter;
            OrderBy = null;
            Include = null;
        }

        public ParametersOfList(int Skip, int Take, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy)
        {
            filter = null;
            this.Skip = Skip;
            this.Take = Take;
            this.OrderBy = OrderBy;
            Include = null;
        }

        public ParametersOfList(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy)
        {
            filter = null;
            this.Skip = -1;
            this.Take = -1;
            this.OrderBy = OrderBy;
            Include = null;
        }
    }
}
