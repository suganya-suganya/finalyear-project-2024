<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="NewAdmin.aspx.cs" Inherits="NewAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <table class="nav-justified" style:"padding:5px">
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="New Admin Registration" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Admin Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Age"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rexNumber" runat="server" 
                        controltovalidate="TextBox2" errormessage="Please enter a 2 digit number!" 
                        ForeColor="Red" validationexpression="^[0-9]{2}$" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Mobile"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        controltovalidate="TextBox3" errormessage="Please enter a 10 digit number!" 
                        ForeColor="Red" validationexpression="^[0-9]{10}$" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox4" ErrorMessage="Email Invalid" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Trichy</asp:ListItem>
                        <asp:ListItem>Covai</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="UserName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox6" ErrorMessage="***" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Retype-Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TextBox7" ControlToValidate="TextBox8" 
                        ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
                    &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Clear" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 281px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

