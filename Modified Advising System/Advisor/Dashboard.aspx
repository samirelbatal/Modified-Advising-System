<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Modified_Advising_System.Dashboard" %>

<!DOCTYPE html>
        <link rel="stylesheet" type="text/css" href="styles.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
          <style>
       
        #form1 div {
    font-size: 25px;
    word-spacing: 5px;
    padding-bottom:7px;
}
    </style>
    <title></title>
</head>
<body>

  


    <form id="form1" runat="server">
        <div>
            Dashboard
        </div>

        <asp:HyperLink ID="HyperLink2" runat="server" Text="View all students" NavigateUrl="allstudents.aspx" OnClick="ViewAllStudents_Click" />

        <br />

        <asp:HyperLink ID="ViewStudentsLink" runat="server" Text="View all students from certain major" NavigateUrl="students.aspx" OnClick="ViewStudents_Click" />
        <br />
        <asp:HyperLink ID="ViewRequestsLink" runat="server" Text="View all requests" NavigateUrl="requests.aspx" OnClick="ViewRequests_Click" />
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" Text="View all pending requests" NavigateUrl="pendingrequests.aspx" OnClick="ViewRequests_Click" />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Text="Create graduation plan " NavigateUrl="CreateGradPlan.aspx" OnClick="ViewRequests_Click" />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" Text="Update graduation plan" NavigateUrl="UpdateGradPlan.aspx" OnClick="ViewRequests_Click" />
        <br />
<asp:HyperLink ID="SignOutLink" runat="server" Text="Sign Out" NavigateUrl="login.aspx" style="background-color: #fff; color: #000; padding: 10px 15px; border: none; border-radius: 4px; cursor: pointer; margin-top: 20px; transition: background-color 0.3s ease;" />



    </form>

</body>
</html>
