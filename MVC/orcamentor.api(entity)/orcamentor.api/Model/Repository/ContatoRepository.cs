using Microsoft.EntityFrameworkCore;
using orcamentor.api.Infra.Data;
using orcamentor.api.Model.Repository.Interfaces;

namespace orcamentor.api.Model.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ContatoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }   

        public async Task<List<Contato>> Listar()
        {
            return await _appDbContext.Contatos.ToListAsync();
        }

        public async Task<Contato?> BuscarPorId(int id)
        {
            return await _appDbContext.Contatos.FindAsync();
        }

        public async Task Salvar(Contato contato)
        {
            _appDbContext.Contatos.Add(contato);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public class CarroRepository : ICarroRepository
    {
        private readonly AppCarruxDbContext _appCarruxDbContext;

        public CarroRepository(AppCarruxDbContext appDbContext)
        {
            _appCarruxDbContext = appDbContext;
        }

        public List<Carro> Listar()
        {
            return _appCarruxDbContext.Carros.ToList();
        }

        public async Task<Carro?> BuscarPorId(int id)
        {
            return await _appCarruxDbContext.Carros.FindAsync();
        }

        public async Task Salvar(Carro contato)
        {
            _appCarruxDbContext.Carros.Add(contato);
            await _appCarruxDbContext.SaveChangesAsync();
        }
    }
}
