using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Group4Project_ClassLibrary
{
    public class DataServices
    {
        public static SqlConnection SetDatabaseConnection()
        {
            string connectionString =
                    @"Data Source=PAUL\PAULSSQLSERVER;Initial Catalog=Group4Project;Integrated Security=True";

           /* connectionString="Data Source=BNE141-Podium\SQLServer;Initial Catalog=MIST452Group4Development; username = sa; password = BELab1234";*/
                        
           

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}