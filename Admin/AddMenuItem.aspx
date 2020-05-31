<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenuItem.aspx.cs" Inherits="Italianos.Admin.AddMenuItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Menu Item</title>
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
                <asp:HyperLink HREF="/Admin/ViewItems.aspx" runat="server" Text="Back to Items"></asp:HyperLink> 
                <h1>New Menu Item</h1>
                <br />
                <label>Item Name</label>
                <asp:TextBox ID="TxtItemName" runat="server"></asp:TextBox>
                <asp:Label ID="ErrName" runat="server"></asp:Label><br />
                <label>Category</label>
                <asp:DropDownList ID="DDCategory" runat="server"></asp:DropDownList><br />
                <label>Course</label>
                <asp:DropDownList ID="DDCourse" runat="server"></asp:DropDownList><br />
                <label>Description</label>
                <asp:TextBox ID="TxtItemDesc" runat="server"></asp:TextBox><asp:Label ID="ErrDesc" runat="server"></asp:Label><br />
                <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Create Item"/>
            </div>
            
        </div>
    </form>
</body>
</html>
