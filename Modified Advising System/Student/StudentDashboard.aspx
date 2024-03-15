<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="Modified_Advising_System.StudentDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: #999; /* Gradient background from light gray to dark gray */
            min-height: 150vh; /* Set a minimum height to fill the viewport */
            margin: 0; /* Remove default margin */
          
        }

        #header {
            position: absolute;
            top: 10px;
            left: 10px;
            font-size: 18px;
            font-weight: bold;
            color: #000; /* Black text color */
        }
        #container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: left;
        }

        #welcomeMessage {
            text-align: center;
            font-size: 24px;
            font-weight: bold;
            color: black;
            margin-top: 50px;
        }

        #dashboardSection {
            float: left;
            width: 240px;
            margin-top: 20px;
            text-align: center;
            margin-left: 20px;
        }

        .dashboard-button {
            display: block;
            width: 100%;
            height: auto; 
            background-color: #3498db;
            color: white;
            margin-bottom: 10px;
            text-align: center;
            text-decoration: none; /* Remove underline from links */
            line-height: 33px; /* Center text vertically */
            border: 1px solid #2980b9; /* Add border to buttons */
            border-radius: 5px; /* Add border-radius for rounded corners */
            transition: background-color 0.3s ease;
        }

        .dashboard-button:hover {
            background-color: #2980b9; /* Darker blue on hover */
        }

        #studentInfoForm {
            display: inline-block;
            text-align: right;
            width: 400px;
            margin-top: 90px;
            margin-left: 200px;
            font-weight: bold;
            color: #333;
        }

        .info-label {
            font-size: 16px;
            margin-bottom: 5px;
        }

        .info-value {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        #signOutButton {
            position: absolute;
            top: 10px;
            right: 10px;
            width: 100px;
            height: 33px;
            background-color: #e74c3c;
            color: white;
            text-align: center;
            line-height: 33px;
            border: 1px solid #c0392b;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

        #signOutButton:hover {
            background-color: #c0392b;
        }
    </style>
</head>
<body>
   
    <div id="header">The German University in Cairo</div>
    <div id="welcomeMessage" runat="server" style="font-weight: bold;"></div>
    
    <div id="dashboardSection">
        <label style="font-size: 24px; font-weight: bold; color: white; display: block; margin-bottom: 20px; text-shadow: 2px 2px 4px #000;">Dashboard Menu</label>


        
        
        <a class="dashboard-button" href="Studentaddphonenumbers.aspx">Add your Phone Number(s)</a>
        <a class="dashboard-button" href="StudentviewOptionalCourses.aspx">View Optional Courses</a>
        <a class="dashboard-button" href="StudentviewAvailableCourses.aspx">View Available Courses</a>
        <a class="dashboard-button" href="StudentviewRequiredCourses.aspx">View Required Courses</a>
        <a class="dashboard-button" href="StudentviewMissingCourses.aspx">View Missing Courses</a>
        <a class="dashboard-button" href="StudentviewGraduationPlan.aspx">View Graduation Plan</a>
        <a class="dashboard-button" href="StudentsendCourseRequest.aspx">Send Course Request</a>
        <a class="dashboard-button" href="StudentsendCreditHourRequest.aspx">Send Credit Hours Request</a>
        <a class="dashboard-button" href="StudentviewUpcomingInstallment.aspx">View Upcoming Installment</a>
        <a class="dashboard-button" href="StudentregisterFirstMakeupExam.aspx">Register for 1st Makeup</a>
        <a class="dashboard-button" href="StudentregisterSecondMakeupExam.aspx">Register for 2nd Makeup</a>
        <a class="dashboard-button" href="StudentslotsOfCourseByInstructor.aspx">View all slots of a Course by Instructor</a>
        
        <a class="dashboard-button" href="StudentallCoursesWithExamsDetails.aspx">View all Courses With their Exams Details</a>
        <a class="dashboard-button" href="StudentallCoursesWithPrerequisites.aspx">View all courses with their Prerequisites</a>
        <a class="dashboard-button" href="StudentallCoursesWithSlotsAndInstructors.aspx">View all Courses With their Slots & Instructors Details</a>
       
     
    </div>
    
    <form id="studentInfoForm" runat="server">
        <div id="container">
        <!-- Student Information Section -->
        <div class="info-value" id="lblFullName" runat="server"></div>
        <div class="info-value" id="lblStudentID" runat="server"></div>
        <div class="info-value" id="lblFaculty" runat="server"></div>
        <div class="info-value" id="lblMajor" runat="server"></div>
        <div class="info-value" id="lblSemester" runat="server"></div>
         <div class="info-value" id="lblStatus" runat="server"></div>
        <div class="info-value" id="lblMail" runat="server"></div>
        <div class="info-value" id="lblAssignedHours" runat="server"></div>
        <div class="info-value" id="lblRequiredHours" runat="server"></div>
        </div>
        <asp:Button ID="signOutButton" CssClass="dashboard-button" runat="server" OnClick="SignOut" Text="Sign Out" />
    </form>

    
</body>
</html>