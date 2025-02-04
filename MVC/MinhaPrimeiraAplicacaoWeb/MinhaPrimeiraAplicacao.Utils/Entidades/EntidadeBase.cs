using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MinhaPrimeiraAplicacao.Utils.Database;
using MySql.Data.MySqlClient;

namespace MinhaPrimeiraAplicacao.Utils.Entidades
{
    public abstract class EntidadeBase1<T>
    {
        public long ID { get; set; }
        protected abstract string TableName { get; }
        protected abstract List<string> Fields { get; }

        protected abstract T Fill(MySqlDataReader reader);
        protected abstract void FillParameters(MySqlParameterCollection parameters);

        public T Get(long id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT {string.Join(", ", Fields)} FROM {TableName} WHERE ID = @ID";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Fill(reader);
                }
            }

            return default(T);
        }

        public List<T> GetAll()
        {
            var result = new List<T>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT {string.Join(", ", Fields)} FROM CARROS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(Fill(reader));
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
                cmd.CommandText = @$"INSERT INTO {TableName} ({string.Join(", ", Fields)}) 
                                        VALUES ({string.Join(", ", Fields.Select(campo => $"@p{campo}"))})";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"UPDATE {TableName} SET {string.Join(", ", Fields.Select(campo => $"{campo} = @p{campo}"))}
                                   WHERE ID = @pID";

                cmd.Parameters.Add(new MySqlParameter("pID", ID));
                FillParameters(cmd.Parameters);

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
                cmd.CommandText = @$"DELETE FROM {TableName} WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
    }

    public abstract class EntidadeBase
    {
        public long ID { get; set; }
        protected abstract string TableName { get; }
        protected abstract List<string> Fields { get; }

        protected abstract EntidadeBase Fill(MySqlDataReader reader);

        protected EntidadeBase BaseGet(long id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT {string.Join(", ", Fields)} FROM {TableName} WHERE ID = @ID";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Fill(reader);
                }
            }

            return null;
        }

        protected List<EntidadeBase> BaseGetAll()
        {
            var result = new List<EntidadeBase>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT {string.Join(", ", Fields)} FROM CARROS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(Fill(reader));
                }
            }

            return result;
        }

        public void Delete()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pID", ID));
                cmd.CommandText = @$"DELETE FROM {TableName} WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
    }
}