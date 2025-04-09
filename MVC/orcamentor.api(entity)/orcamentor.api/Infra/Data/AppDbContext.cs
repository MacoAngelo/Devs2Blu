using Microsoft.EntityFrameworkCore;
using orcamentor.api.Model;

namespace orcamentor.api.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Contato> Contatos { get; set; }
    }

    public class AppCarruxDbContext : DbContext
    {
        public AppCarruxDbContext(DbContextOptions<AppCarruxDbContext> options) : base(options) { }

        public DbSet<Carro> Carros { get; set; }
    }
}
