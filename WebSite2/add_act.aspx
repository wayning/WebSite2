<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_act.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="./css/index1.css">
    <title>我的留言板.新增留言</title>
</head>
<body background="./images/7.jpg" style="background-size:cover;">
    <form id="form1" runat="server">
    <center>
        <h2>我的揪團</h2>
        <input type="button" value="新增揪團" onclick="location.href='add_act.apsx'" class="button" disabled="disabled" />
        <input type="button" value="編輯揪團" onclick="location.href ='act_edit.aspx'" class="button" />
        <input type="button" value="退出登錄" onclick="location.href='login.html'" class="button" />
        <hr width="70%">
    </center>
    <div class="k1">
            <h1>
                發起新團<span>。</span>
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


    </div>
    <p>
        <br />
    </p>
    </form>
    </form>
</body>
</html>
