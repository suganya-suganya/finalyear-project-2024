<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminFileUpload.aspx.cs" Inherits="AdminFileUpload" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <table width="100%">
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" 
                        style="font-size: medium; font-weight: 700" Text="Admin  File Upload"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                        Text="Admin Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
                        Text="AdminName"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="FileInfo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px; height: 31px;">
                    </td>
                <td style="height: 31px">
                    <asp:Label ID="Label9" runat="server" style="font-weight: 700" Text="Bp Value"></asp:Label>
                </td>
                <td style="height: 31px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td style="height: 31px">
                    </td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label10" runat="server" style="font-weight: 700" 
                        Text="Sugar Value"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                        Text="Upload File"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="FileUpload1" ErrorMessage="***" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="Key"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
                    &nbsp;
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Clear" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Encryption Time Chart"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Chart ID="Chart1" runat="server">
                        <series>
                            <asp:Series ChartArea="Size" Name="Time">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="Size">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                </td>
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
    <p>
    </p>
</asp:Content>

