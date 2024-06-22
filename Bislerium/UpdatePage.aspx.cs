using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bislerium
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void btnChangeUsername_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Data Source=MARK1\\\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;"].ConnectionString;

            string newUsername = txtNewUsername.Text;
            string username = Session["Username"].ToString(); // Assuming you store the username in a session variable

            // Check if the new username is available
            if (!IsUsernameAvailable(connectionString, newUsername))
            {
                // New username is not available
                // You can display an error message
                // Example: lblMessage.Text = "The entered username is already taken.";
                return;
            }

            // Update username in the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Example SQL command to update username (replace placeholders with actual column names and table name)
                    string query = "UPDATE Users SET Username = @NewUsername WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewUsername", newUsername);
                    command.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Username updated successfully
                        // You can display a success message or redirect the user to another page
                    }
                    else
                    {
                        // Username update failed
                        // You can display an error message
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // You can display an error message or log the exception
            }
        }

        private bool IsUsernameAvailable(string connectionString, string username)
        {
            // Query the database to check if the new username is available
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Example SQL command to check if username exists (replace placeholders with actual column names and table name)
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    int count = (int)command.ExecuteScalar();

                    // If count is 0, username is available; otherwise, it's already taken
                    return count == 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // You can display an error message or log the exception
            }

            return false;
        }
        protected void btnChangeEmail_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Data Source=MARK1\\\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;"].ConnectionString;

            string newEmail = txtNewEmail.Text;
            string username = Session["Username"].ToString(); // Assuming you store the username in a session variable

            // Check if the new email matches the registered email for the user
            if (!IsRegisteredEmail(connectionString, username, newEmail))
            {
                // New email doesn't match the registered email for the user
                // You can display an error message
                // Example: lblMessage.Text = "The entered email doesn't match your registered email.";
                return;
            }

            // Update email in the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Example SQL command to update email (replace placeholders with actual column names and table name)
                    string query = "UPDATE Users SET Email = @NewEmail WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewEmail", newEmail);
                    command.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Email updated successfully
                        // You can display a success message or redirect the user to another page
                    }
                    else
                    {
                        // Email update failed
                        // You can display an error message
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // You can display an error message or log the exception
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Add code here to handle changing the password
        }

        private bool IsRegisteredEmail(string connectionString, string username, string email)
        {
            // Query the database to check if the provided email matches the registered email for the user
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Example SQL command to retrieve registered email (replace placeholders with actual column names and table name)
                    string query = "SELECT Email FROM Users WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string registeredEmail = reader["Email"].ToString();

                            // Compare the provided email with the registered email
                            if (email == registeredEmail)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // You can display an error message or log the exception
            }

            return false;
        }
    }
}
