<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Bislerium.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cool CSS Art and Menus</title>
    <style>
        /* CSS Art */
        .cool-art {
            font-family: Arial, sans-serif;
            text-align: center;
            margin-top: 50px;
        }
        .cool-art h1 {
            font-size: 40px;
            color: #4CAF50;
        }
        .cool-art p {
            font-size: 20px;
            color: #333;
        }

        /* Navigation Menu */
        .menu {
            text-align: center;
            margin-top: 20px;
        }
        .menu ul {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }
        .menu ul li {
            display: inline;
            margin-right: 20px;
        }
        .menu ul li a {
            text-decoration: none;
            color: #333;
            font-size: 18px;
        }
        .menu ul li a:hover {
            color: #4CAF50;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cool-art">
            <h1>Welcome!!</h1>
            
        </div>
        
        <!-- Navigation Menu -->
        <div class="menu">
            <ul>
                
                <asp:HyperLink ID="Profile1" runat="server" NavigateUrl="~/ProfilePage.aspx" Text="Profile"></asp:HyperLink> 
                  <asp:HyperLink ID="Register" runat="server" NavigateUrl="~/RegistrationPage.aspx" Text="SignUp"></asp:HyperLink>
                 <asp:HyperLink ID="Blog" runat="server" NavigateUrl="~/Blog.aspx" Text="Blog"></asp:HyperLink>
                 <asp:HyperLink ID="Admin" runat="server" NavigateUrl="~/Blog.aspx" Text="Admin"></asp:HyperLink>
            </ul>

        </div>
    </form>
</body>
</html>
