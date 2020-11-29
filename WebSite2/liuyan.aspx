<%@ Page Language="C#" AutoEventWireup="true" CodeFile="liuyan.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="./css/index1.css"/>
    <title>我的留言板.新增留言</title>
</head>
<body background="./images/7.jpg" style="background-size:cover;">
    <form id="form1" runat="server">
    <center>
        <h2>我的留言板</h2>
        <input type="button" value="檢視留言" onclick="location.href='liuyan.aspx'" class="button" disabled="disabled" />
        <input type="button" value="回到上頁" onclick="location.href = 'act.aspx'" class="button" />
        <input type="button" value="退出登錄" onclick="location.href='login.html'" class="button" />
        <hr width="70%">
    </center>
    <div class="k1">
        <div>


            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="act_id" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="act_id" HeaderText="act_id" ReadOnly="True" SortExpression="act_id" />
                    <asp:BoundField DataField="leader_name" HeaderText="leader_name" SortExpression="leader_name" />
                    <asp:BoundField DataField="timer" HeaderText="timer" SortExpression="timer" />
                    <asp:BoundField DataField="loc" HeaderText="loc" SortExpression="loc" />
                    <asp:BoundField DataField="limit_people" HeaderText="limit_people" SortExpression="limit_people" />
                    <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                    <asp:BoundField DataField="content" HeaderText="content" SortExpression="content" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tbl_ms2]"></asp:SqlDataSource>


        </div>
            <h1>
                <span>新增留言:</span>
            </h1>
         
                <label>
                    <span>Your Name :</span>
                    <input type="text" name="author" placeholder="Your Full Name" />
                </label>
                <label>
                    <span>Message :</span>
                    <textarea name="content" placeholder="Your Message to Us"></textarea>
                 </label>
                <div style="margin-left:125px">
                    <input type="submit" value="提交" class="submit"/>
                    <input type="reset" value="重置" class="reset"/>
                </div>
     
          <br />

        <div>

            <br />
            <br />

            加入此團 :
            <input type="button" id="join_button" runat="server" value="加入!" onclick="location.href = 'joinact.aspx'" class="button" />
            <br />
            <br />
            <br />

        </div>
    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="act_id,lid" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="act_id" HeaderText="act_id" ReadOnly="True" SortExpression="act_id" />
                <asp:BoundField DataField="lid" HeaderText="lid" SortExpression="lid" ReadOnly="True" />
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
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
</body>
</html>  