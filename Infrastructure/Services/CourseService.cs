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
    public class CourseService : ICourseService
    {
        private readonly DapperContext _context;
        public CourseService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddCourseAsync(Course course)
        {
            try
            {
                var sql = $"insert into course(name,description,gradeId)" +
                    $"values('{course.Name}','{course.Description}',{course.GradeId})";
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

        public async Task<Response<bool>> DeleteCourseAsync(int id)
        {
            try
            {
                var sql = $"Delete from course  where id={@id}";
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

        public async Task<Response<List<Course>>> GetCourseAsync()
        {
            try
            {
                var sql = "Select * from  course";
                var result = await _context.Connection().QueryAsync<Course>(sql);
                return new Response<List<Course>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Course>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Course>> GetCourseByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from  course where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Course>(result);
                }
                return new Response<Course>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Course>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateCourseAsync(Course course)
        {
            try
            {
                var sql = $"update course set name='{course.Name}',description='{course.Description}',gradeId={course.GradeId}" +
                    $"where id={course.GradeId}";
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
