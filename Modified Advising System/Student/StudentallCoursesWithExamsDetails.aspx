<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentallCoursesWithExamsDetails.aspx.cs" Inherits="Modified_Advising_System.StudentallCoursesWithExamsDetails" %>


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
        #GridView1 {
            width: 80%;
            margin: auto;
            background-color: #fff;
            color: #333;
            border-collapse: collapse;
            margin-top: 20px;
        }

        #GridView1 th, #GridView1 td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        #GridView1 th {
            background-color: #3498db;
            color: #fff;
            font-weight: bold;
        }
        .gridview-style {
            width: 80%;
            margin: auto;
            background-color: #fff;
            color: #333;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .gridview-style th,
        .gridview-style td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        .gridview-style th {
            background-color: #3498db;
            color: #fff;
            font-weight: bold;
        }

         #GridViewCoursesMakeupExams {
            margin-bottom: 100px;
         }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="All Courses With Exam Details"></asp:Label>
        <!-- Add your content for the new page here -->
        <br />
        <br />
<asp:GridView ID="GridViewCoursesMakeupExams" runat="server" AutoGenerateColumns="False" DataKeyNames="exam_id" CssClass="gridview-style">
    <Columns>
        <asp:BoundField DataField="name" HeaderText="Course Name" SortExpression="name" />
        <asp:BoundField DataField="semester" HeaderText="Course Semester" SortExpression="semester" />
        <asp:BoundField DataField="exam_id" HeaderText="Exam ID" SortExpression="exam_id" />
        <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
        <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
    </Columns>
</asp:GridView>  </form>
</body>
</html>

