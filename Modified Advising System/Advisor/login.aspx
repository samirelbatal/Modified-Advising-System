<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Modified_Advising_System.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
      <style>
        body {
            background-image: url('background.jpg');
            background-size: cover; /* Adjust as needed */
            background-repeat: no-repeat;
            background-attachment: fixed; /* Optional: Keeps the background fixed while scrolling */
        }
        #form1{
             max-width: 900px;
    width: 280px;
    height: 370px;
        }
        #form1 div {
    font-size: 30px;
    word-spacing: 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="advisorLogin">
    Advisor login
</div>

        <p>
    <asp:TextBox ID="id" runat="server" Placeholder="Enter your ID"></asp:TextBox>
</p>

<p>
 <asp:TextBox ID="password" runat="server" TextMode="Password" Placeholder="Enter your password"></asp:TextBox>
</p>
        <p>

            <asp:Button ID="Button1" runat="server" OnClick="Login" Text="Sign in" style="background-color: #4caf50; color: #fff; padding: 10px 15px; border: none; border-radius: 4px; cursor: pointer;" />
        </p>
         <p>
     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
 </p>

        <hr />

        <p>
<asp:Button ID="RegisterButton" runat="server" Text="Don't have an account? Sign up" OnClientClick="window.location.href='register.aspx'; return false;" CssClass="register-button" />
        </p

                <p>
<asp:Button ID="button9" runat="server" Text="Go back" OnClientClick="window.location.href='../chooseUser.aspx'; return false;" CssClass="register-button" />
        </p>
         
    </form>
</body>
</html>
