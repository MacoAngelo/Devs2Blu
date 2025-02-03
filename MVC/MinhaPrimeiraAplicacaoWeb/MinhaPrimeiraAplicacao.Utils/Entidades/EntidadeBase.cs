using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaPrimeiraAplicacao.Utils.Database;
using MySql.Data.MySqlClient;

namespace MinhaPrimeiraAplicacao.Utils.Entidades
{
    public abstract class EntidadeBase
    {
        public long ID { get; set; }
        protected abstract string TableName { get; }


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