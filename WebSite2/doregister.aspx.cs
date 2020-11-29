using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.Form["uid"].ToString() == ""))
            Response.Write("<script> alert('註冊失敗!帳號為空白') ; location.href='register.html'; </script>");
        else if (Request.Form["password1"].ToString() != Request.Form["password2"].ToString())
            Response.Write("<script> alert('註冊失敗!2次密碼不同') ; location.href='register.html'; </script>");
        else
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn;
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(null, conn);
            cmd.CommandText = "SELECT username FROM tbl_ms WHERE username = @uname ";
            SqlParameter nameParam = new SqlParameter("@uname", SqlDbType.VarChar, 16);
            nameParam.Value = Request.Form["uid"].ToString();
            cmd.Parameters.Add(nameParam);
            cmd.Prepare();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                Response.Write("<script> alert('註冊失敗!帳號已存在') ; location.href='login.html'; </script>");
            }
            else
            {
                reader.Close();
                SqlCommand cmd2 = new SqlCommand(null, conn);
                cmd2.CommandText = "INSERT INTO tbl_ms VALUES ( @uname2 , @upass ) ";
                SqlParameter name2Param = new SqlParameter("@uname2", SqlDbType.VarChar, 16);
                SqlParameter passParam = new SqlParameter("@upass", SqlDbType.VarChar, 16);
                name2Param.Value = Request.Form["uid"].ToString();
                passParam.Value = Request.Form["password1"].ToString();
                cmd2.Parameters.Add(name2Param);
                cmd2.Parameters.Add(passParam);
                cmd2.Prepare();
                cmd2.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script> alert('註冊成功!') ; location.href='login.html'; </script>");
            }
        }
    }
}