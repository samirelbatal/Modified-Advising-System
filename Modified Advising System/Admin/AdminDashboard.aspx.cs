using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void deletecourse(object sender, EventArgs e)
        {
            Response.Redirect("Admindeletecourse.aspx");


        }
        protected void deleteslot(object sender, EventArgs e)
        {
            Response.Redirect("Admindeleteslot.aspx");

        }
        protected void addmakeup(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddMakeUpExam.aspx");
        }

        protected void viewpayments(object sender, EventArgs e)
        {
            Response.Redirect("Adminviewpayments.aspx");

        }

        protected void issueinstallments(object sender, EventArgs e)
        {
            Response.Redirect("Adminissueinstallments.aspx");
        }

        protected void updatestatus(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateStudentStatus.aspx");

        }

        protected void activestudent(object sender, EventArgs e)
        {
            Response.Redirect("AdminGetActiveStudents.aspx");

        }

        protected void gradplans(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewGraduationPlan.aspx");
        }

        protected void studentstranscript(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewStudentTranscript.aspx");
        }
    }
}