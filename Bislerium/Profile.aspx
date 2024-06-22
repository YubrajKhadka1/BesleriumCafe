<!DOCTYPE html>
<html>
<head>
    <title>User Profile</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #e6ffed; 
            color: #333;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 600px;
            margin: 50px auto;
            background-color: #fff; 
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #1a751f; 
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            font-weight: bold;
        }
        .form-group input[type="text"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .btn {
            background-color: #1a751f;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .btn:hover {
            background-color: #005f1f; 
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>User Profile</h1>
        <div class="form-group">
            <label for="username">User Name:</label>
            <input type="text" id="username" name="username" value="John Doe">
        </div>
        <div class="form-group">
            <label for="email">Email:</label>
            <input type="text" id="email" name="email" value="john@example.com">
        </div>
        <div class="form-group">
            <button class="btn" onclick="updateProfile()">Update Profile</button>
            <button class="btn" onclick="deleteProfile()">Delete Profile</button>
        </div>
    </div>

    <
    <script>
        function updateProfile() {

            alert("Profile updated successfully!");
        }

        function deleteProfile() {
            
            if (confirm("Are you sure you want to delete your profile?")) {
                alert("Profile deleted successfully!");
                // Redirect to a confirmation page or logout
            }
        }
    </script>
</body>
</html>
