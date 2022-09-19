using GanpatiBappa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GanpatiBappa.Repository
{
    public class DonationRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Donation details
        public bool AddDonation(DonationModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_AddDonation", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@donaterName", obj.donaterName);
            com.Parameters.AddWithValue("@donateAmount", obj.donateAmount);
            com.Parameters.AddWithValue("@donationDate", obj.donationDate);
            com.Parameters.AddWithValue("@donationRecievedBy", obj.donationRecievedBy);
            com.Parameters.AddWithValue("@donationYear", obj.donationYear);
            com.Parameters.AddWithValue("@PaymentBy", obj.PaymentBy);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        //To view Donation details with generic list 
        public List<DonationModel> GetAllDonationList()
        {
            connection();
            List<DonationModel> DonationList = new List<DonationModel>();
            SqlCommand com = new SqlCommand("sp_getDonationDate", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            DonationList = (from DataRow dr in dt.Rows

                            select new DonationModel()
                            {
                                d_Id = Convert.ToInt32(dr["d_Id"]),
                                donaterName = Convert.ToString(dr["donaterName"]),
                                donateAmount = Convert.ToInt32(dr["donateAmount"]),
                                donationDate = Convert.ToDateTime(dr["donationDate"]),
                                donationRecievedBy = Convert.ToString(dr["donationRecievedBy"]),
                                donationYear = Convert.ToString(dr["donationYear"]),
                                PaymentBy = Convert.ToString(dr["paymentBy"])
                            }).ToList();


            return DonationList;


        }

        //To Update Donation details
        public bool UpdateEmployee(DonationModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_UpdateDonationData", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@d_Id", obj.d_Id);
            com.Parameters.AddWithValue("@donaterName", obj.donaterName);
            com.Parameters.AddWithValue("@donateAmount", obj.donateAmount);
            com.Parameters.AddWithValue("@donationDate", obj.donationDate);
            com.Parameters.AddWithValue("@donationRecievedBy", obj.donationRecievedBy);
            com.Parameters.AddWithValue("@donationYear", obj.donationYear);
            com.Parameters.AddWithValue("@paymentBy", obj.PaymentBy);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
    }
}