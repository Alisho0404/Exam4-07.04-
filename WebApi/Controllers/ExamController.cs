using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Domain.Models;

 

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/exam")]
    public class ExamController(IExamService examService):ControllerBase
    { 
        private readonly IExamService _examService=examService;

        [HttpGet]
        public async Task<Response<List<Exam>>> GetExamAsync()
        {
            return await _examService.GetExamAsync();
        }

        [HttpGet("{ExamId:int}")]
        public async Task<Response<Exam>> GetExamByIdAsync(int ExamId)
        {
            return await _examService.GetExamByIdAsync(ExamId);
        }

        [HttpPost]
        public async Task<Response<string>> AddExamAsync(Exam Exam)
        {
            return await _examService.AddExamAsync(Exam);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateExamAsync(Exam Exam)
        {
            return await _examService.UpdateExamAsync(Exam);
        }

        [HttpDelete("{ExamId:int}")]
        public async Task<Response<bool>> DeleteExamAsync(int ExamId)
        {
            return await _examService.DeleteExamAsync(ExamId);
        }
    }
}
