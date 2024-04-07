using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public required string Section { get; set; }
        public required string Status { get; set; }
        public required string Remark { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
        
    }
}
