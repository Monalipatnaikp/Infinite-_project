<%@ Page Title="Add Bills" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="ElectricityBillingProject.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Electricity Bills</h2>
    Enter Number of Bills To Be Added: <asp:TextBox ID="txtNumBills" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnStartAdding" runat="server" Text="Start Adding" OnClick="btnStartAdding_Click" CssClass="button" /><br />
    <asp:Panel ID="pnlAddBills" runat="server" Visible="false">
        Enter Consumer Number: <asp:TextBox ID="txtConsumerNumber" runat="server"></asp:TextBox><br />
        Enter Consumer Name: <asp:TextBox ID="txtConsumerName" runat="server"></asp:TextBox><br />
        Enter Units Consumed: <asp:TextBox ID="txtUnits" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAddBill" runat="server" Text="Add Bill" OnClick="btnAddBill_Click" CssClass="button" />
    </asp:Panel>
    <asp:Label ID="lblOutput" runat="server"></asp:Label><br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <a href="RetrieveBills.aspx">Retrieve Bills</a>
</asp:Content>
