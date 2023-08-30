using Back_Assist.Data.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Back_Assist.Data.Interfaces
{
    public interface IGeneric<TEntity> : IDisposable
    {
        DbContext Context { get; }

        Task<List<TEntity>> ListAsync(ParametersOfList<TEntity> Parameters = null);
        List<TEntity> List(ParametersOfList<TEntity> Parameters = null);
        Task<TEntity> SearchAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Search(Expression<Func<TEntity, bool>> predicate);
        TEntity Create(TEntity oEntity);
        Task<TEntity> CreateAsync(TEntity oEntity);
        bool Modify(TEntity oEntity);
        Task<bool> ModifyAsync(TEntity oEntity);
        bool Remove(Expression<Func<TEntity, bool>> predicate);
        bool RemoveRange(Expression<Func<TEntity, bool>> predicate);
        bool AddRange(IEnumerable<TEntity> entities);
        Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> RemoveAllAsync();
        bool RemoveAll();
        bool Remove(TEntity oObj);
        Task<bool> RemoveAsync(TEntity oObj);
    }
}
