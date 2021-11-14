using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IAdministradorRepository
    {
        Task<Administrador> Get(string Correo_electronico);
        Task<IEnumerable<Administrador>> GetAll();
        Task Add(Administrador administrador);
        Task Delete(string Correo_electronico);
        Task Update(Administrador administrador);           
    }
}