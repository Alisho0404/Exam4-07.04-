using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IClassroomStudentService
    {
        Task<Response<List<ClassroomStudent>>> GetClassroomStudentAsync();
        Task<Response<ClassroomStudent>> GetClassroomStudentByIdAsync(int id);
        Task<Response<string>> AddClassroomStudentAsync(ClassroomStudent classroomStudent);
        Task<Response<string>> UpdateClassroomStudentAsync(ClassroomStudent classroomStudent);
        Task<Response<bool>> DeleteClassroomStudentAsync(int id);
    }
}
