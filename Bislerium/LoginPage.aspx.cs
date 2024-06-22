using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Bislerium
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private const string UserConnectionString = "Data Source=MARK1\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;";
        private const string AdminConnectionString = "Data Source=MARK1\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Hash the password using a secure password hashing algorithm
            string hashedPassword = HashPassword(password);

            // Check user credentials against the Users table using a parameterized query
            using (SqlConnection connection = new SqlConnection(UserConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Successful user login, redirect to home page
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        // Display error message for user login (optional)
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Invalid email or password.');", true);
                    }
                }
            }
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string adminUsername = txtAdminUsername.Text;

            // Check admin username against the Admins table using a parameterized query
            using (SqlConnection connection = new SqlConnection(AdminConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", adminUsername);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Successful admin login, redirect to admin page
                        Response.Redirect("~/Admin.aspx");
                    }
                    else
                    {
                        // Display error message for admin login (optional)
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Invalid admin username.');", true);
                    }
                }
            }
        }

        // Method to securely hash the password using a secure password hashing algorithm
        private string HashPassword(string password)
        {
            using (Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
            {
                return Convert.ToBase64String(hasher.GetBytes(20));
            }
        }
    }
}