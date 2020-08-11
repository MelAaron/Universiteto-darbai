<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="_4lab.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 346px;
        }
        .auto-style3 {
            width: 346px;
            height: 33px;
        }
        .auto-style4 {
            height: 33px;
        }
        DarkMode{
            background-color: dimgray;
        }
        .auto-style6 {
            height: 33px;
            width: 357px;
        }
        .auto-style7 {
            width: 357px;
        }
        .darker {
            background-color: black;
        }
        .backgr{
            background-color:dimgray
        }
        .Background{
            background-image:url("Triangles.png");
            width:100vw;
            height:100vh;
            background-size:100%;
            margin-left:-7px;
            margin-top:-7px;
        }
        .Tables{
            background-image:url("TableB2.jpg");
            text-decoration:double;
            border-width: thick;
            font-weight:900;
            text-shadow:initial;
        }
        .Buttons{
            background-image:url("TableB.jpg");
            border-width: thick;
            border-style: dotted;
            width: 50%;
            height: 200%;
            cursor:pointer;
            border-radius:10px;
        }
        .TextBox{
            border-width:thick;
            border-style:dotted;
            background-image:url("TableB.jpg");
            font-style:oblique;
            cursor:text;
            border-radius:10px;
        }
        .DropDownL {
            border-width:thick;
            border-style:dotted;
            background-image:url("TableB.jpg");
            font-style:oblique;
            text-shadow:initial;
            cursor:pointer;
            border-radius:10px;
        }
        .LabelS{
            font-weight:800;
            font-size:16px;
            text-decoration:underline;
        }
        @-a-keyframes rainbow {
            0%{background-position:0% 82%}
            50%{background-position:100% 19%}
            100%{background-position:0% 82%}
        }
        @-b-keyframes rainbow {
            0%{background-position:0% 82%}
            50%{background-position:100% 19%}
            100%{background-position:0% 82%}
        }
        @-c-keyframes rainbow {
            0%{background-position:0% 82%}
            50%{background-position:100% 19%}
            100%{background-position:0% 82%}
        }
        @keyframes rainbow { 
            0%{background-position:0% 82%}
            50%{background-position:100% 19%}
            100%{background-position:0% 82%}
        }
        .wzoom{
			background: linear-gradient(124deg, #ff2400, #e81d1d, #e8b71d, #e3e81d, #1de840, #1ddde8, #2b1de8, #dd00f3, #dd00f3);
            //background-image:url("Triangles.png");
            background-size: 1800% 1800%;

            -a-animation: rainbow 18s ease infinite;
            -b-animation: rainbow 18s ease infinite;
            -b-animation: rainbow 18s ease infinite;
              animation: rainbow 18s ease infinite;
		}
        .auto-style8 {
            background-image: url('TableB.jpg');
            border-width: thick;
            border-style: dotted;
            cursor: pointer;
            border-radius: 10px;
        }
        </style>
</head>
<body class="wzoom" >
    <div class="Background">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Choose the position:" CssClass="LabelS"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="DropDownL">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="TextBox" Text="Show Input Data" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Select the starting date:" CssClass="LabelS"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Starting date field has to be filled" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Select the ending date:" CssClass="LabelS"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="Starting date field has to be filled" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
            <asp:Button ID="Button1" runat="server" Text="Find best players" OnClick="Button1_Click" CssClass="Buttons" Height="68px" Width="279px" Font-Bold="True" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" CssClass="auto-style8" Font-Bold="True" Height="56px" OnClick="Button2_Click" Text="Order by team and name" Visible="False" Width="218px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Select the amount of players to display:" CssClass="LabelS"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" ErrorMessage="Starting date field has to be filled" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                    </td>
                    <td>
                        <asp:Table ID="Table2" runat="server" GridLines="Both" CssClass="Tables">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td>
                        <asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="Tables" Height="19px">
                        </asp:Table>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
        </div>
</body>
</html>
