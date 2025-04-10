using orcamentor.api.Infra.Data;
using orcamentor.api.Model.Repository.Interfaces;

namespace orcamentor.api.Model.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppTechStudentsDbContext _context;

        public AlunoRepository(AppTechStudentsDbContext context)
        {
            _context = context;
        }

        public List<Aluno> Listar()
        {
            return _context.Alunos.ToList();
        }

        public Aluno Listar(Guid id)
        {
            return _context.Alunos.Find(id);
        }

        public void Salvar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges(); // COMMIT
        }
    }
}
