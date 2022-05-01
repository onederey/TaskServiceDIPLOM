using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

        public static ICollection<T> ExecuteQuerySP<T>(string sp, DynamicParameters? param = null)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                return conn.Query<T>(
                    sql: sp,
                    param: param, 
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: _commandTimeout).ToList();
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

        public static void ExecuteSqlNonQuery(string sql, DynamicParameters? param = null)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                conn.Execute(
                    sql: sql,
                    param: param,
                    commandType: CommandType.Text,
                    commandTimeout: _commandTimeout);
            }
        }

        public static void ClearTable(string tableName) => ExecuteSqlNonQuery($"DELETE FROM {tableName}");
        

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            dataTable.TableName = typeof(T).FullName;
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static List<SqlBulkCopyColumnMapping> PrepareColumnMapping(DataTable table)
        {
            if (table is null)
                throw new ArgumentNullException(nameof(table));

            var columnMap = new List<SqlBulkCopyColumnMapping>();

            foreach (DataColumn column in table.Columns)
                columnMap.Add(new SqlBulkCopyColumnMapping(column.ColumnName, column.ColumnName));

            return columnMap;
        }

        public static void BulkInsertIntoTable(DataTable data, string tableName, List<SqlBulkCopyColumnMapping> map)
        {
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();

                using (var bulk = new SqlBulkCopy(conn))
                {
                    try
                    {
                        bulk.DestinationTableName = tableName;
                        map.ForEach(x => bulk.ColumnMappings.Add(x));
                        bulk.WriteToServer(data);
                    }
                    catch(Exception ex) 
                    {
                        throw new DataException($"Error on BulkInsert to table - {tableName}");
                    }
                }
            }
        }
    }
}
