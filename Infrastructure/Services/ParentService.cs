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
    public class ParentService : IParentService1
    {
        private readonly DapperContext _context;
        public ParentService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddParentAsync(Parent parent)
        {
            try
            {
                var sql = $" insert into parent(firstname,lastname,password,phone,Dob,email)" +
                    $"values('{parent.FirstName}','{parent.LastName}','{parent.Password}','{parent.Phone}'," +
                    $"'{parent.Dob}','{parent.Email}')";
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

        public async Task<Response<bool>> DeleteParentAsync(int id)
        {
            try
            {
                var sql = $"Delete from Parent where id={@id}";
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

        public async Task<Response<List<Parent>>> GetParentAsync()
        {
            try
            {
                var sql = "Select * from Parent";
                var result = await _context.Connection().QueryAsync<Parent>(sql);
                return new Response<List<Parent>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Parent>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Parent>> GetParentByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from Parent where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Parent>(result);
                }
                return new Response<Parent>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Parent>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateParentAsync(Parent parent)
        {
            try
            {
                var sql = $"update parent set firstname='{parent.FirstName}',lastname='{parent.LastName}'," +
                    $"password='{parent.Password}',phone='{parent.Phone}',Dob='{parent.Dob}',email='{parent.Email}' " +
                    $"where id={parent.Id}";
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
