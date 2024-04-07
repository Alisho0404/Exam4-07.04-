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
    public class ClassroomStudentService : IClassroomStudentService
    {
        private readonly DapperContext _context;
        public ClassroomStudentService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddClassroomStudentAsync(ClassroomStudent classroomStudent)
        {
            try
            {
                var sql = $"insert into classroomStudent(classroomId,studentId)" +
                    $"values({classroomStudent.ClassroomId},{classroomStudent.StudentId})";
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

        public async Task<Response<bool>> DeleteClassroomStudentAsync(int id)
        {
            try
            {
                var sql = $"Delete from classroomStudent  where id={@id}";
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

        public async Task<Response<List<ClassroomStudent>>> GetClassroomStudentAsync()
        {
            try
            {
                var sql = "Select * from classroomStudent ";
                var result = await _context.Connection().QueryAsync<ClassroomStudent>(sql);
                return new Response<List<ClassroomStudent>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<ClassroomStudent>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<ClassroomStudent>> GetClassroomStudentByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from classroomStudent  where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<ClassroomStudent>(result);
                }
                return new Response<ClassroomStudent>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<ClassroomStudent>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateClassroomStudentAsync(ClassroomStudent classroomStudent)
        {
            try
            {
                var sql = $"update classroomStudent set classroomId={classroomStudent.ClassroomId},studentId={classroomStudent.StudentId}" +
                    $"where id={classroomStudent.Id}";
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
