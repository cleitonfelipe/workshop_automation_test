using LocadoraDeAutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutos.Data
{
    public class LocadoraDeAutosContext : DbContext
    {
        public LocadoraDeAutosContext(DbContextOptions<LocadoraDeAutosContext> options)
            : base(options)
        {
        }

        public DbSet<CarroViewModel> Carro { get; set; }
    }
}