// viewMissingCourses.aspx.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class StudentviewMissingCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The logic for loading the page (without semester code) remains here
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Call GetMissingCoursesButton_Click when the page loads to display the missing courses
            GetMissingCoursesButton_Click(sender, e);
        }

        protected void GetMissingCoursesButton_Click(object sender, EventArgs e)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];

            if (userIdCookie != null)
            {
                int studentId = Convert.ToInt32(userIdCookie.Value);

                // Proceed with the logic using the entered semester code
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();

                string query = "Procedures_ViewMS";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentId });

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    MissingCoursesLiteral.Text = "<table border='3'><tr><th>Course ID</th><th>Course Name</th></tr>";

                    while (reader.Read())
                    {
                        MissingCoursesLiteral.Text += "<tr>";
                        MissingCoursesLiteral.Text += "<td>" + reader["course_id"] + "</td>";
                        MissingCoursesLiteral.Text += "<td>" + reader["name"] + "</td>";
                        MissingCoursesLiteral.Text += "</tr>";
                    }

                    MissingCoursesLiteral.Text += "</table>";
                }
                else
                {
                    // Format the message to be bigger, bold, and positioned lower on the page
                    MissingCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>No missing courses found for you</div>";
                }

                conn.Close();
            }
        }
    }
}
