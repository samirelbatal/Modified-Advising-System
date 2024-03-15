using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class Admin_Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
           

        protected void AdminListAdvisors(object sender, EventArgs e)
        {
            Response.Redirect("AdminListAdvisors.aspx");

        }
        protected void AdminListStudentsWithAdvisors(object sender, EventArgs e)
        {
            Response.Redirect("AdminListStudentsWithAdvisors.aspx");

        }

        protected void AdminListsPendingRequests(object sender, EventArgs e)
        {
            Response.Redirect("AdminListsPendingRequests.aspx");

        }

        
            protected void AdminAddingSemester(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddingSemester.aspx");

        }
        
              protected void AdminAddingCourse(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddingCourse.aspx");

        }
        
              protected void AdminLinkInstructor(object sender, EventArgs e)
        {
            Response.Redirect("AdminLinkInstructor.aspx");

        }
        
             protected void AdminLinkStudentToAdvisor(object sender, EventArgs e)
        {
            Response.Redirect("AdminLinkStudentToAdvisor.aspx");

        }
        
            protected void AdminLinkStudentToInstructor(object sender, EventArgs e)
        {
            Response.Redirect("AdminLinkStudentToInstructor.aspx");

        }
        
             protected void AdminViewInstructorWithAssignedCourses(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewInstructorWithAssignedCourses.aspx");

        }
        
             protected void AdminViewSemestersWithOfferedCourses(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewSemestersWithOfferedCourses.aspx");

        }


        protected void AdminDeleteCourse(object sender, EventArgs e)
        {
            Response.Redirect("Admindeletecourse.aspx");
        }

        protected void AdminDeleteSlot(object sender, EventArgs e)
        {
            Response.Redirect("Admindeleteslot.aspx");
        }

        protected void AdminAddMakeUpExam(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddMakeUpExam.aspx");
        }

        protected void AdminViewPayments(object sender, EventArgs e)
        {
            Response.Redirect("Adminviewpayments.aspx");
        }

        protected void AdminIssueInstallments(object sender, EventArgs e)
        {
            Response.Redirect("Adminissueinstallments.aspx");
        }

        protected void AdminUpdateStudentStatus(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateStudentStatus.aspx");
        }

        protected void AdminFetchActiveStudents(object sender, EventArgs e)
        {
            Response.Redirect("AdminGetActiveStudents.aspx");
        }

        protected void AdminViewGraduationPlan(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewGraduationPlan.aspx");
        }

        protected void AdminViewTranscriptDetails(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewStudentTranscript.aspx");
        }






        protected void AdminSignout(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");

        }





    }
}