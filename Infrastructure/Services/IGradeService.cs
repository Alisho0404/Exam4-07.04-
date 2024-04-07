using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IGradeService
    {
        Task<Response<List<Grade>>> GetGradeAsync();
        Task<Response<Grade>> GetGradeByIdAsync(int id);
        Task<Response<string>> AddGradeAsync(Grade grade);
        Task<Response<string>> UpdateGradeAsync(Grade grade);
        Task<Response<bool>> DeleteGradeAsync(int id);
    }
}
