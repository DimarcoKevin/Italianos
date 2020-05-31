<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewItems.aspx.cs" Inherits="Italianos.Admin.ViewItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Items</title>
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
                <asp:HyperLink HREF="/Admin/Dashboard.aspx" runat="server" Text="Back to Dashboard"></asp:HyperLink> 
                <asp:HyperLink HREF="/Admin/AddMenuItem.aspx" runat="server" Text="Add Item"></asp:HyperLink> 
                <asp:GridView Style="margin: auto auto;" ID="ItemGrid" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Available">
                            <ItemTemplate>
                                <asp:CheckBox ID="Available" runat="server" Checked="true"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Accept Changes"/>
            </div>
        </div>
    </form>
</body>
</html>
