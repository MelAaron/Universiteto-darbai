<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="SesijaWeb.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Naujas Irasas:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ivesti" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Egzistuojantys irasai:"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" HorizontalAlign="Left">
            </asp:Table>
        </div>
    </form>
</body>
</html>
