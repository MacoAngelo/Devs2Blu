namespace orcamentor.api.Model.Repository.Interfaces
{
    public interface IProfessorRepository
    {
        List<Professor> Listar();

        Professor Listar(Guid id);

        void Salvar(Professor aluno);
    }
}