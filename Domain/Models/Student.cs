using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public DateTime Dob { get; set; }
        public int ParentId { get; set; }
    }
}
