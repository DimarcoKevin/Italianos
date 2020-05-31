<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Italianos.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
    <link href="~/Content/Global.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/Menu.css" rel="stylesheet" type="text/css" />
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
            <div class="menuContainer">
                <h3 class="appetizerTitle">Appetizers</h3>
                <h3 class="mainTitle">Mains</h3>
                <h3 class="dessertTitle">Desserts</h3>
                <div class="appetizerContainer" id="appCont" runat="server">

                </div>
                <div class="mainContainer" id="mainCont" runat="server">
                  
                </div>
                <div class="dessertContainer" id="dessCont" runat="server">
                   
                </div>
            </div>
        </div>
    </form>
</body>
</html>
