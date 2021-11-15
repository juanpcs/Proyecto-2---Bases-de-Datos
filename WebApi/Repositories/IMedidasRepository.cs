using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IMedidasRepository
    {
        Task<Medidas> Get(int MedidasId);
        Task<IEnumerable<Medidas>> GetAll();
        Task Add(Medidas medidas);
        Task Delete(int MedidasId);
        Task Update(Medidas medidas);           
    }
}