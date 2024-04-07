using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ITeacherService
    {
        Task<Response<List<Teacher>>> GetTeacherAsync();
        Task<Response<Teacher>> GetTeacherByIdAsync(int id);
        Task<Response<string>> AddTeacherAsync(Teacher teacher);
        Task<Response<string>> UpdateTeacherAsync(Teacher teacher);
        Task<Response<bool>> DeleteTeacherAsync(int id);
    }
}
