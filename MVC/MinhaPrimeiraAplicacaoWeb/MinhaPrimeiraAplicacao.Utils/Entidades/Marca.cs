using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MinhaPrimeiraAplicacao.Utils.Entidades
{
    public class Marca : EntidadeBase1<Marca>
    {
        protected override string TableName => "MARCAS";

        protected override List<string> Fields => new List<string>() { "Nome"};

        public string Nome { get; set; }

        protected override Marca Fill(MySqlDataReader reader)
        {
            var aux = new Marca();

            aux.Nome = reader.GetString("NOME");

            return aux;
        }

        protected override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("@pNome", Nome));
        }
    }
}
