using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IMedidasRepository
    {
        Task<Medidas> Get(string CCorreo_electronico);
        Task<IEnumerable<Medidas>> GetAll();
        Task Add(Medidas medidas);
        Task Delete(string CCorreo_electronico);
        Task Update(Medidas medidas);           
    }
}