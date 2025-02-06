using MinhaPrimeiraAplicacao.Utils.Entidades;
using System.Numerics;

namespace MinhaPrimeiraAplicacaoWeb.Models.Marcas
{
    public class MarcaModel
    {
        public long ID { get; set; }
        public string Nome { get; set; }

		public MarcaModel()
		{

		}

		public MarcaModel(Marca marca)
		{
			ID = marca.ID;
			Nome = marca.Nome;
		}

		public Marca GetEntidade()
		{
			return new Marca()
			{
				ID = ID,
				Nome = Nome,
			};
		}
	}
}
