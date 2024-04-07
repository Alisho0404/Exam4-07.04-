using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IExamTypeService
    {
        Task<Response<List<ExamType>>> GetExamTypeAsync();
        Task<Response<ExamType>> GetExamTypeByIdAsync(int id);
        Task<Response<string>> AddExamTypeAsync(ExamType examType);
        Task<Response<string>> UpdateExamTypeAsync(ExamType examType);
        Task<Response<bool>> DeleteExamTypeAsync(int id);
    }
}
