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
        //Response.Write(Request.QueryString["act"]);
        Session["act"] = Request.QueryString["act"];
        SqlDataSource1.SelectCommand = "SELECT * FROM [tbl_ms1]   WHERE act_id = '" + Request.QueryString["act"] + "' ORDER BY time DESC";
        SqlDataSource2.SelectCommand = "SELECT * FROM [tbl_ms2]   WHERE act_id = '" + Request.QueryString["act"] + "'";
        string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn;
        conn =new SqlConnection(connStr);       
        SqlCommand cmd = new SqlCommand("SELECT username FROM tbl_ms3 WHERE act_id = '" + Session["act"].ToString() + "'  AND username = '" + Session["uid"].ToString() + "'" , conn);  
        cmd.Connection.Open( );
        
        SqlDataReader reader;
        reader = cmd.ExecuteReader();
        if(reader.Read())
        {
            join_button.Disabled = true;
            join_button.Value = "已加入";
            reader.Close();
        }

        /*
        while(reader.Read())
        {
            for (int i = 0; i <= reader.FieldCount - 1; i++)
                Response.Write(reader.GetValue(i) + "<br>");
        }
        */
            //reader.Close();

            // SqlCommand cmd = new SqlCommand("INSERT INTO  tbl_ms1 VALUES (7,'test02','title_test','author_test','liuyan test', '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss") + "')", conn);
            //conn.Open();
            // cmd.ExecuteNonQuery();
    }


}
 