<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="UserDownload.aspx.cs" Inherits="UserDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <table width="100%">
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
                        Text="Approved Waiting File info"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="Fileid" HeaderText="Id" />
                             <asp:BoundField DataField="AdminName" HeaderText="AdminName" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="FileName" HeaderText="FileName" />
                            <asp:BoundField DataField="FileSize" HeaderText="Size" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="3">
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                        Text="Download File Info"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Enter File Key"></asp:Label>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="3">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Id" />
                             <asp:BoundField DataField="AdminName" HeaderText="AdminName" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="FileName" HeaderText="FileName" />
                            <asp:BoundField DataField="FileSize" HeaderText="Size" />
                             <asp:BoundField DataField="Bpvalue" HeaderText="Bpvalue" />
                              <asp:BoundField DataField="Sugarvalue" HeaderText="Sugarvalue" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkView0" runat="server" OnClick="lnkView_Click">Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                </td>
                <td colspan="2">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 227px">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 227px">
                    &nbsp;</td>
                <td colspan="2">
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
</asp:Content>

