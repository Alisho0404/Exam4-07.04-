using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Infrastructure.Services
{
    public class AttandanceService : IAttandanceService
    {
        private readonly DapperContext _context;
        public AttandanceService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddAttendanceAsync(Attendance attendance)
        {
            try
            {
                var sql = $"insert into attendance(Date,studentId,status,remark)" +
                    $"values('{attendance.Date}',{attendance.StudentId},'{attendance.Status}','{attendance.Remark}')";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result>0)
                {
                    return new Response<string>("Succesfully added");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Error in adding");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteAttendanceAsync(int id)
        {
            try
            {
                var sql = $"Delete from attendance where id={@id}";
                var result = await _context.Connection().ExecuteAsync(sql); 
                if (result>0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, "error in deleting");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message); 
                return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
            }
        }

        public async Task<Response<List<Attendance>>> GetAttandanceAsync()
        {
            try
            {
                var sql = "Select * from attendance"; 
                var result=await _context.Connection().QueryAsync<Attendance>(sql);
                return new Response<List<Attendance>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Attendance>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Attendance>> GetAttandanceByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from attendance where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result!=null)
                {
                    return new Response<Attendance>(result); 
                }
                return new Response<Attendance>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message); 
                return new Response<Attendance>(HttpStatusCode.InternalServerError,e.Message) ;
            }
        }

        public async Task<Response<string>> UpdateAttendanceAsync(Attendance attendance)
        {
            try
            {
                var sql = $"update attendance set Date='{attendance.Date}',studentId={attendance.StudentId}," +
                    $"status='{attendance.Status}',remark='{attendance.Remark}'" +
                    $"where id={attendance.Id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result>0)
                {
                    return new Response<string>("Succesfully updated");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
