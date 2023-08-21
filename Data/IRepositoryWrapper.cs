using Data.IRepositories;

namespace Data
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }

        void Commit();
    }
}