// viewAvailableCourses.aspx.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class StudentviewAvailableCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");
        }

        protected void GetAvailableCoursesButton_Click(object sender, EventArgs e)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];

            if (userIdCookie != null)
            {
                int studentId = Convert.ToInt32(userIdCookie.Value);

                // Retrieve semester code from the TextBox
                string enteredSemesterCode = SemesterCodeTextBox.Text.Trim();

                // Validate that the user entered at least 3 characters for the semester code
                if (enteredSemesterCode.Length >= 3 & enteredSemesterCode.Length <= 5)
                {
                    // Proceed with the logic using the entered semester code
                    string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    conn.Open();

                    string query = "SELECT * FROM FN_SemsterAvailableCourses(@semstercode)"; // Modify the query to fit your function
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@semstercode", SqlDbType.VarChar, 40) { Value = enteredSemesterCode });

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        AvailableCoursesLiteral.Text = "<table border='3'><tr><th>Course ID</th><th>Course Name</th></tr>";

                        foreach (DataRow row in dataTable.Rows)
                        {
                            AvailableCoursesLiteral.Text += "<tr>";
                            AvailableCoursesLiteral.Text += "<td>" + row["course_id"] + "</td>";
                            AvailableCoursesLiteral.Text += "<td>" + row["name"] + "</td>";
                            AvailableCoursesLiteral.Text += "</tr>";
                        }

                        AvailableCoursesLiteral.Text += "</table>";
                    }
                    else
                    {
                        // Display a warning message in red if no available courses are found
                        AvailableCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>No available courses for the entered semester</div>";
                    }

                    conn.Close();
                }
                else if (enteredSemesterCode.Length == 0)
                {
                    AvailableCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 70px;'>Please enter a value for Semester Code</div>";
                }
                else
                {
                    // Display a warning message in red if the entered semester code is invalid
                    AvailableCoursesLiteral.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>Please enter a valid Semester Code</div>";
                }
            }
        }
    }
}
