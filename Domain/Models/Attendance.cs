using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public  DateTime Date { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        
    }
}
