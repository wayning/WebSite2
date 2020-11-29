using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = "SELECT * FROM [tbl_ms2]   WHERE leader_name = '" +Session["uid"].ToString() + "'" ;
        //WHERE leader_name = '<%# Session["uid"].ToString() %>'
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("act_edit_row.aspx?act=" + e.CommandArgument);
    }
}