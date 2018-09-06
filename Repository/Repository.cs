using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class Repository<T> : DbContext, IRepository<T> where T : class, new()
    {
        private DbSet<T> Set { get; set; }
        private OceanicaContext context;

        public static IConfiguration ReadConfigurationFile()
        {
            string pPath = Path.GetFullPath(Directory.GetCurrentDirectory());
            var config = new ConfigurationBuilder().SetBasePath(pPath).AddJsonFile("appsettings.json").Build();
            return config;
        }

        public Repository(OceanicaContext context)
        {
            this.context = context;
            Set = context.Set<T>();
        }

        public void Attach(T entity)
        {
            this.context.Attach(entity);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            var items = Set<T>().Where(expression);
            foreach (T item in items)
            {
                Remove(item);
            }
        }
        public void Delete(T item)
        {
            Remove(item);
        }
        public void DeleteAll(IList<T> items)
        {
            RemoveRange(items);
        }
        public T Single(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return Set<T>().SingleOrDefault(expression);
        }
        public T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }

        public T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression, params string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    return context.Set<T>().Include(args[0]).FirstOrDefault(expression);
                case 2:
                    return context.Set<T>().Include(args[0]).Include(args[1]).FirstOrDefault(expression);
                case 3:
                    return context.Set<T>().Include(args[0]).Include(args[1]).Include(args[2]).FirstOrDefault(expression);
                case 4:
                    return context.Set<T>().Include(args[0]).Include(args[1]).Include(args[2]).Include(args[3]).FirstOrDefault(expression);                    
                case 5:
                    return context.Set<T>().Include(args[0]).Include(args[1]).Include(args[2]).Include(args[3]).Include(args[4]).FirstOrDefault(expression);                    

            }           

            return context.Set<T>().Include(args[0]).Include(args[1]).FirstOrDefault(expression);
        }


        public IQueryable<T> All()
        {
            return context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> All(params string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    return context.Set<T>().Include(args[0]).AsNoTracking();
                case 2:
                    return context.Set<T>().Include(args[0]).Include(args[1]).AsNoTracking();
                case 3:
                    return context.Set<T>().Include(args[0]).Include(args[1]).Include(args[2]).AsNoTracking();
            }
            return context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> All(int page, int pageSize)
        {
            return context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking();
        }

        public IQueryable<T> All(int page, int pageSize, params string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    return context.Set<T>().Include(args[0]).Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking();
            }
            return context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking();
        }

        public IQueryable<T> All(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> All(Expression<Func<T, bool>> expression, params string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    return context.Set<T>().Include(args[0]).Where(expression).AsNoTracking();
                case 2:
                    return context.Set<T>().Include(args[0]).Include(args[1]).Where(expression).AsNoTracking();
            }
            return context.Set<T>().Where(expression).AsNoTracking();
        }


        public IQueryable<T> All(int page, int pageSize, Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking();
        }

        public IQueryable<T> All(int page, int pageSize, Expression<Func<T, bool>> expression, params string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    return context.Set<T>().Include(args[0]).Where(expression).Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking();
            }

            return context.Set<T>().Where(expression).Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking();
        }

        public void Add(T item)
        {
            context.Add(item);
        }
        public void Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public void Update(T item)
        {
            context.Update(item);
        }
    }
}