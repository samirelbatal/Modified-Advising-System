<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentslotsOfCourseByInstructor.aspx.cs" Inherits="Modified_Advising_System.StudentslotsOfCourseByInstructor" %>


<!DOCTYPE html>
<html>
    <head runat="server">
    <title>Other Page</title>
<style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background: #999;
        margin: 0;
        padding: 20px;
    }

    #form1 {
        text-align: center;
        position: relative;
    }

    #Label2 {
        font-size: 28px;
        font-weight: bold;
        color: #fff;
        margin-top: 20px;
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

    #lblCourse,
    #Label1 {
        font-size: 18px;
        color: #fff;
        margin-top: 20px;
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
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Course Instructor Slot Schedule"></asp:Label>
        <br />
        <br />
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
         <br />
        <asp:Button ID="btnViewSlots" runat="server" Text="View Slots" OnClick="btnViewSlots_Click" />
        <hr />

        <!-- Display the results in a GridView -->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="slot_id" HeaderText="Slot ID" SortExpression="slot_id" />
                <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
                <asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" />
                <asp:BoundField DataField="day" HeaderText="Day" SortExpression="day" />
                <asp:BoundField DataField="Course" HeaderText="Course Name" SortExpression="Course" />
                <asp:BoundField DataField="Instructor" HeaderText="Instructor Name" SortExpression="Instructor" />
            </Columns>
        </asp:GridView>
        </form>

</html>