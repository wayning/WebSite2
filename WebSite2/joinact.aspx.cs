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
        string actstr = Session["act"].ToString();
        if (Session["upass"].ToString() == "true")
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn;
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(null, conn);
            cmd.CommandText = "INSERT INTO tbl_ms3 VALUES ( " + actstr + " , '" + Session["uid"].ToString() + "' )";
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script> alert('加入成功^_^') ; location.href='liuyan.aspx?act=" + actstr + "'; </script>");
        }
        else
            Response.Write("<script> alert('加入失敗>_<') ; location.href='liuyan.aspx?act=" + actstr + "'; </script>");
    }
}