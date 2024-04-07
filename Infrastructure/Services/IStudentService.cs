using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IStudentService
    {
        Task<Response<List<Student>>> GetStudentAsync();
        Task<Response<Student>> GetStudentByIdAsync(int id);
        Task<Response<string>> AddStudentAsync(Student student);
        Task<Response<string>> UpdateStudentAsync(Student student);
        Task<Response<bool>> DeleteStudentAsync(int id);
    }
}
