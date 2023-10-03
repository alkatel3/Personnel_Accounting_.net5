using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
namespace Models
{
    public class Employee : BaseEntity<int>
    {
        [Required]
        [DisplayName("Прізвище")]
        public string LastName { get; set; } = null!;
        [Required]
        [DisplayName("Ім'я")]
        public string FirstName { get; set; } = null!;
        [DisplayName("По-батькові")]
        public string? MiddleName { get; set; }
        [DisplayName("Рік народження")]
        [Range(1900, 2100)]
        public uint? BirthYear { get; set; }
        [DisplayName("Освіта")]
        public string? Education { get; set; }
        [Required]
        [DisplayName("Посада")]
        public string Position { get; set; } = null!;
        [Required]
        [DisplayName("Оклад")]
        [Range(0, double.MaxValue)]
        public double Salary { get; set; }
        [DisplayName("Підпорядкований")]
        public int? SupervisorId { get; set; }
        [ForeignKey("SupervisorId")]
        public Employee? Supervisor { get; set; }
        [DisplayName("Департамент")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

    }
}
