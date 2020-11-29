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
        //string LoginName = Request.Form["uid"].ToString();
        
        string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn;
        conn = new SqlConnection(connStr);
        conn.Open();
        //SqlCommand cmd = new SqlCommand("SELECT username FROM tbl_ms WHERE  "+
        //                                                                             " username = '" + Request.Form["uid"].ToString() + 
         //                                                             "' AND  password = '" + Request.Form["password"].ToString() + "'" , conn );
        
        SqlCommand cmd = new SqlCommand(null,conn);
        cmd.CommandText ="SELECT username FROM tbl_ms WHERE username = @uname AND password = @upassword ";
        SqlParameter nameParam = new SqlParameter("@uname", SqlDbType.VarChar, 16);
        SqlParameter pwParam = new SqlParameter("@upassword", SqlDbType.VarChar, 16);
        nameParam.Value = Request.Form["uid"].ToString();
        pwParam.Value = Request.Form["password"].ToString();
        cmd.Parameters.Add(nameParam);
        cmd.Parameters.Add(pwParam);
        cmd.Prepare();
        //cmd.ExecuteNonQuery();
        
        //SqlCommand cmd = new SqlCommand("SELECT username FROM tbl_ms", conn);
        SqlDataReader reader;
        reader = cmd.ExecuteReader();
        // while(reader.Read())
        //{
        // for (int i = 0; i <= reader.FieldCount - 1; i++)
        //  Response.Write(reader.GetValue(i) + "<br>");
        //}
        if (reader.Read())
        {
            Session["upass"] = "true";
            Session["uid"] = reader.GetValue(0).ToString();
            Response.Write("<script> alert('登入成功"+ reader.GetValue(0).ToString() + "') ; location.href='act.aspx'; </script>");
        }
        else
        {
            Session["upass"] = null;
            Response.Write("<script> alert('帳號或密碼錯誤') ; location.href='login.html'; </script>");
        }
        //reader.Close();

        //SqlCommand cmd = new SqlCommand("INSERT INTO  tbl_ms1 VALUES (7,'test02','title_test','author_test','liuyan test', '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss") + "')", conn);
        //conn.Open();
        //cmd.ExecuteNonQuery();
    }
}