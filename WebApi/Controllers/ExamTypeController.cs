using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/examType")]
    public class ExamTypeController(IExamTypeService examTypeService):ControllerBase 
    { 
        private readonly IExamTypeService _examTypeService=examTypeService;

        [HttpGet]
        public async Task<Response<List<ExamType>>> GetExamTypeAsync()
        {
            return await _examTypeService.GetExamTypeAsync();
        }

        [HttpGet("{ExamTypeId:int}")]
        public async Task<Response<ExamType>> GeExamTypetByIdAsync(int ExamTypeId)
        {
            return await _examTypeService.GetExamTypeByIdAsync(ExamTypeId);
        }

        [HttpPost]
        public async Task<Response<string>> AddExamTypeAsync(ExamType ExamType)
        {
            return await _examTypeService.AddExamTypeAsync(ExamType);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateExamTypeAsync(ExamType ExamType)
        {
            return await _examTypeService.UpdateExamTypeAsync(ExamType);
        }

        [HttpDelete("{ExamTypeId:int}")]
        public async Task<Response<bool>> DeleteExamTypeAsync(int ExamTypeId)
        {
            return await _examTypeService.DeleteExamTypeAsync(ExamTypeId);
        }
    }
}
