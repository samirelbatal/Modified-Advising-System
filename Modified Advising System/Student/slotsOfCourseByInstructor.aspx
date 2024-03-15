<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slotsOfCourseByInstructor.aspx.cs" Inherits="Modified_Advising_System.slotsOfCourseByInstructor" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Instructor Slot Schedule</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(to right, #3498db, #2ecc71);
            margin: 0;
            padding: 20px;
        }

        #form1 {
            text-align: center;
            position: relative;
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

        #Label2 {
            font-size: 28px;
            font-weight: bold;
            color: #fff;
            margin-top: 20px;
        }

        .form-group {
            margin: 20px 0;
        }

        .form-group label {
            font-size: 18px;
            color: #fff;
            display: inline-block;
            margin-right: 10px;
            width: 120px;
        }

        .dropdown-container {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 10px;
        }

        .dropdown-list {
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-right: 10px;
            width: 150px;
        }

        #btnViewSlots {
            background-color: #2ecc71;
            color: white;
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin-top: 10px;
        }

        #btnViewSlots:hover {
            background-color: #27ae60;
        }

        #GridView1 {
            width: 80%;
            margin: auto;
            background-color: #fff;
            color: #333;
            border-collapse: collapse;
            margin-top: 20px;
        }

        #GridView1 th,
        #GridView1 td {
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
        <div id="Label2">Course Instructor Slot Schedule</div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Semester Code"></asp:Label>
            <asp:TextBox ID="semesterCode" runat="server"></asp:TextBox>
        </div>
        <div class="dropdown-container">
            <asp:Label ID="lblCourse" runat="server" Text="Select Course:"></asp:Label>
            <asp:DropDownList ID="ddlCourses" runat="server" AppendDataBoundItems="True" DataTextField="name"  AutoPostBack="true" DataValueField="name" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged" CssClass="dropdown-list">
                <asp:ListItem Text="-- Select Course --" Value="" />
            </asp:DropDownList>

            <asp:Label ID="Label1" runat="server" Text="Select Instructor:"></asp:Label>
            <asp:DropDownList ID="ddlInstructors" runat="server" AppendDataBoundItems="True" DataTextField="name" DataValueField="name" CssClass="dropdown-list">
                <asp:ListItem Text="-- Select Instructor --" Value="" />
            </asp:DropDownList>
        </div>

        <asp:Button ID="btnViewSlots" runat="server" Text="View Slots" OnClick="btnViewSlots_Click" />
        <hr />

        <!-- Display the results in a GridView -->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Slot ID" HeaderText="Slot ID" SortExpression="Slot ID" />
                <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
                <asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" />
                <asp:BoundField DataField="day" HeaderText="Day" SortExpression="day" />
                <asp:BoundField DataField="Course name" HeaderText="Course Name" SortExpression="Course name" />
                <asp:BoundField DataField="Instructor name" HeaderText="Instructor Name" SortExpression="Instructor name" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
