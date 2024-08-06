using Boilerplate.Infrastructure.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Boilerplate.Infrastructure.Helpers
{
    public class SqlQueryHelper : ISqlQueryHelper
    {
        private readonly string connString;

        public SqlQueryHelper(string _connString)
        {
            connString = _connString;
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var cmd = new SqlCommand(commandText, con)
                {
                    CommandType = commandType,
                };

                con.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, List<SqlParameter> parameters)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var cmd = new SqlCommand(commandText, con)
                {
                    CommandType = commandType,
                };

                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                con.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
        }

        public List<T> ExecuteReader<T>(string commandText, CommandType commandType, List<SqlParameter> parameters)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var cmd = new SqlCommand(commandText, con)
                {
                    CommandType = commandType,
                };

                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                con.Open();
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                var data = new List<T>();

                if (dt.Rows.Count > 0)
                {
                    var serializedMyObjects = JsonConvert.SerializeObject(dt);
                    data = (List<T>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<T>));
                }

                con.Close();
                return data;
            }
        }
    }
}
