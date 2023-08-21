using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataTransferObjects
{
    public class EmployeeUpdateDto
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public string? Education { get; set; }
        public string? Company { get; set; }
        public int Experience { get; set; }
        public int Package { get; set; }
    }
}
