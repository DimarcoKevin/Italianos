<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cancel.aspx.cs" Inherits="Italianos.Cancel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cancel Reservation</title>
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
                 <h1>Cancel a Reservation</h1>
                <label>Reservation ID</label><br />
                <asp:TextBox ID="TxtReservationId" runat="server"></asp:TextBox><asp:Label ID="ErrResId" Text="" runat="server"></asp:Label><br />
                <asp:Button ID="BtnFindReservation" runat="server" Text="Find Reservation"  OnClick="BtnFindReservation_Click"/>
                <div class="resInfo" id="resInfo" runat="server">
                <p class="hostInfo" id="hostInfo" runat="server">te</p>
                <p class="timeInfo" id="timeInfo" runat="server">te</p>
                <p class="tableNum" id="tableNum" runat="server">te</p>
                <p class="appetizer" id="appetizer" runat="server">te</p>
                <p class="main" id="main" runat="server">te</p>
                <p class="dessert" id="dessert" runat="server">te</p> 
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel Reservation" OnClick="BtnCancel_Click"/>
            </div>
           
            
            </div>
        </div>
    </form>
</body>
</html>
