using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController(ICourseService courseService):ControllerBase
    {
        private readonly ICourseService _courseService=courseService;
        [HttpGet]
        public async Task<Response<List<Course>>> GetCourseAsync()
        {
            return await _courseService.GetCourseAsync();
        }

        [HttpGet("{CourseId:int}")]
        public async Task<Response<Course>> GetCourseByIdAsync(int CourseId)
        {
            return await _courseService.GetCourseByIdAsync(CourseId);
        }

        [HttpPost]
        public async Task<Response<string>> AddCourseAsync(Course Course)
        {
            return await _courseService.AddCourseAsync(Course);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateCourseAsync(Course Course)
        {
            return await _courseService.UpdateCourseAsync(Course);
        }

        [HttpDelete("{CourseId:int}")]
        public async Task<Response<bool>> DeleteCourseAsync(int CourseId)
        {
            return await _courseService.DeleteCourseAsync(CourseId);
        }
    }
}
