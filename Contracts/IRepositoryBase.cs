using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T model);
        void Update(T model);
        void Delete(T model);
    }
}