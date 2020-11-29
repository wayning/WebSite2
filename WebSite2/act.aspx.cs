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
       SqlDataSource1.SelectCommand = "SELECT * FROM [tbl_ms2] ";
    }

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {  
        Response.Redirect("liuyan.aspx?act=" + e.CommandArgument);
    }
}