using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/parent")]
    public class ParentController(IParentService1 parentService):ControllerBase 
    {
        private readonly IParentService1 _ParentService=parentService;

        [HttpGet]
        public async Task<Response<List<Parent>>> GetParentAsync()
        {
            return await _ParentService.GetParentAsync();
        }

        [HttpGet("{ParentId:int}")]
        public async Task<Response<Parent>> GetParentByIdAsync(int ParentId)
        {
            return await _ParentService.GetParentByIdAsync(ParentId);
        }

        [HttpPost]
        public async Task<Response<string>> AddParentAsync(Parent Parent)
        {
            return await _ParentService.AddParentAsync(Parent);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateParentAsync(Parent Parent)
        {
            return await _ParentService.UpdateParentAsync(Parent);
        }

        [HttpDelete("{ParentId:int}")]
        public async Task<Response<bool>> DeleteParentAsync(int ParentId)
        {
            return await _ParentService.DeleteParentAsync(ParentId);
        }
    }
}
