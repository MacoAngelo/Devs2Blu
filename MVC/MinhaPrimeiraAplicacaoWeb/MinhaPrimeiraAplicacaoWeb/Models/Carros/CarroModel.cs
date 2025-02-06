using MinhaPrimeiraAplicacao.Utils.Entidades;
using MinhaPrimeiraAplicacaoWeb.Models.Marcas;

namespace MinhaPrimeiraAplicacaoWeb.Models.Carros
{
    public class CarroModel
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public int Ano {  get; set; }
        public Carro.CategoriaVeiculo Categoria {  get; set; }
        public MarcaModel Marca {  get; set; }

        public List<MarcaModel> MarcasDisponíveis { get; set; }

        public CarroModel()
        {
            
        }

        public CarroModel(Carro carro)
        {
            ID = carro.ID;
            Nome = carro.Nome;
            Placa = carro.Placa;
            Ano = carro.Ano;
            Marca = new MarcaModel(carro.Marca);
            Categoria = carro.Categoria;
        }

        public Carro GetEntidade()
        {
            return new Carro()
            {
                ID = ID,
                Nome = Nome,
                Placa = Placa,
                Ano = Ano,
                Marca = Marca.GetEntidade(),
                Categoria = Categoria
            };
        }
    }
}