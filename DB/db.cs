using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StoredProcedure.Models;

namespace StoredProcedure.DB
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=AB-LPT-VJY-123\\SQLEXPRESS;Database=StoredProcedure;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        public string EmployeeOpt(Employee emp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_EMPLOYEE",con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID",emp.Id);
                com.Parameters.AddWithValue("@Email",emp.Email);
                com.Parameters.AddWithValue("@Name",emp.Name);
                com.Parameters.AddWithValue("@Designation",emp.Designation);
                com.Parameters.AddWithValue("@type",emp.Type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";  
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if(con.State==System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        
        public DataSet EmployeeGet(Employee emp,out string msg)
        {
            msg = string.Empty;
            DataSet ds=new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_EMPLOYEE",con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.Id);
                //com.Parameters.AddWithValue("@Email",emp.Email);
                //com.Parameters.AddWithValue("@Name",emp.Name);
                //com.Parameters.AddWithValue("@Designation",emp.Designation);
                com.Parameters.AddWithValue("@Type",emp.Type);
                SqlDataAdapter da =new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";  
                return ds;
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
    }
}