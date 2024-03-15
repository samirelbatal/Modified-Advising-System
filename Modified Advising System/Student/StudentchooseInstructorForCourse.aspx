<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentchooseInstructorForCourse.aspx.cs" Inherits="Modified_Advising_System.chooseInstructorForCourse" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Other Page</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: #999; /* Gradient background */
            margin: 0; /* Remove default margin to avoid spacing issues */
        }

        #form1 {
            text-align: center; /* Center the content within the form */
            padding-top: 20px; /* Add some top padding for spacing */
            position: relative; /* Make the form a positioned container */
        }

        #Label2 {
            font-size: 28px; /* Increase the font size of the label */
            font-weight: bold; /* Make the font bold */
            color: #fff; /* Set text color to white */
        }

        .dashboard-button {
            background-color: #e74c3c; /* Red background color for buttons */
            color: white; /* White text color */
            padding: 8px 16px; /* Adjust padding for a smaller size */
            font-size: 14px; /* Adjust font size */
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease; /* Add a smooth transition effect */
            position: absolute; /* Position the button absolutely */
            top: 10px;
            left: 10px;
        }

        .dashboard-button:hover {
            background-color: #c0392b; /* Darker red on hover */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Other Page"></asp:Label>
        <!-- Add your content for the new page here -->
        <br />
        <br />
        <!-- Add more elements as needed -->
    </form>
</body>
</html>

