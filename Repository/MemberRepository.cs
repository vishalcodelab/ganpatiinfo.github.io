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
    public class MemberRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Members details
        public bool AddMember(MemberModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_AddMember", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@memberName", obj.memberName);
            com.Parameters.AddWithValue("@memberMobileNo", obj.memberMobileNo);
            com.Parameters.AddWithValue("@memberCurrentStatus", obj.memberCurrentStatus);
            com.Parameters.AddWithValue("@memberDonation", obj.memberDonation);
            com.Parameters.AddWithValue("@memberDonationDate", obj.memberDonationDate);
            com.Parameters.AddWithValue("@memberPaymentBy", obj.memberPaymentBy);

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

        //To view Members details with generic list 
        public List<MemberModel> GetMemberList()
        {
            connection();
            List<MemberModel> MembersList = new List<MemberModel>();
            SqlCommand com = new SqlCommand("sp_getMemberData", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            MembersList = (from DataRow dr in dt.Rows

                            select new MemberModel()
                            {
                                memberId = Convert.ToInt32(dr["memberId"]),
                                memberName = Convert.ToString(dr["memberName"]),
                                memberMobileNo = Convert.ToString(dr["memberMobileNo"]),
                                memberCurrentStatus = Convert.ToString(dr["memberCurrentStatus"]),
                                memberDonation = Convert.ToInt32(dr["memberDonation"]),
                                memberDonationDate = Convert.ToDateTime(dr["memberDonationDate"]),
                                memberPaymentBy = Convert.ToString(dr["memberPaymentBy"])                                
                            }).ToList();


            return MembersList;


        }

        //To Update Members details
        public bool UpdateMember(MemberModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_UpdateMemberData", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@memberId", obj.memberId);
            com.Parameters.AddWithValue("@memberName", obj.memberName);
            com.Parameters.AddWithValue("@memberMobileNo", obj.memberMobileNo);
            com.Parameters.AddWithValue("@memberCurrentStatus", obj.memberCurrentStatus);
            com.Parameters.AddWithValue("@memberDonation", obj.memberDonation);
            com.Parameters.AddWithValue("@memberDonationDate", obj.memberDonationDate);
            com.Parameters.AddWithValue("@memberPaymentBy", obj.memberPaymentBy);

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