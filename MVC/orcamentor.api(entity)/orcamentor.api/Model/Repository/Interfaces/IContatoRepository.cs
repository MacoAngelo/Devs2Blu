namespace orcamentor.api.Model.Repository.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<Contato>> Listar();
        Task<Contato> BuscarPorId(int id);

        Task Salvar(Contato contato);
    }

    public interface ICarroRepository
    {
        List<Carro> Listar();
        Task<Carro> BuscarPorId(int id);

        Task Salvar(Carro contato);
    }
}
