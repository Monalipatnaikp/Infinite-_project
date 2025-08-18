<%@ Page Title="Retrieve Bills" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RetrieveBills.aspx.cs" Inherits="ElectricityBillingProject.RetrieveBills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Retrieve Last N Bills</h2>
    Enter Last 'N' Number of Bills To Generate: <asp:TextBox ID="txtN" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" CssClass="button" /><br />
    <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
            <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
            <asp:BoundField DataField="UnitsConsumed" HeaderText="Units Consumed" />
            <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" />
        </Columns>
    </asp:GridView>
    <br />
    <a href="Billing.aspx">Add Bills</a>
</asp:Content>