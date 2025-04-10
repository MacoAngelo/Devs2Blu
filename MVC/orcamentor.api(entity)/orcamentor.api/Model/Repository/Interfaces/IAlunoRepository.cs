namespace orcamentor.api.Model.Repository.Interfaces
{
    public interface IAlunoRepository
    {
        List<Aluno> Listar();

        Aluno Listar(Guid id);

        void Salvar(Aluno aluno);
    }
}
