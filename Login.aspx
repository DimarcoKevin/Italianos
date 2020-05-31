<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Italianos.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="~/Content/Global.css"/>
    <link rel="stylesheet" type="text/css" href="~/Content/Login.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainBody">
            <div class="header">
                <h1>Italianos</h1>
                <ul class="nav">
                    <li><asp:Button CssClass="btn" ID="BtnHome" runat="server" Text="Home" OnClick="BtnHome_Click"/></li>
                    <li><asp:Button CssClass="btn" ID="BtnMenu" runat="server" Text="Menu" OnClick="BtnMenu_Click"/></li>
                    <li><asp:Button CssClass="btn" ID="BtnAccount" runat="server" Text="Account" OnClick="BtnAccount_Click"/></li>
                    <li><asp:Button CssClass="btn" ID="BtnReservations" runat="server" Text="Reservations" OnClick="BtnReservations_Click"/></li>
                </ul>
            </div>
             
            <div class="loginForm">
                <h4>Login</h4>
                <label>Email</label><br />
                <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox><asp:Label ID="LblEmail" runat="server"></asp:Label><br />  
                <label>Password</label><br />
                <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox><asp:Label ID="LblPassword" runat="server"></asp:Label><br />
                <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Login"/><br />
                <asp:Button ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" Text="Register"/>
            </div>
            </div>
    </form>
</body>
</html>
