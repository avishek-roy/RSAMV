using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RSAMV_Service.Interfaces
{
    public interface IGenericFactory<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        bool HasData(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        bool IsDuplicate(T entity);
        void Add(T entity);
        void Delete(T entity);
        void Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Edit(T entity);
        void Save();
        String getHTML();
    }
}