using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
       
    }
}
