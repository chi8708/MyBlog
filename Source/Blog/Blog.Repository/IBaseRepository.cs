using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public interface IBaseRepository<T> where T : EntityBase,new()
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 查询实体列表
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        IQueryable<T> LoadEntity(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <typeparam name="S">排序类型</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="pageIndex">页大小</param>
        /// <param name="pageSize">所有</param>
        /// <param name="total">记录总条数</param>
        /// <param name="orderLambda">排序Lambda</param>
        /// <param name="isAsc">是否自增</param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntity<S>(Expression<Func<T, bool>> whereLambda, int? pageIndex, int? pageSize, out int total, Expression<Func<T, S>> orderLambda, bool isAsc);
    }
}
