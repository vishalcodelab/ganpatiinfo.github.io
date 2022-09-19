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
    public class ExpenseRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        public bool AddExpense(ExpenseModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_AddExpenseData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@expenseFor", obj.expenseFor);
            com.Parameters.AddWithValue("@expenseAmount", obj.expenseAmount);
            com.Parameters.AddWithValue("@expenseBy", obj.expenseBy);
            com.Parameters.AddWithValue("@expenseDate", obj.expenseDate);
            com.Parameters.AddWithValue("@expenseYear", obj.expenseYear);

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

        //To view Expense details with generic list 
        public List<ExpenseModel> GetAllExpenseList()
        {
            connection();
            List<ExpenseModel> ExpenseList = new List<ExpenseModel>();
            SqlCommand com = new SqlCommand("sp_getExpenseData", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            ExpenseList = (from DataRow dr in dt.Rows

                           select new ExpenseModel()
                           {
                               e_Id = Convert.ToInt32(dr["e_Id"]),
                               expenseFor = Convert.ToString(dr["expenseFor"]),
                               expenseAmount = Convert.ToInt32(dr["expenseAmount"]),
                               expenseBy = Convert.ToString(dr["expenseBy"]),
                               expenseDate = Convert.ToDateTime(dr["expenseDate"]),
                               expenseYear = Convert.ToString(dr["expenseYear"]),
                           }).ToList();


            return ExpenseList;


        }

        //To Update Donation details
        public bool UpdateExpenseData(ExpenseModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_UpdateExpenseData", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@e_Id", obj.e_Id);
            com.Parameters.AddWithValue("@expenseFor", obj.expenseFor);
            com.Parameters.AddWithValue("@expenseAmount", obj.expenseAmount);
            com.Parameters.AddWithValue("@expenseBy", obj.expenseBy);
            com.Parameters.AddWithValue("@expenseDate", obj.expenseDate);
            com.Parameters.AddWithValue("@expenseYear", obj.expenseYear);
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