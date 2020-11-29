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
            conn =new SqlConnection(connStr);
            conn.Open();
            //-----------------------------------------------------------------
            SqlCommand cmd = new SqlCommand(null, conn);
            cmd.CommandText = "UPDATE tbl_ms2 SET title = @act_title , loc = @act_loc , limit_people = @act_limit , content = @act_content WHERE act_id = '" + Session["act"].ToString() + "'";
            SqlParameter titleParam = new SqlParameter("@act_title", SqlDbType.NVarChar, 128);
            SqlParameter locParam = new SqlParameter("@act_loc", SqlDbType.NVarChar, 128);
            SqlParameter limitParam = new SqlParameter("@act_limit", SqlDbType.Int);
            SqlParameter contentParam = new SqlParameter("@act_content", SqlDbType.NVarChar, 1000);
            titleParam.Value = Request.Form["act_title"].ToString();
            locParam.Value = Request.Form["act_loc"].ToString();
            limitParam.Value = Request.Form["act_limit"].ToString();
            contentParam.Value = Request.Form["act_content"].ToString();
            cmd.Parameters.Add(titleParam);
            cmd.Parameters.Add(locParam);
            cmd.Parameters.Add(limitParam);
            cmd.Parameters.Add(contentParam);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            //------------------------------------------------------------------
            Response.Write("<script> alert('修改成功') ; location.href='act_edit.aspx'; </script>");
            conn.Close();
            //"UPDATE tbl_ms2 SET  WHERE act_id = '" + Session["act"].ToString() + "'";


            //SqlCommand cmd = new SqlCommand("select * from tbl_ms1",conn);  
            //cmd.Connection.Open( );
            /*
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                for (int i = 0; i <= reader.FieldCount - 1; i++)
                    Response.Write(reader.GetValue(i) + "<br>");
            }
            */
            //reader.Close();

            // SqlCommand cmd = new SqlCommand("INSERT INTO  tbl_ms1 VALUES (7,'test02','title_test','author_test','liuyan test', '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss") + "')", conn);

            // cmd.ExecuteNonQuery();
            //conn.Close();
        }
    }
}