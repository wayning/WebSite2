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
            //Request.QueryString["act"]
            //Session["uid"].ToString()
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn;
            conn = new SqlConnection(connStr);
            conn.Open();
            //-----------------------------------------------------------------
            SqlCommand cmd = new SqlCommand(null, conn);
            //查詢留言id最大值---------------------------------------------------------
            cmd.CommandText = "SELECT MAX(lid) FROM [tbl_ms1] WHERE act_id = " + Session["act"].ToString() ;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            string Newlid = null;
            if (reader.Read())
                Newlid = Convert.ToString(Convert.ToInt32(reader.GetValue(0).ToString()) + 1);
            else
                Response.Write("<script> alert('增加失敗，lid查詢不到') ; location.href='liuyan.aspx'; </script>");
            reader.Close();
            //------------------------------------------------------------------------------
            //" + Session["act"].ToString() + "          
            //Response.Write(actstr);          
            cmd.CommandText = "INSERT INTO tbl_ms1 VALUES ( " + actstr + " , " + Newlid + " , '" + Session["uid"].ToString() + "' , @author , @content , '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss") + "' )";
            SqlParameter authorParam = new SqlParameter("@author", SqlDbType.NVarChar, 16);
            SqlParameter contentParam = new SqlParameter("@content", SqlDbType.NVarChar, 1000);
            authorParam.Value = Request.Form["author"].ToString();
            contentParam.Value = Request.Form["content"].ToString();
            cmd.Parameters.Add(authorParam);
            cmd.Parameters.Add(contentParam);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
            //------------------------------------------------------------------

            Response.Write("<script> alert('增加成功') ; location.href='liuyan.aspx?act="+ actstr + "'; </script>");
        }
        else
            Response.Write("<script> alert('增加失敗') ; location.href='liuyan.aspx?act=" + actstr + "'; </script>");
    }
}