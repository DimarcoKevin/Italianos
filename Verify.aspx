<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verify.aspx.cs" Inherits="Italianos.Verify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account verification</title>
    <link rel="stylesheet" type="text/css" href="~/Content/Global.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <h1>Italianos</h1>
                <ul class="nav">
                    <li><asp:Button CssClass="btn" ID="BtnHome" runat="server" Text="Home" OnClick="BtnHome_Click"/></li>
                    <li><asp:Button CssClass="btn" ID="BtnMenu" runat="server" Text="Menu" OnClick="BtnMenu_Click"/></li>
                    <li><asp:Button CssClass="btn" ID="BtnAccount" runat="server" Text="Account" OnClick="BtnAccount_Click"/></li>
                    <li><asp:Button CssClass="btn" ID="BtnReservations" runat="server" Text="Reservations" OnClick="BtnReservations_Click"/></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
