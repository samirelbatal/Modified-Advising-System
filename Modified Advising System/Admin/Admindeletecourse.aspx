<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admindeletecourse.aspx.cs" Inherits="Modified_Advising_System.Admindeletecourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
        }

        form {
            max-width: 400px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        #form1 div {
            text-align: center;
            margin-bottom: 20px;
        }

        #form1 input[type="text"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #form1 .delete-button {
            padding: 12px 20px;
            font-size: 16px;
            background-color: #e74c3c; /* Red color */
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #form1 .delete-button:hover {
            background-color: #c0392b;
        }

        #form1 .dashboard-button {
            padding: 12px 20px;
            font-size: 16px;
            background-color: #3498db; /* Blue color */
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #form1 .dashboard-button:hover {
            background-color: #2980b9;
        }

        #form1 .message {
            font-size: 20px;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter course ID:<br />
            <asp:TextBox ID="courseid" runat="server" CssClass="textbox"></asp:TextBox>
            <br/>
            <asp:Button ID="Button1" runat="server" OnClick="delete" Text="Delete Course" CssClass="delete-button"/>

            <br/>
            <br/>
            <asp:Button ID="Button2" runat="server" OnClick="back" Text="Go Back To DashBoard" CssClass="dashboard-button" /> 
            <br/>
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
