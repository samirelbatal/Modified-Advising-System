<!-- viewAvailableCourses.aspx -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentviewAvailableCourses.aspx.cs" Inherits="Modified_Advising_System.StudentviewAvailableCourses" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Available Courses</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: #999;
            margin: 0;
            text-align: center;
        }

        #form1 {
            position: relative;
            padding-top: 20px;
        }

        #availableCoursesTitle {
            font-size: 28px;
            font-weight: bold;
            color: #fff;
        }

        .dashboard-button {
            background-color: #e74c3c;
            color: white;
            padding: 8px 16px;
            font-size: 14px;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
            position: absolute;
            top: 10px;
            left: 10px;
        }

        .dashboard-button:hover {
            background-color: #c0392b;
        }

        .semester-code-input {
            font-size: 16px;
            padding: 8px;
            margin-bottom: 10px;
        }

        .get-courses-button {
            background-color: #3498db;
            color: white;
            padding: 8px 16px;
            font-size: 14px;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .get-courses-button:hover {
            background-color: #2980b9;
        }

        .message {
            font-size: 18px;
            font-weight: bold;
            color: #fff;
            margin-top: 20px;
        }

        table {
            margin: 20px auto;
            border-collapse: collapse;
            width: 40%;
        }

        th, td {
            padding: 10px;
            text-align: center;
            border: 1px solid #ddd;
            background-color: #fff; /* Blue header background */
            color: #000; /* White text */
        }

        th {
            background-color: #2980b9; /* Darker blue header background */
            font-weight: bold;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <div id="availableCoursesTitle">Available Courses</div>
        <br />
        <div>
            <asp:TextBox ID="SemesterCodeTextBox" runat="server" CssClass="semester-code-input" placeholder="Enter Semester Code"></asp:TextBox>
            <asp:Button ID="GetAvailableCoursesButton" runat="server" OnClick="GetAvailableCoursesButton_Click" Text="Get Available Courses" CssClass="get-courses-button" />
        </div>
        <br />
        <asp:Literal ID="AvailableCoursesLiteral" runat="server"></asp:Literal>
        <br />
        <br />
        <!-- Add more elements as needed -->
    </form>
</body>
</html>
