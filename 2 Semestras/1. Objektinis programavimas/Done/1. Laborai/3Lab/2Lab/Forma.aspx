<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="_2Lab.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .TextBoxStyle{
            border-style: double;
            background-color: aquamarine;
            font-style: italic;
            text-shadow: initial;
            font-family: "franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            color: #000080;
            text-decoration: underline;
            cursor: text;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 288px;
        }
        .auto-style3 {
            width: 288px;
            height: 34px;
        }
        .auto-style4 {
            height: 34px;
        }
        .auto-style5 {
            width: 317px;
        }
        .auto-style6 {
            height: 34px;
            width: 317px;
        }
        .auto-style7 {
            width: 288px;
            height: 26px;
        }
        .auto-style8 {
            width: 317px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
        }
        .auto-style10 {
            width: 288px;
            height: 33px;
        }
        .auto-style11 {
            width: 317px;
            height: 33px;
        }
        .auto-style12 {
            height: 33px;
        }
        .ButtonStyle {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            font-weight: bold;
            font-style: oblique;
            font-variant: normal;
            text-transform: none;
            color: #000080;
            background-color: #FFFF00;
            padding: 0px;
            border: thin dashed #000080;
            font-size: inherit;
            cursor: pointer;
        }
        .LabelStyle {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            color: #000080;
            font-weight: bold;
        }
        .TableStyle {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            color: #000080;
            table-layout: fixed;
            border-collapse: collapse;
            border-spacing: 10px;
            border: 3px solid #800000;
            background-color: #C0C0C0;
        }
        .CheckBoxStyle {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            font-size: medium;
            font-style: oblique;
            font-weight: bolder;
            color: #000080;
            background-color: #FFFFFF;
            border-style: groove;
            border-width: thin;
            cursor: pointer;
        }
        .BackgroundStyle {
            background-color: #CC99FF;
            border: thick double #800000;
        }
        .IndividualCellColor {
            background-color: #9900CC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="BackgroundStyle">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Text="Select the subscriber file" CssClass="LabelStyle"></asp:Label>
                    </td>
                    <td class="auto-style6">
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TextBoxStyle" />
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*" ForeColor="Red" ValidationGroup="Val 2"></asp:CustomValidator>
                    </td>
                    <td class="auto-style4">
            <asp:Label ID="Label4" runat="server" ForeColor="Red" Visible="False" Font-Bold="True">No list found</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Text="Select the publication file" CssClass="LabelStyle"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="TextBoxStyle" />
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="FileUpload2" ErrorMessage="*" ForeColor="Red" ValidationGroup="Val 2"></asp:CustomValidator>
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" CssClass="ButtonStyle" Height="50px" OnClick="Button2_Click" Text="Read Files" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <asp:Label ID="Label1" runat="server" Text="Type in the publication's code" CssClass="LabelStyle"></asp:Label>
                    </td>
                    <td class="auto-style6">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxStyle"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Code required" ForeColor="Red" ValidationGroup="Val1" Enabled="False">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
            <asp:Label ID="Label3" runat="server" Visible="False" CssClass="LabelStyle"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Type in the month (1-12)" CssClass="LabelStyle"></asp:Label>
                    </td>
                    <td class="auto-style5">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBoxStyle"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Month required" ForeColor="Red" ValidationGroup="Val1" Enabled="False">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
            <asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="TableStyle">
            </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style8"></td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Val1" />
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Compile" ValidationGroup="Val 2" CssClass="ButtonStyle" Height="50px" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Show input data" CssClass="CheckBoxStyle" />
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="SubTLabel" runat="server" Visible="False" CssClass="LabelStyle"></asp:Label>
                        <br />
                        </td>
                    <td class="auto-style8">
                        <asp:Label ID="PubTLabel" runat="server" Visible="False" BorderStyle="None" CssClass="LabelStyle"></asp:Label>
                        <br />
                        </td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Table ID="TableSubs" runat="server" Visible="False" GridLines="Both" CssClass="TableStyle" HorizontalAlign="Center">
                        </asp:Table>
                        </td>
                    <td class="auto-style5">
                        <asp:Table ID="TablePubs" runat="server" Visible="False" GridLines="Both" CssClass="TableStyle" HorizontalAlign="Center">
                        </asp:Table>
                        </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Table ID="Table2" runat="server" CssClass="TableStyle" GridLines="Both">
                        </asp:Table>
                        </td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />
                        <br />
                        </td>
                    <td class="auto-style2">
                        <br />
                        </td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />
                        </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
