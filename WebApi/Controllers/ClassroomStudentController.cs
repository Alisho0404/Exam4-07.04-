using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/classroomStudent")]
    public class ClassroomStudentController(IClassroomStudentService classroomStudentService) : ControllerBase  
    { 
        private readonly IClassroomStudentService _classroomStudentService=classroomStudentService;

        [HttpGet]
        public async Task<Response<List<ClassroomStudent>>> GetClassroomStudentAsync()
        {
            return await _classroomStudentService.GetClassroomStudentAsync();
        }

        [HttpGet("{ClassroomStudentId:int}")]
        public async Task<Response<ClassroomStudent>> GetClassroomStudentByIdAsync(int ClassroomStudentId)
        {
            return await _classroomStudentService.GetClassroomStudentByIdAsync(ClassroomStudentId);
        }

        [HttpPost]
        public async Task<Response<string>> AddClassroomStudentAsync(ClassroomStudent ClassroomStudent)
        {
            return await _classroomStudentService.AddClassroomStudentAsync(ClassroomStudent);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateClassroomStudentAsync(ClassroomStudent ClassroomStudent)
        {
            return await _classroomStudentService.UpdateClassroomStudentAsync(ClassroomStudent);
        }

        [HttpDelete("{ClassroomStudentId:int}")]
        public async Task<Response<bool>> DeleteClassroomStudentAsync(int ClassroomStudentId)
        {
            return await _classroomStudentService.DeleteClassroomStudentAsync(ClassroomStudentId);
        }
    }
}
