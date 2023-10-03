using Models;

namespace DataAccessLayer.Repository
{
    internal class EmployeeRepository : Repository<int, Employee>
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
