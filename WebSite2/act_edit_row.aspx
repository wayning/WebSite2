<%@ Page Language="C#" AutoEventWireup="true" CodeFile="act_edit_row.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="./css/index1.css"/>
    <title>我的揪團</title>
    <style type="text/css">
        .auto-style1 {
            width: 63px;
        }
        .auto-style2 {
            width: 208px;
            height: 112px;
        }
    </style>
</head>
<body background="./images/7.jpg" style="background-size:cover;">
    <form id="form1" runat="server" method="POST" action="doact_edit_row.aspx" name="act_edit_row">
    <center>
        <h2>我的揪團</h2>
        <input type="button" value="新增揪團" onclick="location.href ='act_add.aspx'" class="button" />
        <input type="button" value="回到上頁" onclick="location.href='act_edit.aspx'" class="button" />
        <input type="button" value="退出登錄" onclick="location.href='login.html'" class="button" />
        <hr width="70%"/>
    </center>
    <div class="k1">
            <h1>
                <span>資料變更</span>
            </h1>
            <label>
                <span>揪團主題 :</span>
                <input type="text"  id="act_title" runat="server" name="act_title" placeholder="請輸入主題" />
            </label>

            <label>
                <span>揪團地點 :</span>
                <input type="text" id="act_loc" runat="server" name="act_loc" placeholder="請輸入地點" />
            </label>
            <label>
                <span>人數上限 :</span>
                <input type="text" id="act_limit" runat="server" name="act_limit" placeholder="請輸入人數上限" class="auto-style1" />
            </label>
            <label>
                <span>內容說明:</span>
                <textarea name="act_content" runat="server"  id="act_content" placeholder="內容說明" class="auto-style2"></textarea>
            </label>
            <div style="margin-left:125px">
                <input type="submit" value="提交" class="submit"/>
                <input type="reset" value="重置" class="reset"/>
            </div>
    </div>
    <div>

        <br />

    </div>
    <p>
        <br />
    </p>
    </form>
</body>
</html>
