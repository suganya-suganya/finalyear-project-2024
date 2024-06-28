<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Compare.aspx.cs" Inherits="Compare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
        <table width="100%">
            <tr>
                <td style="width: 260px">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" 
                        style="font-size: medium; font-weight: 700" Text="Comparison"></asp:Label>
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
                    <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                        Text="Upload File"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
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
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Encrypt" />
                    &nbsp;
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                        Text="Decrypt" />
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
                <td colspan="2">
                    <asp:Label ID="Label8" runat="server" Text="Encryption Time Chart"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 260px">
                    <asp:Label ID="Label9" runat="server" Text="ECC"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="Label10" runat="server" Text="AES"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="BLOWFISH"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 260px">
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
                <td colspan="2">
                    <asp:Chart ID="Chart2" runat="server">
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
                    <asp:Chart ID="Chart3" runat="server">
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
            </tr>
            <tr>
                <td style="width: 260px">
                    <asp:Label ID="Label12" runat="server" Text="Size"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="Label13" runat="server" Text="Size"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Size"></asp:Label>
                </td>
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
                    <asp:Label ID="Label15" runat="server" Text="Decryption Time Chart"></asp:Label>
                </td>
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
                    <asp:Chart ID="Chart4" runat="server">
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
                <td colspan="2">
                    <asp:Chart ID="Chart5" runat="server">
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
                    <asp:Chart ID="Chart6" runat="server">
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
            </tr>
            <tr>
                <td style="width: 260px">
                    <asp:Label ID="Label16" runat="server" Text="Size"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="Label17" runat="server" Text="Size"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="Size"></asp:Label>
                </td>
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

            </table>
    <p>
    </p>
</asp:Content>

