using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsCRUDAPIs.Models
{
    [Table("Students")]
    public class Students
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = "";
        public DateTime EnrollmentDate { get; set; }
    }
}