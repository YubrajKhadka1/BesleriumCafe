using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Bislerium
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Hash the password using a secure hash algorithm like SHA256
            string hashedPassword = HashPassword(password);

            // Insert user data into the database with hashed password
            string connectionString = "Data Source=MARK1\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, PasswordHash, Email) VALUES (@Username, @PasswordHash, @Email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", name);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Redirect to login page after successful registration
            Response.Redirect("~/LoginPage.aspx");
        }

        // Method to securely hash the password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from the password bytes
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert hash bytes to string representation (hexadecimal)
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
