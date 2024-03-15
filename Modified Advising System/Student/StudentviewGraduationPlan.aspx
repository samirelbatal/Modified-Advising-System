<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentviewGraduationPlan.aspx.cs" Inherits="Modified_Advising_System.StudentviewGraduationPlan" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Other Page</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: #999; 
            margin: 0; /* Remove default margin to avoid spacing issues */
            color: #fff; /* Set default text color to white */
        }

        #form1 {
            text-align: center; /* Center the content within the form */
            padding-top: 20px; /* Add some top padding for spacing */
            position: relative; /* Make the form a positioned container */
        }

        #Label2 {
            font-size: 28px; /* Increase the font size of the label */
            font-weight: bold; /* Make the font bold */
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

        /* Style for GridView */
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Graduation Plan"></asp:Label>
        <!-- Add your content for the new page here -->
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student ID" SortExpression="student_id" />
                    <asp:BoundField DataField="student_name" HeaderText="Student Name" SortExpression="student_name" />
                    <asp:BoundField DataField="plan_id" HeaderText="Plan ID" SortExpression="plan_id" />
                    <asp:BoundField DataField="semester_code" HeaderText="Semester Code" SortExpression="semester_code" />
                    <asp:BoundField DataField="semester_credit_hours" HeaderText="Semester Credit Hours" SortExpression="semester_credit_hours" />
                    <asp:BoundField DataField="expected_grad_date" HeaderText="Expected Graduation Date" SortExpression="expected_grad_date" />
                    <asp:BoundField DataField="advisor_id" HeaderText="Advisor ID" SortExpression="advisor_id" />
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
                    <asp:BoundField DataField="name" HeaderText="Course Name" SortExpression="name" />
                </Columns>

            </asp:GridView>
        </div>
        <br />
   
    </form>
</body>
</html>
