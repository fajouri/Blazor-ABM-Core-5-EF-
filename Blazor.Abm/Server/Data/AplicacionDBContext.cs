using Blazor.Abm.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Abm.Server.Data
{
    public class AplicacionDbContext:DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
        {
        }
        public DbSet<Programador> Programadores { get; set; }
    }
}
