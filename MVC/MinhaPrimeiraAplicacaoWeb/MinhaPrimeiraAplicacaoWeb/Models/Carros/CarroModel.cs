using MinhaPrimeiraAplicacao.Utils.Entidades;

namespace MinhaPrimeiraAplicacaoWeb.Models.Carros
{
    public class CarroModel
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public int Ano {  get; set; }

        public CarroModel()
        {
            
        }

        public CarroModel(Carro carro)
        {
            ID = carro.ID;
            Nome = carro.Nome;
            Placa = carro.Placa;
            Ano = carro.Ano;
        }

        public Carro GetEntidade()
        {
            return new Carro()
            {
                ID = ID,
                Nome = Nome,
                Placa = Placa,
                Ano = Ano
            };
        }
    }
}