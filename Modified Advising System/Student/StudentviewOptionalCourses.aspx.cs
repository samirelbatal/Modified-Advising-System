using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class StudentviewOptionalCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The logic for loading the page (without semester code) remains here
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");
        }

        protected void GetOptionalCoursesButton_Click(object sender, EventArgs e)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];

            if (userIdCookie != null)
            {
                int studentId = Convert.ToInt32(userIdCookie.Value);

                // Retrieve semester code from the TextBox
                string enteredSemesterCode = SemesterCodeTextBox.Text.Trim();

                // Validate that the user entered at least 3 characters for the semester code
                if (enteredSemesterCode.Length >= 3 & enteredSemesterCode.Length <=5)
                {
                    // Proceed with the logic using the entered semester code
                    string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    conn.Open();

                    string query = "Procedures_ViewOptionalCourse";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentId });
                    cmd.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.VarChar, 40) { Value = enteredSemesterCode });

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        OptionalCoursesLiteral.Text = "<table border='3'><tr><th>Course ID</th><th>Course Name</th></tr>";

                        while (reader.Read())
                        {
                            OptionalCoursesLiteral.Text += "<tr>";
                            OptionalCoursesLiteral.Text += "<td>" + reader["course_id"] + "</td>";
                            OptionalCoursesLiteral.Text += "<td>" + reader["name"] + "</td>";
                            OptionalCoursesLiteral.Text += "</tr>";
                        }

                        OptionalCoursesLiteral.Text += "</table>";
                    }
                    else
                    {
                        OptionalCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>No optional courses available for you</div>";

                    }

                    conn.Close();
                }
                else if (enteredSemesterCode.Length == 0)
                {
                    OptionalCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 70px;'>Please enter a value for Semester Code</div>";
                }
                else
                {
                   
                    OptionalCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>Please enter a valid Semester Code</div>";

                }
            }
        }
    }
}
