<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Site.cs" Inherits="ElectricityBillingProject.SiteMaster" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Electricity Billing System</title>
    <asp:ContentPlaceHolder ID="HeadContent" runat="server" />
</head>
<body>
    <form runat="server">
        <div>
            <h1>Electricity Board Billing Automation</h1>
            <asp:ContentPlaceHolder ID="MainContent" runat="server" />
        </div>
    </form>
</body>
</html>
