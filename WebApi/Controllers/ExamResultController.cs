using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/examResult")]
    public class ExamResultController(IExamResultService examResultService):ControllerBase
    { 
        private readonly IExamResultService _examResultService=examResultService;

        [HttpGet]
        public async Task<Response<List<ExamResult>>> GetExamResultAsync()
        {
            return await _examResultService.GetExamResultAsync();
        }

        [HttpGet("{ExamResultId:int}")]
        public async Task<Response<ExamResult>> GetExamResultByIdAsync(int ExamResultId)
        {
            return await _examResultService.GetExamResultByIdAsync(ExamResultId);
        }

        [HttpPost]
        public async Task<Response<string>> AddExamResultAsync(ExamResult ExamResult)
        {
            return await _examResultService.AddExamResultAsync(ExamResult);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateExamResultAsync(ExamResult ExamResult)
        {
            return await _examResultService.UpdateExamResultAsync(ExamResult);
        }

        [HttpDelete("{ExamResultId:int}")]
        public async Task<Response<bool>> DeleteExamResultAsync(int ExamResultId)
        {
            return await _examResultService.DeleteExamResultAsync(ExamResultId);
        }
    }
}
