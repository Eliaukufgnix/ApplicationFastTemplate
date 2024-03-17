using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Service
{
    public class BaseService<T> : IBaseService<T> where T : CommonColumn
    {
        public readonly IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public bool Add(T Entity)
        {
            return repository.Add(Entity);
        }

        public bool AddRange(List<T> Entity)
        {
            throw new NotImplementedException();
        }

        public T FindByID(dynamic ID)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, string>> OrderLambda = null)
        {
            return repository.GetAll(OrderLambda);
        }

        public List<T> GetAllByWhere(Expression<Func<T, bool>> WhereLambda = null, Expression<Func<T, string>> OrderLambda = null)
        {
            throw new NotImplementedException();
        }

        public bool GetAny(Expression<Func<T, bool>> WhereLambda = null)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Expression<Func<T, bool>> WhereLambda = null)
        {
            throw new NotImplementedException();
        }

        public T GetFristDefault(Expression<Func<T, bool>> WhereLambda = null)
        {
            throw new NotImplementedException();
        }

        public List<T> Pagination(int PageIndex, int PageSize, out int TotalCount, Expression<Func<T, int>> OrderBy = null, bool IsOrder = true, Expression<Func<T, bool>> WhereLambda = null)
        {
            if (OrderBy == null)
            {
                // 默认使用 CreateDate 作为排序键
                OrderBy = x => x.CreateDate;
            }
            return repository.Pagination(PageIndex, PageSize, out TotalCount, OrderBy, WhereLambda, IsOrder);
        }

        public List<T> Pagination<TKey>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<T, TKey>> OrderBy, bool IsOrder = true, Expression<Func<T, bool>> WhereLambda = null)
        {
            return repository.Pagination(PageIndex, PageSize, out TotalCount, OrderBy, WhereLambda, IsOrder);
        }

        public bool Remove(T Entity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveByWhere(Expression<Func<T, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public bool Update(T Entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Expression<Func<T, bool>> WhereLambda, Expression<Func<T, T>> UpdateLambda)
        {
            throw new NotImplementedException();
        }

        public bool Update(List<T> Entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T model, Expression<Func<T, bool>> WhereLambda, params string[] ModifiedProNames)
        {
            throw new NotImplementedException();
        }
    }
}