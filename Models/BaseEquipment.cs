using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Reflection;
using System.Web.UI;
using System.Xml.Linq;

namespace pracLogin.Models
{
    public class BaseEquipment
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string ProductDescription { get; set; }
        public string ImgUrl { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public decimal EquipmentPrice { get; set; }
        public BaseEquipment GetEquipmentById(int equipmentId)
        {
            BaseEquipment equipment = new BaseEquipment();
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);

            try
            {
                
                sqlConnection.Open();
                string Query = "spOST_LstEquipment";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 0;

                //cmd.ExecuteNonQuery();//insert delete update 
                

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    { if(equipmentId == Convert.ToInt32(reader["EquipmentId"].ToString())) { 
                        equipment.EquipmentId = Convert.ToInt32(reader["EquipmentId"].ToString());
                        equipment.EquipmentName = reader["EquipmentName"].ToString();
                        equipment.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                        equipment.Stock = Convert.ToInt32(reader["Stock"].ToString());
                        equipment.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                        equipment.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                        equipment.EquipmentPrice = Convert.ToDecimal(reader["EquipmentPrice"].ToString());
                        equipment.ProductDescription = reader["ProductDescription"].ToString();
                        equipment.ImgUrl = reader["ImgUrl"].ToString();
                        break;
                        }
                    }
                }

                reader.Close();
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
            return equipment;
        }
        public List<BaseEquipment> LstEquipment()
        {
            List<BaseEquipment> lstEquips = new List<BaseEquipment>();

            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);

            try
            {
                sqlConnection.Open();
                string Query = "spOST_LstEquipment";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 0;

                //cmd.ExecuteNonQuery();//insert delete update 
                SqlDataReader reader = cmd.ExecuteReader(); //fetch mode list data 
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BaseEquipment baseEquipment = new BaseEquipment();
                        baseEquipment.EquipmentId = Convert.ToInt32(reader["EquipmentId"].ToString());
                        baseEquipment.EquipmentName = reader["EquipmentName"].ToString();
                        baseEquipment.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                        baseEquipment.Stock = Convert.ToInt32(reader["Stock"].ToString());
                        baseEquipment.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                        baseEquipment.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                        baseEquipment.EquipmentPrice = Convert.ToDecimal(reader["EquipmentPrice"].ToString());
                        baseEquipment.ProductDescription = reader["ProductDescription"].ToString();
                        baseEquipment.ImgUrl = reader["ImgUrl"].ToString();
                        lstEquips.Add(baseEquipment);
                        

                    }
                }

                //transaction
                reader.Close();
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
            }
            return lstEquips;
        }

        public static DataTable ListCustomerAssigned()
        {
            DataTable dataTable1 = new DataTable();
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);

            try
            {
                sqlConnection.Open();
                string Query = "spOst_LstCustomerEquiAssignment";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 0;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);    //fetch mode table data  
                adapter.Fill(dataTable1);
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
            }
            return dataTable1;
        }
        public bool SaveEquipment()
        {
            bool status = false;
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);

            try
            {
                sqlConnection.Open();
                string Query = "spOST_InsEquipment";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@Name", this.EquipmentName));
                cmd.Parameters.Add(new SqlParameter("@EcCount", this.Quantity));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", this.EntryDate));
                cmd.Parameters.Add(new SqlParameter("@ReceiveDate", this.ReceiveDate));
                cmd.CommandTimeout = 0;

                int returnvalue = cmd.ExecuteNonQuery();//insert delete update
                if (returnvalue > 0)
                {
                    status = true;
                }

                //transaction
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
            }
            return status;
        }
        public bool UpdateEquipment(string OpType)
        {
            bool status = false;
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);

            try
            {
                sqlConnection.Open();
                string Query = "spOST_UpdEquipment";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                if (OpType == "Update")
                {
                    cmd.Parameters.Add(new SqlParameter("@EquipmentId", this.EquipmentId));
                    cmd.Parameters.Add(new SqlParameter("@Name", this.EquipmentName));
                    cmd.Parameters.Add(new SqlParameter("@EcCount", this.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@EntryDate", this.EntryDate));
                    cmd.Parameters.Add(new SqlParameter("@ReceiveDate", this.ReceiveDate));
                    cmd.Parameters.Add(new SqlParameter("@OpType", OpType));
                }
                if (OpType == "Delete")
                {
                    cmd.Parameters.Add(new SqlParameter("@EquipmentId", this.EquipmentId));
                    cmd.Parameters.Add(new SqlParameter("@OpType", OpType));
                }
                cmd.CommandTimeout = 0;

                int returnvalue = cmd.ExecuteNonQuery();//insert delete update
                if (returnvalue > 0)
                {
                    status = true;
                }

                //transaction
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ArgumentOutOfRangeException(ex.Message, ex);
            }
            return status;
        }
        public bool SaveCustomerEquipmentAssignment(FormCollection formcoll)
        {
            bool status = false;
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);

            try
            {
                sqlConnection.Open();
                string Query = "spOST_InsEquiAssignment";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@CustomerID", Convert.ToInt32(formcoll["ddlCustomer"].ToString())));
                cmd.Parameters.Add(new SqlParameter("@EquipmentID", Convert.ToInt32(formcoll["ddlEquipment"].ToString())));
                cmd.Parameters.Add(new SqlParameter("@EquiCount", Convert.ToInt32(formcoll["txtEquiCount"].ToString())));
                cmd.Parameters.Add(new SqlParameter("@EquiAddress", formcoll["txtAddress"].ToString()));
                cmd.CommandTimeout = 0;

                int returnvalue = cmd.ExecuteNonQuery();//insert delete update
                if (returnvalue>0)
                {
                    status = true;
                }

                //transaction
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
            }
            return status;
        }

        public bool SaveUserToDatabase(FormCollection formcoll)
        {
            bool status = false;
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
           
            try
            {
                sqlConnection.Open();
                string Query = "spOST_InsCustomerMember";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@Name", formcoll["Username"].ToString()));
                //cmd.Parameters.Add(new SqlParameter("@EquiAddress", formcoll["Email"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Mobile", formcoll["Mobile"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Age", Convert.ToInt32(formcoll["Age"].ToString())));
                cmd.Parameters.Add(new SqlParameter("@Address", formcoll["Address"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@ServiceType", formcoll["ServiceType"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Password ", formcoll["Password"].ToString()));
                
                cmd.CommandTimeout = 0;

                int returnvalue = cmd.ExecuteNonQuery();//insert delete update
                if (returnvalue > 0)
                {
                    status = true;
                }

                //transaction
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