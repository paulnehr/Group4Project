using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4Project_ClassLibrary
{
    public class Customer
    {
        public static Boolean RegisterCustomer(out int userID, string userName, string userAddress,
            string userPhone, string userEmail, DateTime dateRegistered, out string errorMessage)
        {
            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procRegisterCustomer", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@userName", SqlDbType.VarChar, 30);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = userName;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@userAddress", SqlDbType.VarChar, 100);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = userAddress;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@userPhone", SqlDbType.VarChar, 20);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = userPhone;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@userEmail", SqlDbType.VarChar, 50);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = userEmail;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@dateRegistered", SqlDbType.Date);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = dateRegistered;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@userID", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@errorMessage", SqlDbType.VarChar, 100);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@registerSuccess", SqlDbType.Bit);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            bool registerSuccess = Convert.ToBoolean(command.Parameters["@registerSuccess"].Value);
            errorMessage = Convert.ToString(command.Parameters["@errorMessage"].Value);


            if (registerSuccess)
            {

                userID = Convert.ToInt32(command.Parameters["@userID"].Value);

            }
            else
            {
                userID = 0;
            }
            
                
            

            return registerSuccess;

        }

        public static bool DeleteAccount(int userID)
        {
            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procDeleteAccount", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@userID", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = userID;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@deleteSuccess", SqlDbType.Bit);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();

            bool deleteSuccess = Convert.ToBoolean(command.Parameters["@deleteSuccess"].Value);

            connection.Close();

            return deleteSuccess;
        }


    }

}
