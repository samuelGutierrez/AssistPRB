using Back_Assist.Data.Data;
using Back_Assist.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Back_Assist.Data.Utility;

namespace Back_Assist.Data.Repositories.Base
{
    public class DaoGeneric<TEntity> : IGeneric<TEntity> where TEntity : class
    {
        protected const string sMensAccion = "Ocurrio un error al {0} la entidad ('{1}') en la capa de Dao.";
        private Context _entities = null;

        public DaoGeneric(Context oContext) { _entities = oContext; }

        public DbContext Context
        {
            get
            {
                if (_entities == null)
                { _entities = new Context(); }

                return _entities;
            }
        }

        public List<TEntity> List(ParametersOfList<TEntity> Parameters = null)
        {
            try
            {
                return Parameters == null ? Context.Set<TEntity>().ToList() :
                 (Parameters.filter != null && Parameters.OrderBy != null) ? (Parameters.OrderBy(Context.Set<TEntity>().Where(Parameters.filter))).ToList() :
                        (Parameters.filter != null && Parameters.OrderBy == null) ? Context.Set<TEntity>().Where(Parameters.filter).ToList() : Context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TEntity>> ListAsync(ParametersOfList<TEntity> Parameters = null)
        {
            try
            {
                var parameter = Parameters == null ? await Context.Set<TEntity>().ToListAsync() :
                    (Parameters.filter != null && Parameters.OrderBy != null) ? await (Parameters.OrderBy(Context.Set<TEntity>().Where(Parameters.filter))).ToListAsync() :
                           (Parameters.filter != null && Parameters.OrderBy == null) ? await Context.Set<TEntity>().Where(Parameters.filter).ToListAsync() :
                           (Parameters.filter != null && Parameters.Include != null) ? await Context.Set<TEntity>().Include(Parameters.Include).Where(Parameters.filter).ToListAsync() :
                           await Context.Set<TEntity>().ToListAsync();

                return parameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity Search(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> SearchAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> CreateAsync(TEntity oEntity)
        {
            try
            {
                Context.Set<TEntity>().Add(oEntity);
                int x = await Context.SaveChangesAsync();
                return ((x > 0) ? oEntity : null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity Create(TEntity oEntity)
        {
            try
            {
                Context.Set<TEntity>().Add(oEntity);
                int x = Context.SaveChanges();
                return ((x > 0) ? oEntity : null);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> ModifyAsync(TEntity oEntity)
        {
            try
            {
                Context.Entry(oEntity).State = EntityState.Modified;
                int x = await Context.SaveChangesAsync();
                return (x > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modify(TEntity oEntity)
        {
            try
            {
                Context.Entry(oEntity).State = EntityState.Modified;
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                if (query != null)
                {
                    Context.Set<TEntity>().RemoveRange(query);
                    int x = await Context.SaveChangesAsync();
                    return (x > 0);
                }
                else
                    return true;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> RemoveAllAsync()
        {
            try
            {
                Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>());
                int x = await Context.SaveChangesAsync();
                return (x > 0);
            }
            catch (Exception ex) { throw ex; }
        }

        public bool RemoveAll()
        {
            try
            {
                Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>());
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().RemoveRange(query.ToList());
                int x = await Context.SaveChangesAsync();
                return (x > 0);
            }
            catch (Exception ex) { throw ex; }
        }

        public bool RemoveRange(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().RemoveRange(query.ToList());
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw ex; }
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                // IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().AddRange(entities);
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Remove(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().Remove(query.FirstOrDefault());
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> RemoveAsync(TEntity oObj)
        {
            if (oObj != null)
            {
                try
                {
                    Context.Set<TEntity>().Remove(oObj);
                    int x = await Context.SaveChangesAsync();
                    return (x > 0);
                }
                catch (Exception ex) { throw ex; }
            }
            else
                throw null;
        }

        public bool Remove(TEntity oObj)
        {
            if (oObj != null)
            {
                try
                {
                    Context.Set<TEntity>().Remove(oObj);
                    int x = Context.SaveChanges();
                    return (x > 0);
                }
                catch (Exception ex) { throw ex; }
            }
            else
                throw null;
        }

        public int ExecuteNoResultSP(string nameProcedure, object[] sqlparameters)
        {
            int result = 0;
            try
            {
                Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                result = Context.Database.ExecuteSqlRaw(nameProcedure, sqlparameters);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }

        private IQueryable<TEntity> ConfigParameters(IQueryable<TEntity> IQuery, ParametersOfList<TEntity> Parameters)
        {
            if (Parameters != null)
            {
                if (Parameters.Skip > -1)
                    IQuery = IQuery.Skip(Parameters.Skip);

                if (Parameters.Take > -1)
                    IQuery = IQuery.Take(Parameters.Take);

                if (Parameters.filter != null)
                    IQuery = IQuery.Where(Parameters.filter);

                if (Parameters.OrderBy != null)
                    IQuery = Parameters.OrderBy(IQuery);

                if (Parameters.Include != null)
                    IQuery = IQuery.Include(Parameters.Include);
            }

            return IQuery;
        }

        public void Dispose()
        {
            _entities.Dispose();
            _entities = null;
        }
    }
}
