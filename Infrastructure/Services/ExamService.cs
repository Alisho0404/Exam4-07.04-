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
    public class ExamService : IExamService
    {
        private readonly DapperContext _context;
        public ExamService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddExamAsync(Exam exam)
        {
            try
            {
                var sql = $"insert into exam(examType,name,startDate)" +
                    $"values({exam.ExamType},'{exam.Name}','{exam.StartDate}')";
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

        public async Task<Response<bool>> DeleteExamAsync(int id)
        {
            try
            {
                var sql = $"Delete from  exam where id={@id}";
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

        public async Task<Response<List<Exam>>> GetExamAsync()
        {
            try
            {
                var sql = "Select * from  exam";
                var result = await _context.Connection().QueryAsync<Exam>(sql);
                return new Response<List<Exam>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Exam>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Exam>> GetExamByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from exam where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Exam>(result);
                }
                return new Response<Exam>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Exam>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateExamAsync(Exam exam)
        {
            try
            {
                var sql = $"update exam set examType={exam.ExamType},name='{exam.Name}',startDate='{exam.StartDate}'" +
                    $"where id={exam.Id}";
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
