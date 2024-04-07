using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/grade")]
    public class GradeController(IGradeService gradeService) : ControllerBase 
    { 
        private readonly IGradeService _GradeService=gradeService;

        [HttpGet]
        public async Task<Response<List<Grade>>> GetGradeAsync()
        {
            return await _GradeService.GetGradeAsync();
        }

        [HttpGet("{GradeId:int}")]
        public async Task<Response<Grade>> GetGradeByIdAsync(int GradeId)
        {
            return await _GradeService.GetGradeByIdAsync(GradeId);
        }

        [HttpPost]
        public async Task<Response<string>> AddGradeAsync(Grade Grade)
        {
            return await _GradeService.AddGradeAsync(Grade);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateGradeAsync(Grade Grade)
        {
            return await _GradeService.UpdateGradeAsync(Grade);
        }

        [HttpDelete("{GradeId:int}")]
        public async Task<Response<bool>> DeleteGradeAsync(int GradeId)
        {
            return await _GradeService.DeleteGradeAsync(GradeId);
        }
    }
}
