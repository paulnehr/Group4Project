using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4Project_ClassLibrary
{
    public class ItemCategory
    {
        public static DataSet GetCategories()
        {
            SqlConnection connection = DataServices.SetDatabaseConnection();
            
            SqlCommand command = new SqlCommand("procGetCategories", connection);
            command.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            connection.Close();

            return dataset;
        }
    }
}
