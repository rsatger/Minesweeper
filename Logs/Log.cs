using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.WebSockets;

namespace Minesweeper.Logs
{
    public class Log
    {
        private readonly int _logId;

        public Log()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mineDb"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(SqlQuries.GetMaxLogId, connection))
                {
                    var dataTable = new DataTable();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    var dataRow = dataTable.Rows[0];

                    _logId = dataRow.IsNull(0) ? 0 : (int)dataRow[0] + 1;
                }
                connection.Close();
            }
        }

        public void WriteInLog(string logContent, int type)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mineDb"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(SqlQuries.InsertLog, connection))
                {
                    command.Parameters.AddWithValue("@logId", _logId);
                    command.Parameters.AddWithValue("@user", Environment.UserName);
                    command.Parameters.AddWithValue("@message", logContent);
                    command.Parameters.AddWithValue("@type", type);

                    command.ExecuteNonQuery();
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public IEnumerable<LogRecord> GetAllLogs()
        {
            var logRecords = new List<LogRecord>();
            
            return logRecords;
        }
    }
}