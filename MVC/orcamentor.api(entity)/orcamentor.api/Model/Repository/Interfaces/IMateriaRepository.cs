namespace orcamentor.api.Model.Repository.Interfaces
{
    public interface IMateriaRepository
    {
        List<Materia> Listar();

        Materia Listar(Guid id);

        void Salvar(Materia aluno);
    }
}