using Autofac;
using Blog.IRepository;
using Blog.Repository;
using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;

namespace Blog.Service.Impl
{
    public class BaseService<T>:IBaseService<T>
        where T:EntityBase,new()
    {

        private  IDBSession session = null;

        protected IDBSession DBSession
        {
            get { return session; }
        }
        public BaseService() 
         {
            session=new RepositoryContainner().Container.Resolve<IDBSession>();
         }

        public IBaseRepository<T> baseRepository = new RepositoryContainner().GetBaseRepository<T>();
        public T AddEntity(T entity)
        {
            var model= baseRepository.AddEntity(entity);
            DBSession.SaveChanges();

            return model;
        }

        public bool UpdateEntity(T entity)
        {
          var result= baseRepository.UpdateEntity(entity);

          return DBSession.SaveChanges()>0;
        }

        public bool DeleteEntity(T entity)
        {
           var result= baseRepository.DeleteEntity(entity);

           return DBSession.SaveChanges()>0;

        }

        public IQueryable<T> LoadEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
           return baseRepository.LoadEntity(whereLambda);
        }

        public IQueryable<T> LoadPageEntity<S>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, int? pageIndex, int? pageSize, out int total, System.Linq.Expressions.Expression<Func<T, S>> orderLambda, bool isAsc)
        {
            return baseRepository.LoadPageEntity(whereLambda, pageIndex, pageSize, out total, orderLambda, isAsc);
        }


        public bool BatchDelteEntity(IList<T> entities)
        {
            if (entities==null||entities.Count<=0)
            {
                return false;
            }
            foreach (var item in entities)
            {
                baseRepository.DeleteEntity(item);
            }

            return DBSession.SaveChanges() > 0;
        }
    }
}
