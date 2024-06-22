<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blogger.aspx.cs" Inherits="Bislerium.blogger" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blogger</title>
    <style>
       
        body {
            background-color: #f5f5f5;
        }
       .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }
       .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
            font-size: 16px;
            line-height: 1.5;
        }
       .btn {
            background-color: #2ecc71;
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
        }
       .btn:hover {
            background-color: #1b9b54;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Blogger</h2>
            <asp:Label runat="server" AssociatedControlID="txtTitle">Title:</asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            <br /><br />
            <asp:Label runat="server" AssociatedControlID="txtBody">Body:</asp:Label>
            <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            <br /><br />
            <asp:Label runat="server" AssociatedControlID="fuImage">Image:</asp:Label>
            <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" />
            <br /><br />
            <asp:Image ID="imgPreview" runat="server" CssClass="img-preview" />
            <br /><br />
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" OnClick="btnSave_Click" />
            <br /><br />
          <asp:GridView ID="grdPosts" runat="server" AutoGenerateColumns="false" OnRowDeleting="grdPosts_RowDeleting" OnRowUpdating="grdPosts_RowUpdating" OnRowEditing="grdPosts_RowEditing" OnRowCancelingEdit="grdPosts_RowCancelingEdit">
    

    <Columns>
        <asp:BoundField DataField="PostId" HeaderText="PostId" />
        <asp:BoundField DataField="UserId" HeaderText="UserId" />
        <asp:BoundField DataField="CreatedAt" HeaderText="CreatedAt" />
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="Body" HeaderText="Body" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Image ID="imgPost" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' Height="100" Width="100" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:FileUpload ID="fuEditImage" runat="server" CssClass="form-control" />
                <asp:Image ID="imgEditPreview" runat="server" CssClass="img-preview" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CssClass="btn" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn" />
            </EditItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>
             <columns>
<asp:TemplateField HeaderText="Upvote">
    <ItemTemplate>
        <asp:Button ID="btnUpvote" runat="server" Text="Upvote" CommandName="Upvote" CssClass="btn" />
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Downvote">
    <ItemTemplate>
        <asp:Button ID="btnDownvote" runat="server" Text="Downvote" CommandName="Downvote" CssClass="btn" />
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Comments">
    <ItemTemplate>
        <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
        <br />
        <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" CommandName="AddComment" CssClass="btn" />
        <asp:GridView ID="grdComments" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Comment" HeaderText="Comment" />
                <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteComment" />
            </Columns>
        </asp:GridView>
    </ItemTemplate>
</asp:TemplateField>
</columns>
</asp:TemplateField>
        </div>
    </form>
</body>
</html>
