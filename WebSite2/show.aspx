<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="./css/index1.css">
    <title>我的留言板.新增留言</title>
</head>
<body background="./images/7.jpg" style="background-size:cover;">
    <form id="form1" runat="server">
    <center>
        <h2>我的留言板</h2>
        <input type="button" value="新增留言" onclick="location.href='add.aspx'" class="button" />
        <input type="button" value="檢視留言" onclick="location.href='show.aspx'" class="button" />
        <input type="button" value="退出登陸" onclick="location.href='index.html'" class="button" />
        <hr width="70%">
    </center>
    <div class="k1">

    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ip" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ip" HeaderText="ip" ReadOnly="True" SortExpression="ip" />
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                <asp:BoundField DataField="liuyan" HeaderText="liuyan" SortExpression="liuyan" />
                <asp:BoundField DataField="time" HeaderText="time" SortExpression="time" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tbl_ms1]"></asp:SqlDataSource>

    </div>
    <p>
        <br />
    </p>
    </form>
    </form>
</body>
</html>  