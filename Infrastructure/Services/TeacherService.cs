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
    public class TeacherService : ITeacherService
    {
        private readonly DapperContext _context;
        public TeacherService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddTeacherAsync(Teacher teacher)
        {
            try
            {
                var sql = $"insert into teacher (firstname,lastname,password,phone,Dob,email)" +
                    $"values('{teacher.FirstName}','{teacher.LastName}','{teacher.Password}','{teacher.Phone}'," +
                    $"'{teacher.Dob}','{teacher.Email}')";
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

        public async Task<Response<bool>> DeleteTeacherAsync(int id)
        {
            try
            {
                var sql = $"Delete from teacher where id={@id}";
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

        public async Task<Response<List<Teacher>>> GetTeacherAsync()
        {
            try
            {
                var sql = "Select * from teacher";
                var result = await _context.Connection().QueryAsync<Teacher>(sql);
                return new Response<List<Teacher>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Teacher>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Teacher>> GetTeacherByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from Teacher where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Teacher>(result);
                }
                return new Response<Teacher>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Teacher>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateTeacherAsync(Teacher teacher)
        {
            try
            {
                var sql = $"update teacher set firstname='{teacher.FirstName}',lastname='{teacher.LastName}'," +
                    $"password='{teacher.Password}',phone='{teacher.Phone}',Dob='{teacher.Dob}',email='{teacher.Email}'" +
                    $"where id={teacher.Id}";
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
