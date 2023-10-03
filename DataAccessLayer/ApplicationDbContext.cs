using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Software Development" },
                new Department { Id = 2, Name = "Quality Assurance and Testing" },
                new Department { Id = 3, Name = "Technical Support" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    LastName = "Янишин",
                    FirstName = "Віталій",
                    MiddleName = "Володимирович",
                    BirthYear = 2002,
                    Education = "КПІ 121",
                    Position = "Junior",
                    Salary = 700,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2,
                    LastName = "Пеленський",
                    FirstName = "Артур",
                    MiddleName = "Богданович",
                    BirthYear = 2002,
                    Education = "ЛП",
                    Position = "Middle",
                    Salary = 1200,
                    DepartmentId = 2,
                    SupervisorId = 1
                },
                new Employee
                {
                    Id = 3,
                    LastName = "Мисаковець",
                    FirstName = "Михайло",
                    BirthYear = 2002,
                    Education = "ЛНУ",
                    Position = "Middle",
                    Salary = 1300,
                    DepartmentId = 3,
                    SupervisorId = 1
                },
                new Employee
                {
                    Id = 4,
                    LastName = "Вовк",
                    FirstName = "Евген",
                    Position = "Lead",
                    Salary = 1300,
                    DepartmentId = 1,
                    SupervisorId = 1
                }
            );
        }
    }
}
