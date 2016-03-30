using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Minesweeper
{
    public class Log
    {
        private int _currentLogId;
        private string _user;
        //public string UserNameType { get; set; }

        public Log()
        {
            SetLogId();
            SetUser();  

        }


        public void SetLogId()
        {
            const string minesweeperDBString =
                @"server = .\SQLEXPRESS; database = minesweeperDB; integrated security = SSPI";
            // get max logId and increment
            string queryString =
                "select MAX(log_id)from logs_reads_and_writes";

            using (SqlConnection connection = new SqlConnection(minesweeperDBString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    DataTable dataTable = new DataTable();
                    
                    using (SqlDataAdapter a = new SqlDataAdapter(command))
                    {
                        a.Fill(dataTable);
                    }
                    DataRow dataRow = dataTable.Rows[0];
                    _currentLogId = (int)dataRow[0];
                }

            }
        }


        private void SetUser()
        {
            _user = System.Environment.UserName;
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
            string queryString =
                "INSERT INTO logs_reads_and_writes (log_id, UTC_timestamp, user_name, content, message_type_id) VALUES (3, CURRENT_TIMESTAMP, 'jean michel', @message, @type);";

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
