using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.CommonTypes.Sql
{
    public static class SqlDapper
    {
        /// <summary>
        /// Connection string
        /// </summary>
        private static string _connString = string.Empty;
        
        /// <summary>
        /// Timeout for command
        /// </summary>
        private static int _commandTimeout = 100;

        public static void InitDapper(string connString, string commandTimeout)
        {
            if (connString is null)
                throw new ArgumentNullException("Check appsettings, there is no connection string!");

            _connString = connString;

            if (int.TryParse(commandTimeout, out var timeout))
                _commandTimeout = timeout;
        }

        public static IEnumerable<T> ExecuteQuerySP<T>(string sp, DynamicParameters? param = null)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                return conn.Query<T>(
                    sql: sp,
                    param: param, 
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: _commandTimeout);
            }
        }

        public static void ExecuteNonQuerySP<T>(string sp, DynamicParameters? param = null)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                conn.Query<T>(
                    sql: sp,
                    param: param,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: _commandTimeout);
            }
        }
    }
}
