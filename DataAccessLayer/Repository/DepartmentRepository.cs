using Models;

namespace DataAccessLayer.Repository
{
    public class DepartmentRepository : Repository<int, Department>
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
