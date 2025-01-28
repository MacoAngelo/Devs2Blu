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
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

        public static Carro Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT ID, NOME, ANO, PLACA FROM CARROS WHERE ID = {id}";
                var cmd = new MySqlCommand(query, conn);

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
    }
}
