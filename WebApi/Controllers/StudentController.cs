using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Response;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController(IStudentService studentService) : ControllerBase
    { 
        private readonly IStudentService _studentService=studentService;

        [HttpGet]
        public async Task<Response<List<Student>>> GetStudentAsync()
        {
            return await _studentService.GetStudentAsync();
        }

        [HttpGet("{studentId:int}")] 
        public async Task<Response<Student>>GetStudentByIdAsync(int studentId)
        {
            return await _studentService.GetStudentByIdAsync(studentId);
        }

        [HttpPost] 
        public async Task<Response<string>>AddStudentAsync(Student student)
        {
            return await _studentService.AddStudentAsync(student);
        }

        [HttpPut] 
        public async Task<Response<string>>UpdateStudentAsync(Student student)
        {
            return await _studentService.UpdateStudentAsync(student);
        }

        [HttpDelete("{studentId:int}")]
        public async Task<Response<bool>>DeleteStudentAsync(int studentId)
        {
            return await _studentService.DeleteStudentAsync(studentId);
        }
    }
}
