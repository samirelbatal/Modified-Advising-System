<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentregisterFirstMakeupExam.aspx.cs" Inherits="Modified_Advising_System.StudentregisterFirstMakeupExam" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Other Page</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: #999;
            margin: 0;
            padding: 20px;
            box-sizing: border-box;
            text-align: center;
        }

        #form1 {
            display: inline-block;
            text-align: left;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            max-width: 460px;
            margin: auto;
        }

        #Label2 {
            font-size: 28px;
            font-weight: bold;
            color: black;
            margin-bottom: 20px;
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

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            font-size: 16px;
            font-weight: bold;
            margin-bottom: 5px;
            color: #333;
        }

        .form-group input,
        .form-group select {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .form-group button {
            background-color: #3498db;
            color: dodgerblue;
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .form-group button:hover {
            background-color: #2980b9;
        }

        .result-message,
        .error-message {
            color: #333;
            text-align: center;
            font-weight: bold;
            margin-top: 15px;
        }
        .center {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 100%; /* Ensure it takes full height of the container */
        }

        .error-message {
            color: red;
        }
        .custom-button {
        background-color: #4CAF50;
        color: white;
        padding: 10px 20px;
        font-size: 16px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s ease;
        }

        .custom-button:hover {
            background-color: #45a049;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <div id="Label2">
            Student Register 1st Makeup Exam
        </div>
        <div class="form-group">
            <label for="ddlCourses">Select Course:</label>
            <asp:DropDownList ID="ddlCourses" runat="server" AppendDataBoundItems="True" DataTextField="name" DataValueField="name">
                <asp:ListItem Text="-- Select Course --" Value="" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="semsterCode">Semester Code:</label>
            <asp:TextBox ID="semsterCode" runat="server" placeholder="Enter Semester Code"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="IdRegisterFirstMakeup" runat="server" CssClass="custom-button" Text="Register First Makeup" OnClick="btnRegisterFirstMakeup_Click" />
        </div>
      <asp:Label ID="lblResult" runat="server" Text="" CssClass="center"></asp:Label>
        <div class="center">
            <div class="error-message" id="lblError"></div>
        </div>

    </form>
</body>
</html>

