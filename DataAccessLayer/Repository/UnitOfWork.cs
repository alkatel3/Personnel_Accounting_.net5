using Models;
using DataAccessLayer.Repository.Interfaces;

namespace DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<int, Employee> _employees = null!;
        private IRepository<int, Department> _departments = null!;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<int, Employee> Employees
        {
            get
            {
                if (_employees == null)
                    _employees = new EmployeeRepository(_context);

                return _employees;
            }
        }

        public IRepository<int, Department> Departments
        {
            get
            {
                if (_departments == null)
                    _departments = new DepartmentRepository(_context);

                return _departments;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
