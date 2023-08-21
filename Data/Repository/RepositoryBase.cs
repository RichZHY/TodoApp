using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApp.API.DataAccess.DBContext;

namespace Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MainContext RepositoryContext { get; set; }
        private DbSet<T> DbSet { get; set; }
        public RepositoryBase(MainContext context)
        {
            RepositoryContext = context;
            DbSet = RepositoryContext.Set<T>();
        }
        public void Create(T model)
        {
            DbSet.Add(model);
        }
        public void Update(T model)
        {
            DbSet.Update(model);
        }
        public void Delete(T model)
        {
            DbSet.Remove(model);
        }
        public IQueryable<T> FindAll()
        { 
            return DbSet.AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
