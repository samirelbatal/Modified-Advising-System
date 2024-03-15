<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allstudents.aspx.cs" Inherits="Modified_Advising_System.allstudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <style>   
table {
    width: 80%;
    margin: auto; /* Center the table horizontally */
    border-collapse: collapse;
}

th, td {
    padding: 10px;
    text-align: center; /* Center the text horizontally within table cells */
    border: 1px solid #ddd;
}

/* Optional: Add some styling for better visibility */
th {
    background-color: #f2f2f2;
}
</style>
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
        
<p>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</p>        
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="student_id" DataSourceID="SqlDataSource1">
        <LayoutTemplate>
            <table runat="server" class="center-content" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                    <th runat="server">student_id</th>
                    <th runat="server">f_name</th>
                    <th runat="server">l_name</th>
                    <th runat="server">gpa</th>
                    <th runat="server">faculty</th>
                    <th runat="server">major</th>
                    <th runat="server">semester</th>
                    <th runat="server">acquired_hours</th>
                    <th runat="server">assigned_hours</th>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr style="background-color: #FFFBD6;color: #333333;">
                <td>
                    <asp:Label ID="student_idLabel" runat="server" Text='<%# Eval("student_id") %>' />
                </td>
                <td>
                    <asp:Label ID="f_nameLabel" runat="server" Text='<%# Eval("f_name") %>' />
                </td>
                <td>
                    <asp:Label ID="l_nameLabel" runat="server" Text='<%# Eval("l_name") %>' />
                </td>
                <td>
                    <asp:Label ID="gpaLabel" runat="server" Text='<%# Eval("gpa") %>' />
                </td>
                <td>
                    <asp:Label ID="facultyLabel" runat="server" Text='<%# Eval("faculty") %>' />
                </td>
                <td>
                    <asp:Label ID="majorLabel" runat="server" Text='<%# Eval("major") %>' />
                </td>
                <td>
                    <asp:Label ID="semesterLabel" runat="server" Text='<%# Eval("semester") %>' />
                </td>
                <td>
                    <asp:Label ID="acquired_hoursLabel" runat="server" Text='<%# Eval("acquired_hours") %>' />
                </td>
                <td>
                    <asp:Label ID="assigned_hoursLabel" runat="server" Text='<%# Eval("assigned_hours") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Advising_Management_System %>" SelectCommand="SELECT [student_id], [f_name], [l_name], [gpa], [faculty], [major], [semester], [acquired_hours], [assigned_hours] FROM [Student] WHERE ([advisor_id] = @advisor_id)">
        <SelectParameters>
            <asp:SessionParameter Name="advisor_id" SessionField="user" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
          <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">

</body>
</html>
