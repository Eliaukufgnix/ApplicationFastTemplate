using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        bool Add(T Entity);

        /// <summary>
        /// 批量的进行添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        bool AddRange(List<T> Entity);

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        bool Remove(T Entity);

        /// <summary>
        /// 批量删除多个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        bool RemoveRange(List<T> Entity);

        /// <summary>
        /// 根据查询条件进行删除单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        bool RemoveByWhere(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        ///单个对象的修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity">需要修改的对象</param>
        /// <returns></returns>
        bool Update(T Entity);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="updateLambda"></param>
        /// <returns></returns>
        bool Update(Expression<Func<T, bool>> WhereLambda, Expression<Func<T, T>> UpdateLambda);

        /// <summary>
        /// 批量的修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        bool Update(List<T> Entity);

        /// <summary>
        /// 批量统一的进行更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">需要修改的对象实体</param>
        /// <param name="WhereLambda">查询的条件</param>
        /// <param name="ModifiedProNames"></param>
        /// <returns></returns>
        bool Update(T model, Expression<Func<T, bool>> WhereLambda, params string[] ModifiedProNames);

        /// <summary>
        /// 根据主键进行查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        T FindByID(dynamic ID);

        /// <summary>
        /// 默认查询选择第一条数据,没有那么进行返回NULL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="WhereLambda"></param>
        /// <returns>返回bool</returns>
        T GetFristDefault(Expression<Func<T, bool>> WhereLambda = null);

        /// <summary>
        /// 查询所有的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> GetAll(Expression<Func<T, string>> OrderLambda = null);

        /// <summary>
        /// 含有带条件的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        List<T> GetAllByWhere(Expression<Func<T, bool>> WhereLambda = null, Expression<Func<T, string>> OrderLambda = null);

        /// <summary>
        ///获取查询的数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        int GetCountByWhere(Expression<Func<T, bool>> WhereLambda = null);

        /// <summary>
        /// 判断对象是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        bool GetAny(Expression<Func<T, bool>> WhereLambda = null);

        /// <summary>
        /// 根据查询过条件进行分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="PageIndex">当前页面</param>
        /// <param name="PageSize">页面的大小</param>
        /// <param name="TotalCount">总记录数</param>
        /// <param name="OrderBy">排序的条件</param>
        /// <param name="WhereLambda">查询条件</param>
        /// <param name="IsOrder">是否正序</param>
        /// <returns></returns>
        List<T> Pagination<TKey>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<T, TKey>> OrderBy, Expression<Func<T, bool>> WhereLambda = null, bool IsOrder = true);
    }
}