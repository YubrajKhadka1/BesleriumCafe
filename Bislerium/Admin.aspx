<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Bislerium.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Bislerium.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
    <style>
        body {
            background-color: #dff0d8;
            font-family: Arial, sans-serif;
        }

        h1 {
            color: #337ab7;
        }

        .error-message {
            color: red;
        }

        .form-container {
            margin: 0 auto;
            width: 300px;
            padding: 20px;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }

        .form-container input[type="submit"] {
            background-color: #337ab7;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }

        .form-container input[type="submit"]:hover {
            background-color: #23527c;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="form-container">
            <h1>Admin Page</h1>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" />
            <asp:DropDownList ID="ddlUsers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Button ID="btnPromoteUser" runat="server" Text="Promote User to Admin" OnClick="btnPromoteUser_Click" />
        </div>
    </form>
</body>
</html>