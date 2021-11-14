using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IPlanRepository
    {
        Task<Plan> Get(string Nombre);
        Task<IEnumerable<Plan>> GetAll();
        Task Add(Plan plan);
        Task Delete(string Nombre);
        Task Update(Plan plan);           
    }
}