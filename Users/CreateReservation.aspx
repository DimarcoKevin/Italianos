<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateReservation.aspx.cs" Inherits="Italianos.User.CreateReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Reservation</title>
    <link href="~/Content/Global.css" rel="stylesheet" type="text/css" />
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
                <asp:HyperLink HREF="/Users/Dashboard.aspx" runat="server" Text="Back to Dashboard"></asp:HyperLink> 
                <asp:Calendar ID="Date" style="margin: auto auto;" runat="server" OnSelectionChanged="Date_SelectionChanged" OnDayRender="Date_DayRender" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar><br />
                <label>Time Slot</label><br />
                <asp:DropDownList ID="TimeSlot" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="TimeSlot_TextChanged"></asp:DropDownList><br />
                <label>Table Number</label><br />
                <asp:DropDownList ID="TableNumber" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TableNumber_SelectedIndexChanged"></asp:DropDownList><br />
                <label>Appetizer</label><br />
                <asp:DropDownList ID="Appetizer" runat="server"></asp:DropDownList><br />
                <label>Main</label><br />
                <asp:DropDownList ID="Main" runat="server"></asp:DropDownList><br />
                <label>Dessert</label><br />
                <asp:DropDownList ID="Dessert" runat="server"></asp:DropDownList><br />
                <label>Number of Guests</label><br />
                <asp:TextBox ID="TxtNumOfGuests" runat="server"></asp:TextBox><br /> <asp:RangeValidator MinimumValue="1" MaximumValue="4" ControlToValidate="TxtNumOfGuests" ID="RangeValidator1" runat="server" Display="Dynamic" ErrorMessage="Invalid Number of Guest (1-4)">
                </asp:RangeValidator><br />
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click"/>
            </div>
               
        </div>
    </form>
</body>
</html>
