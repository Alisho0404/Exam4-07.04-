using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/classroom")]
    public class ClassroomController(IClassroomService classroomService):ControllerBase
    { 
        private readonly IClassroomService _classroomService=classroomService;

        [HttpGet]
        public async Task<Response<List<Classroom>>> GetClassroomAsync()
        {
            return await _classroomService.GetClassroomAsync();
        }

        [HttpGet("{ClassroomId:int}")]
        public async Task<Response<Classroom>> GetClassroomByIdAsync(int ClassroomId)
        {
            return await _classroomService.GetClassroomByIdAsync(ClassroomId);
        }

        [HttpPost]
        public async Task<Response<string>> AddClassroomAsync(Classroom Classroom)
        {
            return await _classroomService.AddClassroomAsync(Classroom);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateClassroomAsync(Classroom Classroom)
        {
            return await _classroomService.UpdateClassroomAsync(Classroom);
        }

        [HttpDelete("{ClassroomId:int}")]
        public async Task<Response<bool>> DeleteClassroomAsync(int ClassroomId)
        {
            return await _classroomService.DeleteClassroomAsync(ClassroomId);
        }
    }
}
