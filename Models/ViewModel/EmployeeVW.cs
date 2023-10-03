using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Models.ViewModel
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; } = null!;
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; } = null!;
        public Dictionary<int, IEnumerable<SelectListItem>> EmployeeList { get; set; } = null!;
    }
}
