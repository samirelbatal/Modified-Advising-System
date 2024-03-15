<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateGradPlan.aspx.cs" Inherits="Modified_Advising_System.UpdateGradPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <div class="sidebar">
      <a href="dashboard.aspx"><i class="fas fa-Home"></i> Dashboard</a>
       <a href="allstudents.aspx"><i class="fas fa-users"></i> View all students</a>
       <a href="students.aspx"><i class="fas fa-user-graduate"></i> View students by major</a>
       <a href="requests.aspx"><i class="fas fa-file-alt"></i> View all requests</a>
       <a href="pendingrequests.aspx"><i class="fas fa-exclamation-circle"></i> View pending requests</a>
       <a href="CreateGradPlan.aspx"><i class="fas fa-clipboard-check"></i> Create graduation plan</a>
       <a href="UpdateGradPlan.aspx"><i class="fas fa-edit"></i> Update graduation plan</a>

    <div class="sublist">
        <ul>
            <li><a href="InsertCourse.aspx"><i class="fas fa-plus"></i> Insert Course</a></li>
       <li><a href="UpdateDate.aspx"><i class="fas fa-calendar-alt"></i> Update Expected Graduation Date</a></li>
       <li><a href="DeleteCourse.aspx"><i class="fas fa-trash"></i> Delete Course</a></li>
        </ul>
    </div>
</div>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:HyperLink ID="HyperLink2" runat="server" Text="Insert course" NavigateUrl="InsertCourse.aspx"  />

        </div>
        <p>

                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Update expected graduation date" NavigateUrl="updatedate.aspx" />

                    </p>
        <p>

                    <asp:HyperLink ID="HyperLink3" runat="server" Text="Delete course " NavigateUrl="deletecourse.aspx"  />

        </p>
    </form>
        <link rel="stylesheet" type="text/css" href="styles.css" />
          <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">

</body>
</html>
