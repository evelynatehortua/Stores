using Microsoft.EntityFrameworkCore;
using Stores.Shared.Entities;

namespace Stores.API.Data
{
    // Donde nos vamos a conectar con la base de datos
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
