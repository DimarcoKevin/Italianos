<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Italianos.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
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
                <label>Email</label>
                <asp:TextBox ID="TxtEmail" TextMode="Email" runat="server"></asp:TextBox>
                <asp:Label ID="ErrEmail" runat="server"></asp:Label><br />
                <label>Password</label>
                <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Label ID="ErrPassword" runat="server"></asp:Label><br />
                <label>First Name</label>
                <asp:TextBox ID="TxtFirstName" runat="server"></asp:TextBox>
                <asp:Label ID="ErrFName" runat="server"></asp:Label><br />
                <label>Last Name</label>
                <asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox>
                <asp:Label ID="ErrLName" runat="server"></asp:Label><br />
                <label>Phone Number</label>
                <asp:TextBox ID="TxtPhoneNumber" TextMode="Phone" runat="server"></asp:TextBox>
                <asp:Label ID="ErrPhoneNumber" runat="server"></asp:Label><br />
                <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click"/>
            </div>
            
        </div>
    </form>
</body>
</html>
