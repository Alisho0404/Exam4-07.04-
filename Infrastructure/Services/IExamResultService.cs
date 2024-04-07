using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IExamResultService
    {
        Task<Response<List<ExamResult>>> GetExamResultAsync();
        Task<Response<ExamResult>> GetExamResultByIdAsync(int id);
        Task<Response<string>> AddExamResultAsync(ExamResult examResult);
        Task<Response<string>> UpdateExamResultAsync(ExamResult examResult);
        Task<Response<bool>> DeleteExamResultAsync(int id);
    }
}
