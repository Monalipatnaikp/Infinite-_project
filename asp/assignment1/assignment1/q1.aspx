<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question1.aspx.cs" Inherits="Assignment_1.Question1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Name :  
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"  ErrorMessage="Name is required."  ForeColor="Red"></asp:RequiredFieldValidator>  
            <p>  
                Family Name :  
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator2"  runat="server"  ControlToValidate="TextBox2"  ErrorMessage="Family Name is required."  ForeColor="Red"></asp:RequiredFieldValidator>  
                <asp:CompareValidator  ID="CompareValidator1"  runat="server"  ControlToValidate="TextBox2"  ControlToCompare="TextBox1"  ErrorMessage="Name must be different from Family Name."  ForeColor="Red"  Operator="NotEqual"></asp:CompareValidator>  
            </p>  
            <p>  
                Address :  
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator3"  runat="server"  ControlToValidate="TextBox3"  ErrorMessage="Address is required."  ForeColor="Red"></asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator  ID="RegularExpressionValidator1"  runat="server"  ControlToValidate="TextBox3"  ValidationExpression=".{2,}"  ErrorMessage="Address must have at least 2 characters."  ForeColor="Red"></asp:RegularExpressionValidator>  
            </p>  
            <p>  
                City :  
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator4"  runat="server"  ControlToValidate="TextBox4"  ErrorMessage="City is required."  ForeColor="Red"></asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator  ID="RegularExpressionValidator2"  runat="server"  ControlToValidate="TextBox4"  ValidationExpression=".{2,}"  ErrorMessage="City must have at least 2 characters."  ForeColor="Red"></asp:RegularExpressionValidator>  
            </p>  
            <p>  
                Zip Code :  
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator5"  runat="server"  ControlToValidate="TextBox5"  ErrorMessage="Zip Code is required."  ForeColor="Red"></asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator  ID="RegularExpressionValidator3"  runat="server"  ControlToValidate="TextBox5"  ValidationExpression="^\d{5}$"  ErrorMessage="Zip Code must be 5 digits."  ForeColor="Red"></asp:RegularExpressionValidator>  
            </p>  
            <p>  
                Phone :  
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator6"  runat="server"  ControlToValidate="TextBox6"  ErrorMessage="Phone is required."  ForeColor="Red"></asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator  ID="RegularExpressionValidator4"  runat="server"  ControlToValidate="TextBox6"  ValidationExpression="^\d{2}-\d{7}$|^\d{3}-\d{7}$"  ErrorMessage="Phone must follow the format XX-XXXXXXX or XXX-XXXXXXX."  ForeColor="Red"></asp:RegularExpressionValidator>  
            </p>  
            <p>  
                Email :  
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator7"  runat="server"  ControlToValidate="TextBox7"  ErrorMessage="Email is required."  ForeColor="Red"></asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator  ID="RegularExpressionValidator5"  runat="server"  ControlToValidate="TextBox7"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ValidationExpressionOptions="IgnoreCase"  ErrorMessage="Enter a valid email address."  ForeColor="Red"></asp:RegularExpressionValidator>  
            </p>  
            <p>  
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check" />
        </div>
    </form>
</body>
</html>
