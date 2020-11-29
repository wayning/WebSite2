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
        Session["act"] = Request.QueryString["act"];
        //input_title.Value = "1";
        
        string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn;
        conn = new SqlConnection(connStr);
        conn.Open();
        //-----------------------------------------------------------------
        //讀取原資料後秀出----------------------------------------------
        SqlCommand cmd = new SqlCommand("SELECT title, loc, limit_people, content FROM tbl_ms2 WHERE act_id = '"+ Request.QueryString["act"]+"'", conn);
        SqlDataReader reader;
        reader = cmd.ExecuteReader();
       if (reader.Read())
        {
            // for (int i = 0; i <= reader.FieldCount - 1; i++)
            //{
                //if (i == 0)
                    act_title.Value = reader.GetValue(0).ToString();
                //else if(i==1)
                    act_loc.Value = reader.GetValue(1).ToString();
                //else if (i == 2)
                    act_limit.Value = reader.GetValue(2).ToString();
                //else if (i == 3)
                    act_content.Value = reader.GetValue(3).ToString();
            //}
               // Response.Write(reader.GetValue(i) + "<br>");
        }
        reader.Close();
        conn.Close();




        //Request.QueryString["act"]
        //Session["uid"].ToString()

        //string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //SqlConnection conn;
        //conn =new SqlConnection(connStr);
        //conn.Open();

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