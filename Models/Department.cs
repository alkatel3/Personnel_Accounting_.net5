using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models
{
    public class Department : BaseEntity<int>
    {
        [Required]
        [DisplayName("Назва")]
        public string Name { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}
