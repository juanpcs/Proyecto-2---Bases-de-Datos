using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IProductoRepository
    {
        Task<Producto> Get(decimal Codigo_barras);
        Task<IEnumerable<Producto>> GetAll();
        Task Add(Producto producto);
        Task Delete(decimal Codigo_barras);
        Task Update(Producto producto);           
    }
}