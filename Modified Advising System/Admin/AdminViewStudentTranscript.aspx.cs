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
    public partial class AdminViewStudentTranscript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            //create a new connection to the database using above str (database we want)
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand viewtranscript = new SqlCommand("SELECT * FROM Students_Courses_transcript", conn);

            viewtranscript.CommandType = System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader reader = viewtranscript.ExecuteReader();

            if (reader.HasRows)
            {
                viewtranscriptlist.Text = "<table border='3'> <tr><th>Student ID</th><th>Student Name</th><th>Course ID</th><th>Course Name</th><th>Exam Type</th><th>Course Grade</th><th>Semester</th></tr>";

                while (reader.Read())
                {
                    viewtranscriptlist.Text += "<tr>";
                    viewtranscriptlist.Text += "<td>" + reader["student_id"] + "</td>";
                    viewtranscriptlist.Text += "<td>" + reader["f_name"] + "</td>";
                    viewtranscriptlist.Text += "<td>" + reader["course_id"] + "</td>";
                    viewtranscriptlist.Text += "<td>" + reader["name"] + "</td>";
                    viewtranscriptlist.Text += "<td>" + reader["exam_type"] + "</td>";
                    viewtranscriptlist.Text += "<td>" + reader["grade"] + "</td>";
                    viewtranscriptlist.Text += "<td>" + reader["semester_code"] + "</td>";
                    viewtranscriptlist.Text += "</tr>";
                }

                viewtranscriptlist.Text += "</table>";
            }
            else
            {
                // Format the message to be bigger, bold, and positioned lower on the page
                viewtranscriptlist.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>No Data Found</div>";
            }
            conn.Close();
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
    }
}