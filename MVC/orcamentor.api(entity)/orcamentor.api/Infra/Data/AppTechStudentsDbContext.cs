using Microsoft.EntityFrameworkCore;
using orcamentor.api.Model;

namespace orcamentor.api.Infra.Data
{
    public class AppTechStudentsDbContext : DbContext
    {
        public AppTechStudentsDbContext(DbContextOptions<AppTechStudentsDbContext> options) : base(options)
        {   }

        // Tabelas do banco
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Materia> Materias { get; set; }
    }
}
