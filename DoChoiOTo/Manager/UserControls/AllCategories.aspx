<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Site.Master" AutoEventWireup="true" CodeBehind="AllCategories.aspx.cs" Inherits="DoChoiOTo.Manager.UserControls.AllCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="grvServices" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" OnRowCommand="grvServices_RowCommand" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderText="Id" />
            <asp:BoundField DataField="ServiceName" HeaderStyle-Width="500px" HeaderText="Services name" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa ?')" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="cmdDelete" Text="Xóa" OnClick="btnXoa_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView>
</asp:Content>
