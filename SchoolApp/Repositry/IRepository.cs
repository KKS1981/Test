using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositry
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Add(T entity);
        void Remove(T entity);
        IQueryable<T> Fetch(params Expression<Func<T, object>>[] includes);
        IQueryable<TZ> Fetch<TZ>(params Expression<Func<TZ, object>>[] includes)
            where TZ : class ,T;

        void Update(T t);

        List<T> Find(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);

        List<TZ> Find<TZ>(Func<TZ, bool> predicate,
            params Expression<Func<TZ, object>>[] includes) where TZ : class, T;

        T FindById(int id, params Expression<Func<T, object>>[] includes);

        TZ FindById<TZ>(int id, params Expression<Func<TZ, object>>[] includes)
            where TZ : class ,T;

        T Single(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);
        void SaveChanges();

        TZ Single<TZ>(Func<TZ, bool> predicate, params Expression<Func<TZ, object>>[] includes)
            where TZ : class ,T;

        IEnumerable<TZ> ExecuteProc<TZ>(string procName, IDictionary<string, object> parameters) where TZ : class ,T;
        IEnumerator<T> ExecuteCommand(string procName, IDictionary<string, object> parameters);
        IEnumerable<T> FindByIds(IEnumerable<int> ids, params Expression<Func<T, object>>[]
                                                    includes);
    }
}
