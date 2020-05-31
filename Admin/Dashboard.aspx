<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Italianos.Admin.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
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
            <div class="centeredDiv">
                Welcome, <asp:Label ID="Name" runat="server"></asp:Label><br />
                <asp:HyperLink HREF="/Admin/ViewItems.aspx" runat="server" Text="View Items"></asp:HyperLink> 
                <asp:GridView Style="margin: auto auto;" ID="ReservationGrid" runat="server">
                <Columns>
                </Columns>
                </asp:GridView>
            </div>
            
        </div>
    </form>
</body>
</html>
