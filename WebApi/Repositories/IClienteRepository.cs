using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IClienteRepository
    {
        Task<Cliente> Get(string Correo_electronico);
        Task<IEnumerable<Cliente>> GetAll();
        Task Add(Cliente cliente);
        Task Delete(string Correo_electronico);
        Task Update(Cliente cliente);           
    }
}