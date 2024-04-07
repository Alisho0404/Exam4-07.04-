using Microsoft.AspNetCore.Mvc;
using Infrastructure.DataContext;
using Infrastructure.Services;
using Domain.Models;
using Domain.Response;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/attendance")]
    public class AttendanceController(IAttandanceService attandanceService):ControllerBase
    {  
        private readonly IAttandanceService _attandanceService=attandanceService;

        [HttpGet]
        public async Task<Response<List<Attendance>>> GetAttendanceAsync()
        {
            return await _attandanceService.GetAttandanceAsync();
        } 

        [HttpGet("{attendanceId:int}")] 
        public async Task<Response<Attendance>> GetAttendanceByIdAsync(int attendanceId)
        {
            return await _attandanceService.GetAttandanceByIdAsync(attendanceId);
        }

        [HttpPost] 
        public async Task<Response<string>> AddAtandanceAsync(Attendance attendance)
        {
            return await _attandanceService.AddAttendanceAsync(attendance);
        } 

        [HttpPut]
        public async Task<Response<string>>UpdateAttendanceAsync(Attendance attendance)
        {
            return await _attandanceService.UpdateAttendanceAsync(attendance);
        }

        [HttpDelete("{attendanceId:int}")]
        public async Task<Response<bool>> DeleteAttandanceAsync(int attendanceId)
        {
            return await _attandanceService.DeleteAttendanceAsync(attendanceId);
        }
        
    }
}
