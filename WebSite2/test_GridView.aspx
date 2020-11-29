<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test_GridView.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="./css/index1.css" />
    <title>我的揪團</title>
</head>
<body background="./images/7.jpg" style="background-size:cover;">
    <form id="form1" runat="server">
    <center>
        <h2>我的揪團</h2>
        <input type="button" value="新增揪團" onclick="location.href ='act_add.aspx'" class="button" />
        <input type="button" value="編輯揪團" onclick="location.href='act_edit.aspx'" class="button" />
        <input type="button" value="退出登陸" onclick="location.href='index.html'" class="button" />
        <hr width="70%" />
    </center>
    <div class="k1">
            <h1>
                <span>揪團資料。</span>
            </h1>
            <label>
                <span>Your Name :</span>
                <input type="text" name="author" placeholder="Your Full Name" />
            </label>

            <label>
                <span>Title :</span>
                <input type="text" name="title" placeholder="Please input title" />
            </label>

            <label>
                <span>Message :</span>
                <textarea name="content" placeholder="Your Message to Us"></textarea>
            </label>
            <div style="margin-left:125px">
                <input type="submit" value="提交" class="submit">
                <input type="reset" value="重置" class="reset">
            </div>
    </div>
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
        <br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="act_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="act_id" SortExpression="act_id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("act_id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("act_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="leader_name" HeaderText="leader_name" SortExpression="leader_name" />
                <asp:BoundField DataField="timer" HeaderText="timer" SortExpression="timer" />
                <asp:BoundField DataField="loc" HeaderText="loc" SortExpression="loc" />
                <asp:BoundField DataField="limit_people" HeaderText="limit_people" SortExpression="limit_people" />
                <asp:TemplateField  SortExpression="title">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text="title"></asp:Label> <br />
                        <asp:Label ID="Label4" runat="server" Text="content"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
           
                  <asp:TemplateField SortExpression="content"> 
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("title") %>'></asp:Label> <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("content") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tbl_ms2]"  DeleteCommand="DELETE FROM [tbl_ms2] WHERE [act_id] = @act_id" InsertCommand="INSERT INTO [tbl_ms2] ([act_id], [leader_name], [timer], [loc], [limit_people]) VALUES (@act_id, @leader_name, @timer, @loc, @limit_people)" UpdateCommand="UPDATE [tbl_ms2] SET [leader_name] = @leader_name, [timer] = @timer, [loc] = @loc, [limit_people] = @limit_people WHERE [act_id] = @act_id">
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
