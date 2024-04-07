﻿using Dapper;
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
    public class ExamTypeService : IExamTypeService
    {
        private readonly DapperContext _context;
        public ExamTypeService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddExamTypeAsync(ExamType examType)
        {
            try
            {
                var sql = $"insert into examType(name,description)" +
                    $"values('{examType.Name}','{examType.Descrition}')";
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

        public async Task<Response<bool>> DeleteExamTypeAsync(int id)
        {
            try
            {
                var sql = $"Delete from  examType  where id={@id}";
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

        public async Task<Response<List<ExamType>>> GetExamTypeAsync()
        {
            try
            {
                var sql = "Select * from  examType";
                var result = await _context.Connection().QueryAsync<ExamType>(sql);
                return new Response<List<ExamType>>(result.ToList());
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<ExamType>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<ExamType>> GetExamTypeByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from  examType where id ={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<ExamType>(result);
                }
                return new Response<ExamType>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<ExamType>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateExamTypeAsync(ExamType examType)
        {
            try
            {
                var sql = $"update examType set name='{examType.Name}',description='{examType.Descrition}'" +
                    $"where id={examType.Id}";
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
