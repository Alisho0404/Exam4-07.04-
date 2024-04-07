using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IExamService
    {
        Task<Response<List<Exam>>> GetExamAsync();
        Task<Response<Exam>> GetExamByIdAsync(int id);
        Task<Response<string>> AddExamAsync(Exam exam);
        Task<Response<string>> UpdateExamAsync(Exam exam);
        Task<Response<bool>> DeleteExamAsync(int id);
    }
}
