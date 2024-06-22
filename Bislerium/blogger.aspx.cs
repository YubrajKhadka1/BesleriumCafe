using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bislerium
{
    public partial class blogger : Page
    {
        private const string ConnectionString = "Data Source=MARK1\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;";
        private int _userId = 1;
        private void LoadPosts()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT PostId, UserId, CreatedAt, Title, Body, ImageUrl FROM BlogPosts", connection);
                SqlDataReader reader = command.ExecuteReader();
                grdPosts.DataSource = reader;
                grdPosts.DataBind();
            }
            grdPosts.DataKeyNames = new string[] { "PostId" };
        }

        private void SavePost(int userId, string title, string body, string imageUrl)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO BlogPosts (UserId, Title, Body, ImageUrl) VALUES (@UserId, @Title, @Body, @ImageUrl)", connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Body", body);
                command.Parameters.AddWithValue("@ImageUrl", imageUrl);
                command.ExecuteNonQuery();
            }
        }

        private void DeletePost(int postId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM BlogPosts WHERE PostId = @PostId", connection);
                command.Parameters.AddWithValue("@PostId", postId);
                command.ExecuteNonQuery();
            }
        }

        private void SaveReaction(int postId, int userId, string Type)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Data Source=MARK1\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Reactions (PostId, UserId, Type, CreatedAt) VALUES (@PostId, @UserId, @ReactionType, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@PostId", postId);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ReactionType", Type);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

                command.ExecuteNonQuery();
            }
        }

        private void SaveComment(int postId, int userId, string Content)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Data Source=MARK1\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Comments (PostId, UserId, Content, CreatedAt) VALUES (@PostId, @UserId, @Content, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@PostId", postId);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Content", Content);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

                command.ExecuteNonQuery();
            }
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtBody.Text = string.Empty;
            fuImage.Dispose();
            imgPreview.ImageUrl = string.Empty;
        }
        private void UpdatePost(int postId, int userId, string title, string body, string imageUrl)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE BlogPosts SET UserId = @UserId, Title = @Title, Body = @Body, ImageUrl = @ImageUrl WHERE PostId = @PostId", connection);
                command.Parameters.AddWithValue("@PostId", postId);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Body", body);
                command.Parameters.AddWithValue("@ImageUrl", imageUrl);
                command.ExecuteNonQuery();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int userId = 1; // Set the UserId here or get it from the session.
            string title = txtTitle.Text.Trim();
            string body = txtBody.Text.Trim();
            string imageUrl = string.Empty;

            if (fuImage.HasFile)
            {
                string imageFolderPath = Server.MapPath("~/Images");
                if (!Directory.Exists(imageFolderPath))
                {
                    Directory.CreateDirectory(imageFolderPath);
                }
                string fileName = Path.GetFileName(fuImage.PostedFile.FileName);
                string filePath = Path.Combine(imageFolderPath, fileName);
                fuImage.PostedFile.SaveAs(filePath);
                imageUrl = "/Images/" + fileName;
            }

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(body))
            {
                SavePost(userId, title, body, imageUrl);
                LoadPosts();
                ClearForm();
            }
        }
        protected void grdPosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPosts.EditIndex = e.NewEditIndex;
            LoadPosts();
        }
        protected void grdPosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int postId = Convert.ToInt32(grdPosts.DataKeys[e.RowIndex].Value);
            int userId = 1; // Set the UserId here or get it from the session.

            TextBox txtTitle = grdPosts.Rows[e.RowIndex].FindControl("txtTitle") as TextBox;
            TextBox txtBody = grdPosts.Rows[e.RowIndex].FindControl("txtBody") as TextBox;
            FileUpload fuImage = grdPosts.Rows[e.RowIndex].FindControl("fuImage") as FileUpload;

            if (fuImage.HasFile)
            {
                string imageFolderPath = Server.MapPath("~/Images");
                if (!Directory.Exists(imageFolderPath))
                {
                    Directory.CreateDirectory(imageFolderPath);
                }
                string fileName = Path.GetFileName(fuImage.PostedFile.FileName);
                string filePath = Path.Combine(imageFolderPath, fileName);
                fuImage.PostedFile.SaveAs(filePath);
                string imageUrl = "/Images/" + fileName;

                UpdatePost(postId, userId, txtTitle.Text.Trim(), txtBody.Text.Trim(), imageUrl);
            }
            else
            {
                string existingImageUrl = (grdPosts.Rows[e.RowIndex].FindControl("lblImageUrl") as Label).Text;
                UpdatePost(postId, userId, txtTitle.Text.Trim(), txtBody.Text.Trim(), existingImageUrl);
            }

            grdPosts.EditIndex = -1;
            LoadPosts();
        }

        protected void grdPosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int postId = Convert.ToInt32(grdPosts.DataKeys[e.RowIndex].Value);
            DeletePost(postId);
            LoadPosts();
        }

        protected void grdPosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upvote" || e.CommandName == "Downvote")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int postId = Convert.ToInt32(grdPosts.DataKeys[rowIndex].Value);
                int userId = 1; // Set the UserId here or get it from the session.
                string reactionType = e.CommandName == "Upvote" ? "upvote" : "downvote";

                SaveReaction(postId, userId, reactionType);
                LoadPosts(); // Refresh the posts after reacting
            }
            // ...
        }
        protected void grdPosts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPosts.EditIndex = -1;
            LoadPosts();
        }
        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)(((Control)sender).NamingContainer)).RowIndex;
            int postId = Convert.ToInt32(grdPosts.DataKeys[rowIndex].Value);
            int userId = 1; // Set the UserId here or get it from the session.
            TextBox txtComment = grdPosts.Rows[rowIndex].FindControl("txtComment") as TextBox;
            string commentContent = txtComment.Text.Trim();

            SaveComment(postId, userId, commentContent);
            LoadPosts(); // Refresh the posts after adding a comment
        }
        protected void fuImage_Uploaded(object sender, EventArgs e)
        {
            if (fuImage.HasFile)
            {
                string fileName = Path.GetFileName(fuImage.PostedFile.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                fuImage.PostedFile.SaveAs(filePath);
                imgPreview.ImageUrl = "~/Images/" + fileName;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPosts();
            }
        }
    }
}
