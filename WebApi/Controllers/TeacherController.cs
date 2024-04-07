using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/teacher")]
    
    public class TeacherController(ITeacherService teacherService):ControllerBase
    {
        private readonly ITeacherService _TeacherService=teacherService;

        [HttpGet]
        public async Task<Response<List<Teacher>>> GetTeacherAsync()
        {
            return await _TeacherService.GetTeacherAsync();
        }

        [HttpGet("{TeacherId:int}")]
        public async Task<Response<Teacher>> GetTeacherByIdAsync(int TeacherId)
        {
            return await _TeacherService.GetTeacherByIdAsync(TeacherId);
        }

        [HttpPost]
        public async Task<Response<string>> AddTeacherAsync(Teacher Teacher)
        {
            return await _TeacherService.AddTeacherAsync(Teacher);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateTeacherAsync(Teacher Teacher)
        {
            return await _TeacherService.UpdateTeacherAsync(Teacher);
        }

        [HttpDelete("{TeacherId:int}")]
        public async Task<Response<bool>> DeleteTeacherAsync(int TeacherId)
        {
            return await _TeacherService.DeleteTeacherAsync(TeacherId);
        }
    }
}
