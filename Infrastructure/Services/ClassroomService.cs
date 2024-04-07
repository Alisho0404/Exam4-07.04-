using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly DapperContext _context;
        public ClassroomService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddClassroomAsync(Classroom classroom)
        {
            try
            {
                var sql = $"insert into classroom(section,status,remark,gradeId,teacherId)" +
                    $"values('{classroom.Section}','{classroom.Status}','{classroom.Remark}',{classroom.GradeId},{classroom.TeacherId})";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
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

        public async Task<Response<bool>> DeleteClassroomAsync(int id)
        {
            try
            {
                var sql = $"Delete from  classroom where id={@id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, "error in deleting");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<Classroom>>> GetClassroomAsync()
        {
            try
            {
                var sql = "Select * from classroom ";
                var result = await _context.Connection().QueryAsync<Classroom>(sql);
                return new Response<List<Classroom>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Classroom>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Classroom>> GetClassroomByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from classroom  where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Classroom>(result);
                }
                return new Response<Classroom>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Classroom>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateClassroomAsync(Classroom classroom)
        {
            try
            {
                var sql = $"update classroom set section='{classroom.Section}',status='{classroom.Status}'," +
                    $"remark='{classroom.Remark}',gradeId={classroom.GradeId},teacherId={classroom.TeacherId}" +
                    $"where id={classroom.Id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
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
