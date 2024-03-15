// viewRequiredCourses.aspx.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class StudentviewRequiredCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The logic for loading the page (without semester code) remains here
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");
        }

        protected void GetRequiredCoursesButton_Click(object sender, EventArgs e)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];

            if (userIdCookie != null)
            {
                int studentId = Convert.ToInt32(userIdCookie.Value);

                // Retrieve semester code from the TextBox
                string enteredSemesterCode = SemesterCodeTextBox.Text.Trim();

                // Validate that the user entered a semester code
                if (enteredSemesterCode.Length >= 3 & enteredSemesterCode.Length <= 5)
                {
                    // Proceed with the logic using the entered semester code
                    string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    conn.Open();

                    string query = "Procedures_ViewRequiredCourses";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentId });
                    cmd.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.VarChar, 40) { Value = enteredSemesterCode });

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        RequiredCoursesLiteral.Text = "<table border='3'><tr><th>Course ID</th><th>Course Name</th></tr>";

                        while (reader.Read())
                        {
                            RequiredCoursesLiteral.Text += "<tr>";
                            RequiredCoursesLiteral.Text += "<td>" + reader["course_id"] + "</td>";
                            RequiredCoursesLiteral.Text += "<td>" + reader["name"] + "</td>";
                            RequiredCoursesLiteral.Text += "</tr>";
                        }

                        RequiredCoursesLiteral.Text += "</table>";
                    }
                    else
                    {
                        // Display a warning message in red if no required courses are found
                        RequiredCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 70px;'>No required Courses found for the entered semester</div>";
                    }

                    conn.Close();
                }
                else if(enteredSemesterCode.Length == 0){
                    RequiredCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 70px;'>Please enter a value for Semester Code</div>";
                }
                else
                {
                    // Display a warning message in red if the entered semester code is invalid
                    RequiredCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 70px;'>Please enter a valid Semester Code</div>";
                }
            }
        }
    }
}
