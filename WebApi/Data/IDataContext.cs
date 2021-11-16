using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

// Represents a session with the database and can be used to query and save instances of your entities.

namespace WebApi.Data
{
    public interface IDataContext
    {
        DbSet<Nutricionista> NUTRICIONISTA { get; init; }
        DbSet<Cliente> CLIENTE { get; init; }
        DbSet<Plan> PLAN_ { get; init; }
        DbSet<Medidas> MEDIDAS { get; init; }
        DbSet<Administrador> ADMINISTRADOR { get; init; }
        DbSet<Producto> PRODUCTO { get; init; }
        DbSet<Receta> RECETA { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}