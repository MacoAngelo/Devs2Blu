using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaPrimeiraAplicacao.Utils.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace MinhaPrimeiraAplicacao.Utils.Entidades
{
    public class Carro
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

        public static Carro Get(long id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT ID, NOME, ANO, PLACA FROM CARROS WHERE ID = @ID";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Carro
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Ano = reader.GetInt32("ANO"),
                        Placa = reader.GetString("PLACA")
                    };
                }
            }

            return null;
        }

        public static List<Carro> GetAll()
        {
            var result = new List<Carro>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT ID, NOME, ANO, PLACA FROM CARROS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Carro()
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Ano = reader.GetInt32("ANO"),
                        Placa = reader.GetString("PLACA")
                    });
                }
            }

            return result;
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

        public void Update()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"UPDATE CARROS SET NOME = @pNOME, PLACA = @pPLACA, ANO = @pANO
                                    WHERE ID = @pID";

                cmd.Parameters.Add(new MySqlParameter("pID", ID));
                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pANO", Ano));
                cmd.Parameters.Add(new MySqlParameter("pPLACA", Placa));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pID", ID));
                cmd.CommandText = @$"DELETE FROM CARROS WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
