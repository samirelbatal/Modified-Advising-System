<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentallCoursesWithSlotsAndInstructors.aspx.cs" Inherits="Modified_Advising_System.StudentallCoursesWithSlotsAndInstructors" %>

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

        #GridViewCourseSlotInstructor {
            width: 80%;
            margin: auto;
            background-color: #fff;
            color: #333;
            border-collapse: collapse;
            margin-top: 20px;
        }

        #GridViewCourseSlotInstructor th, #GridViewCourseSlotInstructor td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        #GridViewCourseSlotInstructor th {
            background-color: #3498db;
            color: #fff;
            font-weight: bold;
        }

        /* Added more margin at the bottom of the table */
        #GridViewCourseSlotInstructor {
            margin-bottom: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Course Slot Instructor Table"></asp:Label>
        <!-- Add your content for the new page here -->
        <br />
        <br />
            <asp:GridView ID="GridViewCourseSlotInstructor" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseID">
    <Columns>
        <asp:BoundField DataField="CourseID" HeaderText="Course ID" SortExpression="CourseID" />
        <asp:BoundField DataField="Course" HeaderText="Course Name" SortExpression="Course" />
        <asp:BoundField DataField="slot_id" HeaderText="Slot ID" SortExpression="slot_id" />
        <asp:BoundField DataField="day" HeaderText="Day" SortExpression="day" />
        <asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" />
        <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
        <asp:BoundField DataField="instructor_id" HeaderText="Instructor Id" SortExpression="instructor_id" />
        <asp:BoundField DataField="instructor" HeaderText="Instructor Name" SortExpression="instructor" />

    </Columns>
</asp:GridView>


    </form>
</body>
</html>

