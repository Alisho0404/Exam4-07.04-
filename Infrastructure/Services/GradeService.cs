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
    public class GradeService : IGradeService
    {
        private readonly DapperContext _context;
        public GradeService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddGradeAsync(Grade grade)
        {
            try
            {
                var sql = $"insert into grade(name,description)" +
                    $"values('{grade.Name}','{grade.Description}')";
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

        public async Task<Response<bool>> DeleteGradeAsync(int id)
        {
            try
            {
                var sql = $"Delete from grade where id={@id}";
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

        public async Task<Response<List<Grade>>> GetGradeAsync()
        {
            try
            {
                var sql = "Select * from  grade";
                var result = await _context.Connection().QueryAsync<Grade>(sql);
                return new Response<List<Grade>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Grade>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Grade>> GetGradeByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from grade  where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Grade>(result);
                }
                return new Response<Grade>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Grade>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateGradeAsync(Grade grade)
        {
            try
            {
                var sql = $"update grade set name='{grade.Name}',description='{grade.Description}' " +
                    $"where id={grade.Id}";
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
