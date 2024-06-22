<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="Bislerium.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
    <link rel="stylesheet" type="text/css" href="styles.css">
    <style>
        .registration-container {
    background-color: #fff;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    width: 300px;
    margin: 100px auto;
    padding: 20px;
}

.registration-container h2 {
    text-align: center;
    color: #333;
}

.registration-container label {
    display: block;
    margin-bottom: 5px;
    color: #666;
}

.registration-container input[type="text"],
.registration-container input[type="password"],
.registration-container input[type="submit"] {
    width: 100%;
    padding: 8px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
}

.registration-container input[type="submit"] {
    background-color: #4CAF50;
    color: white;
    border: none;
    border-radius: 3px;
    cursor: pointer;
}

.registration-container input[type="submit"]:hover {
    background-color: #45a049;
}

.registration-container .link-container {
    text-align: center;
    margin-top: 10px;
}

.registration-container .link-container a {
    color: #007bff;
    text-decoration: none;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="registration-container">
            <h2>Registration</h2>
            <div>
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </div>
            <div>
                <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/LoginPage.aspx">Login</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
