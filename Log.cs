using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Minesweeper
{
    public class Log
    {
        private int _currentLogId;
        private string user;
        public string UserNameType { get; set; }

        public Log()
        {
            SetLogId();
    
        }

        public void SetLogId()
        {
            // get max logId and increment

        }

        public void WriteInLog(string content, int type)
        {
            const string minesweeperDBString =
                @"server = .\SQLEXPRESS; database = minesweeperDB; integrated security = SSPI";
            const string logContent = "this is a log testing";
            WriteLog(minesweeperDBString, logContent, 1);
        }

        public static void WriteLog(string connectionString, string logContent, int type)
        {
            //string queryString =
            //  "select MAX(log_id)from logs_reads_and_writes";

            string queryString =
                "INSERT INTO logs_reads_and_writes (log_id, UTC_timestamp, user_name, content, message_type_id) VALUES (3, CURRENT_TIMESTAMP, 'bernard', @message, @type);";

            //DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@message", logContent);
                    command.Parameters.AddWithValue("@type", type);

                    command.ExecuteNonQuery();

                    //using (SqlDataAdapter a = new SqlDataAdapter(command))
                    //{
                    //    a.Fill(dataTable);
                    //}
                }
            }
            //return broot
        }


    }
}
