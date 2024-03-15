using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Modified_Advising_System
{
    public partial class AdminViewInstructorWithAssignedCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection s = new SqlConnection(conn);

            SqlCommand sql = new SqlCommand("SELECT * FROM Instructors_AssignedCourses", s); 
            sql.CommandType = CommandType.Text;


            s.Open();
            SqlDataReader sdr = sql.ExecuteReader(CommandBehavior.CloseConnection);
            String html = "";
            while (sdr.Read())
            {
                String Instructor = sdr.GetString(sdr.GetOrdinal("Instructor"));
                Label Instructor_name = new Label();
                Instructor_name.Text = Instructor;
                // form1.Controls.Add(name);

                int Iid = sdr.GetInt32(sdr.GetOrdinal("instructor_id"));
                Label Instructor_id = new Label();
                Instructor_id.Text = Iid.ToString();

                String Course = sdr.GetString(sdr.GetOrdinal("Course"));
                Label Course_name = new Label();
                Course_name.Text = Course;
                // form1.Controls.Add(email);

                int Cid = sdr.GetInt32(sdr.GetOrdinal("course_id"));
                Label Course_id = new Label();
                Course_id.Text = Cid.ToString();

                html = html + "<div class='flexbox2'><div class='content1'>" + Instructor_name.Text + "</div><div class='content2'>" + Instructor_id.Text + "</div><div class='content3'>" + Course_name.Text + "</div><div class='content4'>" + Course_id.Text + "</div></div>";


            }
            flow.InnerHtml = html;




        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }
        
    }
    
    
}
