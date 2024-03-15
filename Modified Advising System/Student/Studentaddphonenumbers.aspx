<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Studentaddphonenumbers.aspx.cs" Inherits="Modified_Advising_System.Studentaddphonenumbers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Phone Number</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: #999;
            margin: 0;
        }

        #optionalCoursesTitle {
            font-size: 28px;
            font-weight: bold;
            color: #fff;
        }

        #form1 {
            text-align: center;
            padding-top: 20px;
            position: relative;
        }

        #Label2 {
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
            margin-top: 60px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <div id="optionalCoursesTitle">Add Phone Number</div>
        <br />
        <asp:TextBox ID="phonenumtext" runat="server" CssClass="semester-code-input" placeholder="Enter your Phone Number"></asp:TextBox>
        <asp:Button ID="addphoneButton" runat="server" OnClick="addphoneButton_Click" Text="Add Phone Number" CssClass="get-courses-button" />
        <br />
        <br />
        <p>
            &nbsp;</p>
        <p>
        <asp:Literal ID="errormessage" runat="server"></asp:Literal>
        </p>
    </form>
</body>
</html>
