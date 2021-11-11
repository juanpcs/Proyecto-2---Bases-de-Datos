using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

// Represents a session with the database and can be used to query and save instances of your entities.

namespace WebApi.Data
{
    public interface IDataContext
    {
        DbSet<Student> Students { get; init; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}