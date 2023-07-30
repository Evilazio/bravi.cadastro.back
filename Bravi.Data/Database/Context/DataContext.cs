using Bravi.Data.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bravi.Data.Database.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=sqlite.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoa> Pessoas => Set<Pessoa>();
        public DbSet<Contato> Contatos => Set<Contato>();
        public DbSet<ContatoTipo> ContatoTipos => Set<ContatoTipo>();
    }
}
