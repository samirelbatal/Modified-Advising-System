<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="Modified_Advising_System.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GUC Advising Students System</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-image: url('background.jpg'); 
            background-size: cover;
            background-repeat: no-repeat;
            text-align: center;
            margin-top: 50px;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
        }

        #form1 {
            width: 300px;
            background-color: rgba(255, 255, 255);
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        #Label1 {
            font-size: 28px; /* Increase the font size */
            font-weight: bold;
            color: #000; /* Set text color to black */
        }

        #Label2 {
            font-weight: bold;
            color: #333; /* Set a slightly darker text color */
        }

        #username,
        #password {
            width: 100%;
            padding: 8px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #Button1 {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50; /* Green background color for the button */
            color: #fff; /* White text color */
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        #Button1:hover {
            background-color: #45a049; /* Darker green on hover */
        }

        #HyperLink1 {
            text-decoration: none;
            color: #3498db; /* Blue text color for the hyperlink */
            display: block;
            margin-top: 10px;
            transition: color 0.3s;
        }

        #HyperLink1:hover {
            color: #2980b9; /* Darker blue on hover */
        }

        .error-message {
            color: #ff0000;
            margin-top: 5px;
        }

        .switch-user-button {
        position: absolute;
        top: 10px;
        left: 10px;
        text-decoration: none;
        background-color: #e74c3c; /* Red background color for the button */
        color: white; /* White text color */
        padding: 8px 16px;
        font-weight: bold;
        transition: color 0.3s;
        }

        .switch-user-button:hover {
            color: #c0392b;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server" onsubmit="return validateLoginForm()">
        <div>
            <asp:Button ID="button3" runat="server" OnClick="choose" Text="Switch User" CssClass="switch-user-button"></asp:Button>
            <asp:Label ID="Label1" runat="server" Text="GUC Advising System"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Student ID:"></asp:Label>
            <br />
            <asp:TextBox ID="username" runat="server" placeholder="Enter your ID"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
            <br />
            <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="login" Text="Login" />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="StudentSignup.aspx">Don't have an account? Sign Up</asp:HyperLink>
            <span id="emptyFieldError" class="error-message" style="font-weight: bold; margin-top: 10px;"></span>
            <span id="intFieldError" class="error-message" style="font-weight: bold; margin-top: 10px;"></span>
            <br />
            <br />
            <asp:Literal ID="invalidAuth" runat="server"></asp:Literal>
            <br />
        </div>
    </form>
</body>
</html>
