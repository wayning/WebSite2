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
            //查詢act_id最大值---------------------------------------------------------
            cmd.CommandText = "SELECT MAX(act_id) FROM [tbl_ms2] ";
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            string NewActId=null;
            if (reader.Read())           
                NewActId = Convert.ToString(Convert.ToInt32(reader.GetValue(0).ToString()) + 1);
            else
                Response.Write("<script> alert('增加失敗，act_id查詢不到') ; location.href='act.aspx'; </script>");
            reader.Close();
            //------------------------------------------------------------------------------
            cmd.CommandText = "INSERT INTO tbl_ms2 VALUES ( " + NewActId + " , '" + Session["uid"].ToString() + "' , '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss") + "', @act_loc , @act_limit , @act_title , @act_content )";
            SqlParameter locParam = new SqlParameter("@act_loc", SqlDbType.NVarChar, 128);
            SqlParameter limitParam = new SqlParameter("@act_limit", SqlDbType.Int);
            SqlParameter titleParam = new SqlParameter("@act_title", SqlDbType.NVarChar, 128);
            SqlParameter contentParam = new SqlParameter("@act_content", SqlDbType.NVarChar, 1000);
            locParam.Value = Request.Form["act_loc"].ToString();
            limitParam.Value = Request.Form["act_limit"].ToString();
            titleParam.Value = Request.Form["act_title"].ToString();
            contentParam.Value = Request.Form["act_content"].ToString();
            cmd.Parameters.Add(locParam);
            cmd.Parameters.Add(limitParam);
            cmd.Parameters.Add(titleParam);
            cmd.Parameters.Add(contentParam);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            //------------------------------------------------------------------
            //表三增加人員資料
            cmd.CommandText = "INSERT INTO tbl_ms3 VALUES ( " + NewActId+ " , '" + Session["uid"].ToString() + "' )";
            cmd.ExecuteNonQuery();

            //------------------------------------------------------------------
            //增加系統第一筆留言
            cmd.CommandText = "INSERT INTO tbl_ms1 VALUES ( " + NewActId + " , '0' ,  'SYSOP' ,  @sysopa , @sysopl , '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss") + "' )";
            SqlParameter sysopaParam = new SqlParameter("@sysopa", SqlDbType.NVarChar, 16);
            SqlParameter sysoplParam = new SqlParameter("@sysopl", SqlDbType.NVarChar, 1000);
            sysopaParam.Value = "亞多米尼史特蕾達";
            sysoplParam.Value = "您好，歡迎使用留言板 !";
            cmd.Parameters.Add(sysopaParam);
            cmd.Parameters.Add(sysoplParam);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script> alert('增加成功') ; location.href='act_edit.aspx'; </script>");
        }
     }
}