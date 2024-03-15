<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chooseUser.aspx.cs" Inherits="Modified_Advising_System.chooseUser" %>


<!DOCTYPE html>
        <link rel="stylesheet" type="text/css" href="styles.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

  


<link rel="stylesheet" href="https://pro.fontawesome.com/releases/v6.0.0-beta1/css/all.css" integrity="..." crossorigin="anonymous" />

<form id="form1" runat="server" class="special-width">
    <div>
        Login as
    </div>

    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="login-link" NavigateUrl="Student\StudentLogin.aspx">
         Student    &nbsp;&nbsp;  <i class="fas fa-user-graduate"></i>
    </asp:HyperLink>

    <br />

    <asp:HyperLink ID="ViewStudentsLink" runat="server" CssClass="login-link" NavigateUrl="Advisor\login.aspx">
         Advisor  &nbsp;&nbsp;    <i class="fas fa-chalkboard-teacher"></i>
    </asp:HyperLink>
    <br />
    
    <asp:HyperLink ID="ViewRequestsLink" runat="server" CssClass="login-link" NavigateUrl="Admin\AdminLogin.aspx">
         Admin   &nbsp;&nbsp;   <i class="fas fa-user-cog"></i>
    </asp:HyperLink>
    <br />
</form>



</body>
</html>