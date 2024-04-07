using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IClassroomService
    {
        Task<Response<List<Classroom>>> GetClassroomAsync();
        Task<Response<Classroom>> GetClassroomByIdAsync(int id);
        Task<Response<string>> AddClassroomAsync(Classroom classroom);
        Task<Response<string>> UpdateClassroomAsync(Classroom classroom);
        Task<Response<bool>> DeleteClassroomAsync(int id);
    }
}
