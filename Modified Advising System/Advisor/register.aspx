<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Modified_Advising_System.register" %>

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
width: 350px;
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

      Advisor registration
  </div>
<p>
    <asp:TextBox ID="name_reg" runat="server" Placeholder="Your Name"></asp:TextBox>
</p>

<p>
    <asp:TextBox ID="password_reg" runat="server" Placeholder="Choose a Password"></asp:TextBox>
</p>

<p>
    <asp:TextBox ID="email_reg" runat="server" Placeholder="Your Email"></asp:TextBox>
</p>


<p>
    <asp:TextBox ID="office_reg" runat="server" Placeholder="Your Office"></asp:TextBox>
</p>

            <asp:Button ID="Button1" runat="server" OnClick="Register" Text="Register" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </p>

        <p>
            <asp:Button ID="LoginButton" runat="server" OnClick="RedirectToLogin" Text="Already have an account? Sign in" />
        </p>
    </form>
</body>
</html>
