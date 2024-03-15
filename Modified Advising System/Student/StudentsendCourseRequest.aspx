<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsendCourseRequest.aspx.cs" Inherits="Modified_Advising_System.StudentsendCourseRequest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send Course Request</title>
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

        #sendCourseRequestTitle {
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

        .message {
            font-size: 25px;
            font-weight: bold;
            position: absolute;
            top: 280px;
            left: 50%;
            transform: translateX(-50%);
        }

        .dashboard-button:hover {
            background-color: #c0392b;
        }

        .input-field {
            font-size: 16px;
            padding: 8px;
            margin-bottom: 10px;
        }

        .send-request-button {
            background-color: #3498db;
            color: white;
            padding: 8px 16px;
            font-size: 14px;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .send-request-button:hover {
            background-color: #2980b9;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <div id="sendCourseRequestTitle">Send Course Request</div>
        <br />
        <asp:Label ID="LabelCourseID" runat="server" Text="Course ID"></asp:Label>
        <asp:TextBox ID="TextBoxCourseID" runat="server" CssClass="input-field" placeholder="Enter Course ID"></asp:TextBox>
        <br />
        <asp:Label ID="LabelComment" runat="server" Text="Comment"></asp:Label>
        <asp:TextBox ID="TextBoxComment" runat="server" CssClass="input-field" placeholder="Enter Comment"></asp:TextBox>
        <br />
        <asp:Button ID="SendRequestButton" runat="server" OnClick="SendRequestButton_Click" Text="Send Request" CssClass="send-request-button" />
        <br />
        <asp:Label ID="ErrorMessageLabel" runat="server" Text="" ForeColor="red" Visible="false" CssClass="message"></asp:Label>
        <br />
        <asp:Label ID="successMessageLabel" runat="server" Text="" ForeColor="green" Visible="false" CssClass="message"></asp:Label>
        <br />
        <!-- Add more elements as needed -->
    </form>
</body>
</html>
