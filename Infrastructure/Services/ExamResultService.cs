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
    public class ExamResultService : IExamResultService
    {
        private readonly DapperContext _context;
        public ExamResultService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddExamResultAsync(ExamResult examResult)
        {
            try
            {
                var sql = $"insert into examResult(examid,studentId,courseid,marks)" +
                    $"values({examResult.ExamId},{examResult.StudentId},{examResult.CourseId},'{examResult.Marks}')";
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

        public async Task<Response<bool>> DeleteExamResultAsync(int id)
        {
            try
            {
                var sql = $"Delete from  examResult where id={@id}";
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

        public async Task<Response<List<ExamResult>>> GetExamResultAsync()
        {
            try
            {
                var sql = "Select * from examResult ";
                var result = await _context.Connection().QueryAsync<ExamResult>(sql);
                return new Response<List<ExamResult>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<ExamResult>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<ExamResult>> GetExamResultByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from examResult  where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<ExamResult>(result);
                }
                return new Response<ExamResult>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<ExamResult>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateExamResultAsync(ExamResult examResult)
        {
            try
            {
                var sql = $"update examResult set examid={examResult.ExamId},studentId={examResult.StudentId}," +
                    $"courseid={examResult.CourseId},marks='{examResult.Marks}'" +
                    $"where id ={examResult.Id}";
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
