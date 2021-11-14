using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface INutricionistaRepository
    {
        Task<Nutricionista> Get(string Correo_electronico);
        Task<IEnumerable<Nutricionista>> GetAll();
        Task Add(Nutricionista nutricionista);
        Task Delete(string Correo_electronico);
        Task Update(Nutricionista nutricionista);           
    }
}