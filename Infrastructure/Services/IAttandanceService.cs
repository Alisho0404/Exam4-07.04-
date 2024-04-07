using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Services
{
    public interface IAttandanceService
    {
        Task<Response<List<Attendance>>> GetAttandanceAsync(); 
        Task<Response<Attendance>> GetAttandanceByIdAsync(int id);
        Task<Response<string>> AddAttendanceAsync(Attendance attendance);  
        Task<Response<string>>UpdateAttendanceAsync(Attendance attendance); 
        Task<Response<bool>>DeleteAttendanceAsync(int id);

    }
}
