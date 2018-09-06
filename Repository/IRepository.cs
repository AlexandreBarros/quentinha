namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    public interface IRepository<T> where T : class, new()
    {
        void Delete(Expression<Func<T, bool>> expression);
        void Delete(T item);
        void DeleteAll(IList<T>items);
        void Attach(T entity);
        T Single(Expression<Func<T, bool>> expression) ;
        System.Linq.IQueryable<T> All() ;
        IQueryable<T> All(params string[] args);
        System.Linq.IQueryable<T> All(int page, int pageSize);
        IQueryable<T> All(int page, int pageSize, params string[] args);
        IQueryable<T> All(Expression<Func<T, bool>> expression);
        IQueryable<T> All(int page, int pageSize, Expression<Func<T, bool>> expression);
        IQueryable<T> All(int page, int pageSize, Expression<Func<T, bool>> expression, params string[] args);
        IQueryable<T> All(System.Linq.Expressions.Expression<Func<T, bool>> expression, params string[] args);
        void Add(T item) ;
        void Add(IEnumerable<T> items);
        T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression, params string[] args);
        
        void Update(T item);
    }
}
