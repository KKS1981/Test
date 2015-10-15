using Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositry
{
    public class SqlRepository<T> : IRepository<T> where T : class,IEntity
    {

        protected readonly IDbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public SqlRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }


        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Fetch(params Expression<Func<T, object>>[] includes)
        {
            return _dbSet.IncludeMultiple(includes).AsQueryable();
        }


        public IQueryable<TZ> Fetch<TZ>(params Expression<Func<TZ, object>>[] includes) where TZ : class, T
        {
            return _dbSet.OfType<TZ>().IncludeMultiple(includes);
        }

        public List<T> Find(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {

            var result = _dbSet.IncludeMultiple(includes).Where(predicate).ToList();
            return result;
        }

        public List<TZ> Find<TZ>(Func<TZ, bool> predicate, params Expression<Func<TZ, object>>[] includes) where TZ : class ,T
        {

            return _dbSet.OfType<TZ>().IncludeMultiple(includes).Where(predicate).ToList();
        }


        public T FindById(int id, params Expression<Func<T, object>>[] includes)
        {
            return _dbSet.IncludeMultiple(includes).SingleOrDefault(x => x.Id == id);
        }

        public TZ FindById<TZ>(int id, params Expression<Func<TZ, object>>[] includes) where TZ : class,T
        {
            return _dbSet.OfType<TZ>().IncludeMultiple(includes).SingleOrDefault(x => x.Id == id);
        }

        public T Single(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public TZ Single<TZ>(Func<TZ, bool> predicate, params Expression<Func<TZ, object>>[] includes) where TZ : class,T
        {
            return _dbSet.OfType<TZ>().IncludeMultiple(includes).SingleOrDefault(predicate);
        }

        public IEnumerable<TZ> ExecuteProc<TZ>(string procName, IDictionary<string, object> parameters) where TZ : class , T
        {
            //            var builder = parameters.Select(x => string.Format("@{0}='{1}'", x.Key, FormatParameter(x.Value))).ArrayToCsv();
            //            var command = string.Format("EXEC {0} {1}", procName, builder.ToString());
            //
            //            var connection = _dbContext.Database.Connection;
            //
            //            if (connection.State == ConnectionState.Closed)
            //                connection.Open();
            //
            //            return connection.Query<TZ>(command);

            throw new NotImplementedException();
        }

        public IEnumerator<T> ExecuteCommand(string procName, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> FindByIds(IEnumerable<int> ids, params Expression<Func<T, object>>[]
                                                    includes)
        {
            return _dbSet.IncludeMultiple(includes).Where(x => ids.Contains(x.Id));
        }

        private static string FormatParameter(object data)
        {
            if (data == null)
            {
                return null;
            }

            if (data is Boolean)
            {
                return ((bool)data ? 1 : 0).ToString(CultureInfo.InvariantCulture);
            }

            if (data is DateTime)
            {
                return ((DateTime)data).ToString("dd MMM yyyy");
            }

            return data.ToString();
        }

        public void Update(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
        }
    }
}
