<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="_2Lab.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .t1{
            
            border-spacing: 25px;
            background-color: plum;
            color:black;
            grid-row-start:initial;
            /*color:red;
            text-shadow:initial;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Compile" />
            <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Type in the publication's code"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Code required" ForeColor="Red" ValidationGroup="Val1">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Type in the month (1-12)"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Month required" ForeColor="Red" ValidationGroup="Val1">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Find Subscribers" ValidationGroup="Val1" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" GridLines="Both">
            </asp:Table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Val1" />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Show input data" />
            <br />
            <table class="t1">
                <tr>
                    <td>
                        <asp:Label ID="SubTLabel" runat="server" Visible="False"></asp:Label>
                        <br />
                        <asp:Table ID="TableSubs" runat="server" Visible="False" GridLines="Both">
                        </asp:Table>
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="PubTLabel" runat="server" Visible="False"></asp:Label>
                        <br />
                        <asp:Table ID="TablePubs" runat="server" Visible="False" GridLines="Both">
                        </asp:Table>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
