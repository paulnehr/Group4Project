using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4Project_ClassLibrary
{
    public class Transaction
    {

        public static Boolean CreateTransaction(out int transactionNum, int transactionPrice, 
            string transactionType, int userId, string transactionStatus, int itemNum, 
            DateTime transactionDateTime, out string errorMessage)
        {
            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procCreateTransaction", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@transactionPrice", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionPrice;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionType", SqlDbType.VarChar, 20);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionType;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionDateTime", SqlDbType.DateTime);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionDateTime;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionStatus", SqlDbType.VarChar, 20);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionStatus;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@userId", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = userId;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@itemNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = itemNum;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionSuccess", SqlDbType.Bit);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@errorMessage", SqlDbType.VarChar, 100);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            bool transactionSuccess = Convert.ToBoolean(command.Parameters["@transactionSuccess"].Value);
            errorMessage = Convert.ToString(command.Parameters["@errorMessage"].Value);

            if (transactionSuccess)
            {

                transactionNum = Convert.ToInt32(command.Parameters["@transactionNum"].Value);
                
            }
            else
            {
                transactionNum = 0;
            }
            

            return transactionSuccess;

        }

        public static DataSet GetTransactionHistory(int userID)
        {

            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procGetTransactionHistory", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@userId", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = userID;
            command.Parameters.Add(parameter);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            connection.Close();
            return dataset;

        }

        public static DataSet GetTransactionDetail(int transactionNum)
        {

            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procGetTransactionDetail", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@transactionNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionNum;
            command.Parameters.Add(parameter);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            connection.Close();
            return dataset;

        }

        public static Boolean UpdateTransactionRating(int transactionRating, int transactionNum, 
            out string errorMessage)
        {

            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procUpdateTransactionRating", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@transactionRating", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionRating;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionNum;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@errorMessage", SqlDbType.VarChar, 100);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@updateSuccess", SqlDbType.Bit);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            errorMessage = Convert.ToString(command.Parameters["@errorMessage"].Value);
            bool updateSuccess = Convert.ToBoolean(command.Parameters["@updateSuccess"].Value);

            connection.Close();

            return updateSuccess;
        }

        public static bool DeleteTransaction(int transactionNum)
        {
            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procDeleteTransaction", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@transactionNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionNum;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@deleteSuccess", SqlDbType.Bit);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();

            bool deleteSuccess = Convert.ToBoolean(command.Parameters["@deleteSuccess"].Value);

            connection.Close();

            return deleteSuccess;
        }

        public static Boolean MakeTrade(out int transactionNum, DateTime transactionDateTime, int transactionPrice, string transactionType, string transactionStatus, int itemNum, int accepterUserID, int offerTransactionNum, out string errorMessage)
        {
            SqlConnection connection = DataServices.SetDatabaseConnection();

            SqlCommand command = new SqlCommand("procAcceptTrade", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@transactionNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionDateTime", SqlDbType.DateTime);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionDateTime;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionPrice", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionPrice;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionType", SqlDbType.VarChar, 20);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionType;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@transactionStatus", SqlDbType.VarChar, 20);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = transactionStatus;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@itemNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = itemNum;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@accepterUserID", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = accepterUserID;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@offerTransactionNum", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = offerTransactionNum;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@errorMessage", SqlDbType.VarChar, 100);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@makeTradeSuccess", SqlDbType.Bit);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            bool makeTradeSuccess = Convert.ToBoolean(command.Parameters["@makeTradeSuccess"].Value);
            errorMessage = Convert.ToString(command.Parameters["@errorMessage"].Value);

            if (makeTradeSuccess)
            {

                transactionNum = Convert.ToInt32(command.Parameters["@transactionNum"].Value);

            }
            else
            {
                transactionNum = 0;
            }


            return makeTradeSuccess;

        }

    }
}
