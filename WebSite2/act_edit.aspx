<%@ Page Language="C#" AutoEventWireup="true" CodeFile="act_edit.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="./css/index1.css">
    <title>我的揪團</title>
</head>
<body background="./images/7.jpg" style="background-size:cover;">
    <form id="form1" runat="server">
    <center>
        <h2>我的揪團</h2>
        <input type="button" value="新增揪團" onclick="location.href ='act_add.aspx'" class="button" />
        <input type="button" value="回到上頁" onclick="location.href='act.aspx'" class="button" />
        <input type="button" value="退出登錄" onclick="location.href='index.html'" class="button" />
        <hr width="70%">
    </center>
    <div class="k1">
            <h1>
                <span>揪團資料。</span>
            </h1>
    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="act_id" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                <asp:TemplateField HeaderText="act_id" SortExpression="act_id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("act_id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="viewadd" CommandArgument='<%# Bind("act_id") %>'>變更揪團資訊</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="leader_name" HeaderText="leader_name" SortExpression="leader_name" />
                <asp:BoundField DataField="timer" HeaderText="timer" SortExpression="timer" />
                <asp:BoundField DataField="loc" HeaderText="loc" SortExpression="loc" />
                <asp:BoundField DataField="limit_people" HeaderText="limit_people" SortExpression="limit_people" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="content" HeaderText="content" SortExpression="content" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tbl_ms2] " DeleteCommand="DELETE FROM [tbl_ms2] WHERE [act_id] = @act_id" InsertCommand="INSERT INTO [tbl_ms2] ([act_id], [leader_name], [timer], [loc], [limit_people]) VALUES (@act_id, @leader_name, @timer, @loc, @limit_people)" UpdateCommand="UPDATE [tbl_ms2] SET [leader_name] = @leader_name, [timer] = @timer, [loc] = @loc, [limit_people] = @limit_people WHERE [act_id] = @act_id">
            <DeleteParameters>
                <asp:Parameter Name="act_id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="act_id" Type="Int32" />
                <asp:Parameter Name="leader_name" Type="String" />
                <asp:Parameter Name="timer" Type="DateTime" />
                <asp:Parameter Name="loc" Type="String" />
                <asp:Parameter Name="limit_people" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="leader_name" Type="String" />
                <asp:Parameter Name="timer" Type="DateTime" />
                <asp:Parameter Name="loc" Type="String" />
                <asp:Parameter Name="limit_people" Type="Int32" />
                <asp:Parameter Name="act_id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </div>
    <p>
        <br />
    </p>
    </form>
</body>
</html>  
