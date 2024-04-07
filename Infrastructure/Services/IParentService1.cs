using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IParentService1
    {
        Task<Response<List<Parent>>> GetParentAsync();
        Task<Response<Parent>> GetParentByIdAsync(int id);
        Task<Response<string>> AddParentAsync(Parent parent);
        Task<Response<string>> UpdateParentAsync(Parent parent);
        Task<Response<bool>> DeleteParentAsync(int id);
    }
}
