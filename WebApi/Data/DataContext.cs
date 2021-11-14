using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using System.Threading.Tasks;


namespace WebApi.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
             
        }
 
        public DbSet<Student> Students { get; init; }
        public DbSet<Nutricionista> NUTRICIONISTA { get; init; }
        public DbSet<Cliente> CLIENTE { get; init; }
        public DbSet<Plan> PLAN_ { get; init; }
        public DbSet<Medidas> MEDIDAS { get; init; }
    }
}
