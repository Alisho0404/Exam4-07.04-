using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int ExamType { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }

    }
}
