using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IRecetaRepository
    {
        Task<Receta> Get(string Nombre);
        Task<IEnumerable<Receta>> GetAll();
        Task Add(Receta receta);
        Task Delete(string Nombre);
        Task Update(Receta receta);      
    }
}