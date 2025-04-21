using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace pracLogin.Models
{
    public class ResetAccount
    {
        public bool VerifyUser2(string txtUsername, string newPassword)
        {
            bool status = false;
            string connString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                string query = "UPDATE OSTMember SET Password = @NewPassword WHERE name = @UserName";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.Text;

                // Add parameters to avoid SQL injection
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                cmd.Parameters.AddWithValue("@UserName", txtUsername);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true; // Password successfully updated
                }

                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
            }

            return status;
        }
    }
}