<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requests.aspx.cs" Inherits="Modified_Advising_System.requests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .center-content {
            margin: auto;
            width: 80%;
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

    <asp:ListView ID="ListView1" runat="server" DataKeyNames="request_id" DataSourceID="SqlDataSource1">
        <LayoutTemplate>
            <table runat="server" class="center-content" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;padding:40px;">
                <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                    <th runat="server">student_id</th>
                    <th runat="server">request_id</th>
                    <th runat="server">type</th>
                    <th runat="server">comment</th>
                    <th runat="server">status</th>
                    <th runat="server">credit_hours</th>
                    <th runat="server">course_id</th>
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
                    <asp:Label ID="request_idLabel" runat="server" Text='<%# Eval("request_id") %>' />
                </td>
                <td>
                    <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>' />
                </td>
                <td>
                    <asp:Label ID="commentLabel" runat="server" Text='<%# Eval("comment") %>' />
                </td>
                <td>
                    <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' />
                </td>
                <td>
                    <asp:Label ID="credit_hoursLabel" runat="server" Text='<%# Eval("credit_hours") %>' />
                </td>
                <td>
                    <asp:Label ID="course_idLabel" runat="server" Text='<%# Eval("course_id") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Advising_Management_System %>" SelectCommand="SELECT DISTINCT [student_id], [request_id], [type], [comment], [status], [credit_hours], [course_id] FROM [Request] WHERE ([advisor_id] = @advisor_id)">
        <SelectParameters>
            <asp:SessionParameter Name="advisor_id" SessionField="user" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">

</body>
</html>
