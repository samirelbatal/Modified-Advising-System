<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pendingrequests.aspx.cs" Inherits="Modified_Advising_System.pendingrequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
            <link rel="stylesheet" type="text/css" href="styles.css" />
              <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">

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
</head>
<body>
 <form id="form1" runat="server">
             <h2>Pending Requests</h2>
     <style>#form1 div {
    font-size: 20px;
    word-spacing: 5px;
}</style>
    <div style="max-height: 600px; overflow: auto;">
<asp:GridView ID="GridViewRequests" runat="server" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="request_id" HeaderText="Request ID" SortExpression="request_id" />
                    <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
                    <asp:BoundField DataField="comment" HeaderText="Comment" SortExpression="comment" />
                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                    <asp:BoundField DataField="credit_hours" HeaderText="Credit Hours" SortExpression="credit_hours" />
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
                    <asp:BoundField DataField="student_id" HeaderText="Student ID" SortExpression="student_id" />
                    <asp:TemplateField HeaderText="Action">
                     <ItemTemplate>
<asp:Button ID="handlerequest" runat="server" Text="Handle request" OnClick="handlerequest_Click" CommandArgument='<%# Eval("request_id") %>' CssClass="common-button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
