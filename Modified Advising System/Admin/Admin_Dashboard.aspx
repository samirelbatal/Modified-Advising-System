<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Dashboard.aspx.cs" Inherits="Modified_Advising_System.Admin_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
         body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-color: #2c3e50; /* Dark Blue-Gray */
    margin: 0;
    padding: 0;
}

form {
    max-width: 600px;
    margin: 50px auto;
    background-color: #fff;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

#form1 div {
    text-align: center;
    margin-bottom: 20px;
}

.but {
    background-color: #3498db; /* Dodger Blue */
    color: #fff;
    cursor: pointer;
    padding: 10px;
    width: 350px;
    font-weight: bold;
    opacity: 1;
    transition: opacity 0.5s;
    border-radius: 4px;
}

.text {
    font-size: 50px;
    color: #0094ff;
    margin-top: 30px;
    display: inline-block;
}

.but:hover {
    opacity: 0.8;
}

.but:active {
    opacity: 0.6;
}

.butdiv {
    margin-top: 5%;
}

.signout-button {
    background-color: #e74c3c; /* Alizarin Red */
    color: #fff;
    padding: 15px 20px;
    border: none;
    border-radius: 5px;
    font-size: larger;
    cursor: pointer;
    position: absolute;
    top: 10px;
    left: 10px;
    transition: background-color 0.5s;
}

.signout-button:hover {
    background-color: #c0392b; /* Pomegranate Red */
}

.signout-button:active {
    opacity: 0.6;
}

    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div>
            <asp:Button class="signout-button" ID="SignoutButton" runat="server" Text="Sign Out" OnClick="AdminSignout" />
              <br>
             <div class="text">The Admin System</div>

          </div>


        <div class="butdiv">
                     <asp:Button class="but" ID="Button1" runat="server" Text="View advisors" OnClick="AdminListAdvisors" />
                 <p>
                     <asp:Button class="but" ID="Button2" runat="server" Text="View Students with their Advisors" OnClick="AdminListStudentsWithAdvisors"  />
                 </p>
                 <p>
                     <asp:Button class="but" ID="Button3" runat="server" Text="View pending requests" OnClick="AdminListsPendingRequests" />
                 </p>
                 <p>
                     <asp:Button class="but" ID="Button4" runat="server" Text="Add a new semester." onclick="AdminAddingSemester" />
                 </p>
                 <p>
                     <asp:Button class="but" ID="Button5" runat="server" Text="Add a new course." OnClick="AdminAddingCourse" />
                 </p>
                 <p>
                     <asp:Button class="but" ID="Button6" runat="server" Text="Assign Instructor to a Slot" OnClick="AdminLinkInstructor" />
                 </p>
                 <p>
                     <asp:Button class="but" ID="Button7" runat="server" Text="Assign Advisor to a Student" onclick="AdminLinkStudentToAdvisor" />
                 </p>
                 <p>
                  <asp:Button class="but" ID="Button8" runat="server" Text="Assign a Instructor to a Student" OnClick="AdminLinkStudentToInstructor" />
                 </p>
                 <p>
                 <asp:Button class="but" ID="Button9" runat="server" Text="View Instructors with their assigned courses" onclick="AdminViewInstructorWithAssignedCourses" />
                  </p>
                 <p>
                <asp:Button class="but" ID="Button10" runat="server" Text="View semesters  with their offered courses" onclick="AdminViewSemestersWithOfferedCourses" />
                 </p>
                 <p>
                 <asp:Button class="but" ID="Button11" runat="server" Text="Delete a course" onclick="AdminDeleteCourse" />
                 </p>
                 <p>
                 <asp:Button class="but" ID="Button12" runat="server" Text="Delete a slot of a certain course" onclick="AdminDeleteSlot" />
                 </p>
                             <p>
                 <asp:Button class="but" ID="Button13" runat="server" Text=" Add Make Up exam " onclick="AdminAddMakeUpExam" />
                 </p>
                             <p>
                 <asp:Button class="but" ID="Button14" runat="server" Text=" View payments with corresponding students" onclick="AdminViewPayments" />
                 </p>
                             <p>
                 <asp:Button class="but" ID="Button15" runat="server" Text="Issue installments for a payment " onclick="AdminIssueInstallments" />
                 </p>
                             <p>
                 <asp:Button class="but" ID="Button16" runat="server" Text="Update a Student status based on financial status " onclick="AdminUpdateStudentStatus" />
                 </p>
                             <p>
                 <asp:Button class="but" ID="Button17" runat="server" Text="Fetch all details of active students" onclick="AdminFetchActiveStudents" />
                 </p>
                             <p>
                 <asp:Button class="but" ID="Button18" runat="server" Text="View Graduation Plan with their intiated advisors" onclick="AdminViewGraduationPlan" />
                 </p>
                             <p>
                 <asp:Button class="but" ID="Button19" runat="server" Text="View all students transcript details " onclick="AdminViewTranscriptDetails" />
                 </p>
 



        </div>
        
    </form>
</body>
</html>
