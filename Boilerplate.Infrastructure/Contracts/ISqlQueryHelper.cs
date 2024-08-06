using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Boilerplate.Infrastructure.Contracts
{
    public interface ISqlQueryHelper
    {
        int ExecuteNonQuery(string commandText, CommandType commandType, List<SqlParameter> parameters);

        int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text);

        List<T> ExecuteReader<T>(string commandText, CommandType commandType, List<SqlParameter> parameters);
    }
}
