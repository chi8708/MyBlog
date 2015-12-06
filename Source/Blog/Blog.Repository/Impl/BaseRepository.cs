using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Impl
{
    public class BaseRepository<T>:IBaseRepository<T>
        where T:EntityBase,new()
    {

        private IDBContextFactory dbContextFactory = new EFContextFactory();

        private DbContext db;

        public BaseRepository()
        {
            db = dbContextFactory.GetCurrentContextInstence();

        }
        protected DbContext Context
        {
            get { return db; }
        }
        public T AddEntity(T entity)
        {
            db.Set<T>().Add(entity);

            return entity;
        }

        public bool UpdateEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;

            return true;
        }

        public bool DeleteEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Deleted;

            return true;
        }

        public IQueryable<T> LoadEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> LoadPageEntity<S>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, int? pageIndex, int? pageSize, out int total, System.Linq.Expressions.Expression<Func<T, S>> orderLambda, bool isAsc)
        {
            int index = pageIndex ?? 1;
            int size = pageSize ?? 10;

            var data = db.Set<T>().Where<T>(whereLambda);

            total = data.Count();

            data = isAsc ? data.OrderBy(orderLambda) : data.OrderByDescending(orderLambda);
            data = data.Skip<T>(size * (index - 1)).Take<T>(size);

            return data;
        }
    }
}
