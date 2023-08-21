using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TodoApp.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
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
