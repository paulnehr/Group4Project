using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4Project_ClassLibrary
{
    public class ItemListing
    {
            public static Boolean ListItem (out int itemNum, string itemName, string itemDescription,
                int itemPrice, string itemPhoto, int categoryNum, int userID, out string errorMessage)
            {
                SqlConnection connection = DataServices.SetDatabaseConnection();

                SqlCommand command = new SqlCommand("procListItem", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@itemNum", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@itemName", SqlDbType.VarChar, 8);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = itemName;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@itemDescription", SqlDbType.VarChar, 8);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = itemDescription;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@itemPrice", SqlDbType.Money);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = itemPrice;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@itemPhoto", SqlDbType.VarChar, 8);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = itemPhoto;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@categoryNum", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = categoryNum;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@userID", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = userID;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@errorMessage", SqlDbType.VarChar, 100);
                parameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@listingSuccess", SqlDbType.Bit);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();

                bool listingSuccess = Convert.ToBoolean(command.Parameters["@listingSuccess"].Value);
                errorMessage = Convert.ToString(command.Parameters["@errorMessage"].Value); 

                if (listingSuccess)
                {

                    itemNum = Convert.ToInt32(command.Parameters["@itemNum"].Value);
                }
                else
                {
                    itemNum = 0;
                }               

                return listingSuccess;
            }

            public static DataSet GetAllItemsForCategory(int categoryNum)
            {
                SqlConnection connection = DataServices.SetDatabaseConnection();

                SqlCommand command = new SqlCommand("procGetAllItemsForCategory", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@categoryNum", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = categoryNum;
                command.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                connection.Close();

                return dataset;
            }

            public static DataSet GetItemListingDetail(int itemNum)
            {
                SqlConnection connection = DataServices.SetDatabaseConnection();

                SqlCommand command = new SqlCommand("procGetItemListingDetail", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@itemNum", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = itemNum;
                command.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                connection.Close();

                return dataset;
            }

            public static DataSet GetAllItemsForUser(int userID)
            {
                SqlConnection connection = DataServices.SetDatabaseConnection();

                SqlCommand command = new SqlCommand("procGetAllItemsForUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@userID", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = userID;
                command.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                connection.Close();

                return dataset;
            }

            public static bool RemoveItemListing(int itemNum)
            {
                SqlConnection connection = DataServices.SetDatabaseConnection();

                SqlCommand command = new SqlCommand("procRemoveItemListing", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@itemNum", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = itemNum;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@removeSuccess", SqlDbType.Bit);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();

                bool removeSuccess = Convert.ToBoolean(command.Parameters["@removeSuccess"].Value);

                connection.Close();

                return removeSuccess;

            }
    }
}

