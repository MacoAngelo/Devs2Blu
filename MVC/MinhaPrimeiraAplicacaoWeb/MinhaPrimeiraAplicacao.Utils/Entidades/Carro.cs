using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaPrimeiraAplicacao.Utils.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Crypto.Generators;

namespace MinhaPrimeiraAplicacao.Utils.Entidades
{
    public class Carro : EntidadeBase1<Carro>
    {
        protected override string TableName => "CARROS";
        protected override List<string> Fields => new List<string>()
        {
            "ID",
            "NOME",
            "ANO",
            "PLACA"
        };

        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

        protected override Carro Fill(MySqlDataReader reader)
        {
            var aux = new Carro();

            aux.ID = reader.GetInt32("ID");
            aux.Nome = reader.GetString("NOME");
            aux.Ano = reader.GetInt32("ANO");
            aux.Placa = reader.GetString("PLACA");

            return aux;
        }

        public void Create()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO CARROS (NOME, ANO, PLACA) 
                                        VALUES (@pNOME, @pANO, @pPLACA)";

                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pANO", Ano));
                cmd.Parameters.Add(new MySqlParameter("pPLACA", Placa));

                cmd.ExecuteNonQuery();
            }
        }

        protected override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pNOME", Nome));
            parameters.Add(new MySqlParameter("pANO", Ano));
            parameters.Add(new MySqlParameter("pPLACA", Placa));
        }
    }

    //public class Carro : EntidadeBase
    //{
    //    protected override string TableName => "CARROS";
    //    protected override List<string> Fields => new List<string>()
    //    {
    //        "ID",
    //        "NOME",
    //        "ANO",
    //        "PLACA"
    //    };

    //    public string Nome { get; set; }
    //    public int Ano { get; set; }
    //    public string Placa { get; set; }


    //    public Carro Get(long id)
    //    {
    //        return BaseGet(id) as Carro;
    //    }

    //    public List<Carro> GetAll()
    //    {
    //        return BaseGetAll().Select(entidade => entidade as Carro).ToList();
    //    }

    //    public void Create()
    //    {
    //        using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
    //        {
    //            conn.Open();

    //            var cmd = conn.CreateCommand();
    //            cmd.CommandText = @"INSERT INTO CARROS (NOME, ANO, PLACA) 
    //                                VALUES (@pNOME, @pANO, @pPLACA)";

    //            cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
    //            cmd.Parameters.Add(new MySqlParameter("pANO", Ano));
    //            cmd.Parameters.Add(new MySqlParameter("pPLACA", Placa));

    //            cmd.ExecuteNonQuery();
    //        }
    //    }

    //    public void Update()
    //    {
    //        using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
    //        {
    //            conn.Open();

    //            var cmd = conn.CreateCommand();
    //            cmd.CommandText = @$"UPDATE CARROS SET NOME = @pNOME, PLACA = @pPLACA, ANO = @pANO
    //                                WHERE ID = @pID";

    //            cmd.Parameters.Add(new MySqlParameter("pID", ID));
    //            cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
    //            cmd.Parameters.Add(new MySqlParameter("pANO", Ano));
    //            cmd.Parameters.Add(new MySqlParameter("pPLACA", Placa));

    //            cmd.ExecuteNonQuery();
    //        }
    //    }

    //    protected override EntidadeBase Fill(MySqlDataReader reader)
    //    {
    //        var aux = new Carro();

    //        aux.ID = reader.GetInt32("ID");
    //        aux.Nome = reader.GetString("NOME");
    //        aux.Ano = reader.GetInt32("ANO");
    //        aux.Placa = reader.GetString("PLACA");

    //        return aux;
    //    }
    //}
}
