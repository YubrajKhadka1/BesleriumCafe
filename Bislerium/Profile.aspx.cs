using System;
using System.Data.SqlClient;

namespace UserProfileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "\"Data Source=MARK1\\\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;"; 

            int userIdToDelete = 123; 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // users table is named "Users" and has a column named "UserID"
                    string deleteCommand = "DELETE FROM Users WHERE UserID = @UserId";

                    using (SqlCommand command = new SqlCommand(deleteCommand, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userIdToDelete);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("User profile deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User profile with the specified ID was not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
