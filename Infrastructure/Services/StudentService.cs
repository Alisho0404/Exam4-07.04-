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
    public class StudentService : IStudentService
    {
        private readonly DapperContext _context;
        public StudentService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddStudentAsync(Student student)
        {
            try
            {
                var sql = $"insert into student(firstname,lastname,password,phone,Dob,parentId)" +
                    $"values('{student.FirstName}','{student.LastName}','{student.Password}','{student.Phone}'," +
                    $"'{student.Dob}',{student.ParentId})";
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

        public async Task<Response<bool>> DeleteStudentAsync(int id)
        {
            try
            {
                var sql = $"Delete from student where id={@id}";
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

        public async Task<Response<List<Student>>> GetStudentAsync()
        {
            try
            {
                var sql = "Select * from student";
                var result = await _context.Connection().QueryAsync<Student>(sql);
                return new Response<List<Student>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Student>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Student>> GetStudentByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from Student where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Student>(result);
                }
                return new Response<Student>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Student>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateStudentAsync(Student student)
        {
            try
            {
                var sql = $"update student set firstname='{student.FirstName}',lastname='{student.LastName}'," +
                    $"password='{student.Password}',phone='{student.Phone}',Dob='{student.Dob}',parentId={student.ParentId}" +
                    $"where id={student.Id}";
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
