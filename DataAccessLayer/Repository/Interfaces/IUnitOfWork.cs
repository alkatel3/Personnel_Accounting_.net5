using Models;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<int, Employee> Employees { get; }
        IRepository<int, Department> Departments { get; }

        void Save();
    }
}
