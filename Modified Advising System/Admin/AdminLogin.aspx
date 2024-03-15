<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Modified_Advising_System.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(to bottom right, #3498db, #2c3e50); /* Gradient background */
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        #form1 {
            background-color: rgba(255, 255, 255, 0.8); /* Adjust the background color and opacity */
            border-radius: 8px;
            box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.1);
            padding: 40px;
            width: 300px;
            text-align: center;
            transition: transform 0.3s ease-in-out;
        }

        .title {
            font-size: 36px;
            font-weight: bold;
            color: #2980b9; /* White color for contrast with the background */
            margin-bottom: 20px;
        }

        .input-group {
            margin-bottom: 20px;
            position: relative;
        }

        .input-group input {
            width: 100%;
            padding: 12px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            transition: border-color 0.3s ease-in-out;
        }

        .input-group input:focus {
            outline: none;
            border-color: #3498db;
        }

        .input-group label {
            position: absolute;
            top: 50%;
            left: 12px;
            transform: translateY(-50%);
            font-size: 16px;
            color: #999;
            pointer-events: none;
            transition: transform 0.3s ease-in-out, font-size 0.3s ease-in-out;
        }

        .input-group input:focus + label, .input-group input:not(:placeholder-shown) + label {
            transform: translateY(0%) scale(0);
            font-size: 12px;
            color: #3498db;
        }

        .btn-login {
            background-color: #3498db;
            color: #fff;
            padding: 12px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease-in-out;
        }

        .btn-login:hover {
            background-color: #2980b9;
        }

        .form-footer {
            margin-top: 20px;
            font-size: 14px;
            color: #666;
        }

        .form-footer a {
            color: #3498db;
            text-decoration: none;
        }

        .form-footer a:hover {
            text-decoration: underline;
        }
        #lblMessage {
            margin-top: 10px;
            display: block;
            color: #5cb85c; /* Success color */
            text-align: center;
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
    <form id="form1" runat="server">
        <div>

            <div class="title">Admin Login</div>
            <asp:Button ID="button3" runat="server" OnClick="choose" Text="Switch User" CssClass="switch-user-button"></asp:Button>

            <div class="input-group">
                <asp:TextBox placeholder=" " ID="USERNAME" runat="server"></asp:TextBox>
                <label for="TextBox1">ID</label>
            </div>

            <div class="input-group">
                <asp:TextBox placeholder=" " TextMode="Password" ID="PASSWORD" runat="server"></asp:TextBox>
                <label for="TextBox2">Password</label>
            </div>

            <asp:Button ID="Button1" CssClass="btn-login" OnClick="Login" runat="server" Text="Login" />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

            <!--<div class="form-footer">
                <p>Forgot your password? <a href="AdminResetPassword.aspx">Reset here</a>.</p>
            </div> -->
        </div>
    </form>
</body>
</html>