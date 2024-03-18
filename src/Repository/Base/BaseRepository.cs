using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly ApplicationDBContext db;

        public BaseRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public bool Add(T Entity)
        {
            db.Set<T>().Add(Entity);
            return db.SaveChanges() > 0;
        }

        public bool AddRange(List<T> Entity)
        {
            db.Set<T>().AddRange(Entity);
            return db.SaveChanges() > 0;
        }

        public bool Remove(T Entity)
        {
            db.Set<T>().Remove(Entity);
            return db.SaveChanges() > 0;
        }

        public bool RemoveByWhere(Expression<Func<T, bool>> whereLambda)
        {
            var EntityModel = db.Set<T>().Where(whereLambda).FirstOrDefault();
            if (EntityModel != null)
            {
                db.Set<T>().Remove(EntityModel);
                int Count = db.SaveChanges();
                return Count > 0;
            }
            return false;
        }

        public bool Update(T Entity)
        {
            var EntityModel = db.Entry<T>(Entity);
            db.Set<T>().Attach(Entity);
            EntityModel.State = EntityState.Modified;
            int Count = db.SaveChanges();
            return Count > 0;
        }

        public bool Update(Expression<Func<T, bool>> WhereLambda, Expression<Func<T, T>> UpdateLambda)
        {
            var entities = db.Set<T>().Where(WhereLambda).ToList();

            if (entities != null && entities.Any())
            {
                foreach (var entity in entities)
                {
                    var updatedEntity = UpdateLambda.Compile().Invoke(entity);
                    db.Entry(entity).CurrentValues.SetValues(updatedEntity);
                }

                return db.SaveChanges() > 0;
            }

            return false;
        }

        public bool Update(List<T> Entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T model, Expression<Func<T, bool>> WhereLambda, params string[] ModifiedProNames)
        {
            throw new NotImplementedException();
        }

        public T FindByID(dynamic ID)
        {
            return db.Set<T>().Find(ID) ?? null;
        }

        public List<T> GetAll(Expression<Func<T, string>> OrderLambda = null)
        {
            return OrderLambda == null ? db.Set<T>().ToList() ?? null : db.Set<T>().OrderBy(OrderLambda).ToList() ?? null;
        }

        public List<T> GetAllByWhere(Expression<Func<T, bool>> WhereLambda = null, Expression<Func<T, string>> OrderLambda = null)
        {
            if (WhereLambda == null && OrderLambda == null)
            {
                return db.Set<T>().ToList() ?? null;
            }
            else if (WhereLambda != null && OrderLambda == null)
            {
                return db.Set<T>().Where(WhereLambda).ToList() ?? null;
            }
            else if (WhereLambda == null && OrderLambda != null)
            {
                return db.Set<T>().OrderBy(OrderLambda).ToList() ?? null;
            }
            else
            {
                return db.Set<T>().Where(WhereLambda).OrderBy(OrderLambda).ToList() ?? null;
            }
        }

        public bool GetAny(Expression<Func<T, bool>> WhereLambda = null)
        {
            // 如果没有传入条件，则返回整个表中是否存在记录
            return WhereLambda == null ? db.Set<T>().Any() : db.Set<T>().Any(WhereLambda);
        }

        public int GetCountByWhere(Expression<Func<T, bool>> WhereLambda = null)
        {
            throw new NotImplementedException();
        }

        public T GetFristDefault(Expression<Func<T, bool>> WhereLambda = null)
        {
            throw new NotImplementedException();
        }

        public List<T> GetSelect(Expression<Func<T, bool>> WhereLambda)
        {
            throw new NotImplementedException();
        }

        public List<T> Pagination<TKey>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<T, TKey>> OrderBy, Expression<Func<T, bool>> WhereLambda = null, bool IsOrder = true)
        {
            var query = db.Set<T>().AsQueryable();
            // 添加筛选条件
            if (WhereLambda != null)
            {
                query = query.Where(WhereLambda);
            }
            // 获取总记录数
            TotalCount = query.Count();
            // 排序
            if (OrderBy != null)
            {
                if (IsOrder)
                {
                    query = query.OrderBy(OrderBy);
                }
                else
                {
                    query = query.OrderByDescending(OrderBy);
                }
            }
            // 分页
            List<T> resultList = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            return resultList;
        }

        public List<T> QueryPro(string Sql, List<SqlParameter> Parms, CommandType CmdType = CommandType.Text)
        {
            throw new NotImplementedException();
        }

        public void RollBackChanges()
        {
            throw new NotImplementedException();
        }
    }
}