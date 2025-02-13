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
    /*
     INSERT INTO MARCAS (NOME) VALUES 
('Toyota'),
('Ford'),
('Honda'),
('Chevrolet'),
('Volkswagen');


INSERT INTO CARROS (NOME, ANO, PLACA, CATEGORIA, MARCA) VALUES
('Corolla', 2020, 'ABC1234', 10, 1), 
('Civic', 2021, 'DEF5678', 20, 3),
('Fusca', 1985, 'GHI9012', 30, 5),
('Cruze', 2019, 'JKL3456', 20, 4),
('Gol', 2022, 'MNO7890', 10, 5),
('Hilux', 2021, 'PQR1234', 40, 1),
('Fiesta', 2020, 'STU5678', 10, 2),
('HR-V', 2023, 'VWX9012', 40, 3),
('Tracker', 2022, 'YZA3456', 40, 4),
('Polo', 2021, 'BCD7890', 10, 5),
('Yaris', 2022, 'EFG1234', 10, 1),
('Onix', 2020, 'HIJ5678', 20, 4),
('S10', 2022, 'QRS7890', 40, 4),
('Civic', 2020, 'TUV1234', 20, 3)
     */

    public class Carro : EntidadeBase1<Carro>
    {
        public enum CategoriaVeiculo
        {
            Hatch = 10,
            Sedan = 20,
            Coupe = 30,
            SUV = 40
        }

        protected override string TableName => "CARROS";
        protected override List<string> Fields => new List<string>()
        {
            "NOME",
            "ANO",
            "PLACA",
            "CATEGORIA",
            "MARCA"
        };

        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public Marca Marca { get; set; }
        public CategoriaVeiculo Categoria { get; set; }

        protected override Carro Fill(MySqlDataReader reader)
        {
            var aux = new Carro();

            aux.ID = reader.GetInt32("ID");
            aux.Nome = reader.GetString("NOME");
            aux.Ano = reader.GetInt32("ANO");
            aux.Placa = reader.GetString("PLACA");
            aux.Categoria = (CategoriaVeiculo)reader.GetInt32("CATEGORIA");
            aux.Marca = new Marca().Get(reader.GetInt64("MARCA"));

            return aux;
        }

        protected override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pNOME", Nome));
            parameters.Add(new MySqlParameter("pANO", Ano));
            parameters.Add(new MySqlParameter("pPLACA", Placa));
            parameters.Add(new MySqlParameter("pCATEGORIA", Categoria.GetHashCode()));
            parameters.Add(new MySqlParameter("pMARCA", Marca.ID));
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
