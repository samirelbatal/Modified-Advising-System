using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class StudentsendCourseRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessageLabel.Visible = false;
            successMessageLabel.Visible = false;
        }

        private void ShowErrorMessage(string message)
        {
            // Display an error message to the user using a label control
            ErrorMessageLabel.Text = message;
            ErrorMessageLabel.Visible = true;
        }

        private void ShowSuccessMessage(string message)
        {
            // Display an error message to the user using a label control
            successMessageLabel.Text = message;
            successMessageLabel.Visible = true;
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");
        }

        protected void SendRequestButton_Click(object sender, EventArgs e)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];

            if (userIdCookie != null)
            {
                int studentId = Convert.ToInt32(userIdCookie.Value);

                // Retrieve input values
                string courseIdText = TextBoxCourseID.Text.Trim();

                if (string.IsNullOrEmpty(courseIdText))
                {
                    // Display a warning message if the entered value is empty
                    ShowErrorMessage("Please enter a value for Course ID");
                    return;
                }


                if (!int.TryParse(courseIdText, out _))
                {
                    // Display a warning message if the entered value is not an integer
                    ShowErrorMessage("Please enter a valid Course ID");
                    return;
                }

              


                int courseId = Convert.ToInt32(courseIdText);
                string comment = TextBoxComment.Text;

                // Proceed with the logic using the entered values
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
                SqlConnection conn = new SqlConnection(connStr);

                if (!courseExists(courseId,conn))
                {
                    // Display a warning message if the entered value is not an integer
                    ShowErrorMessage("This Course doesn't exist. Please enter a valid Course ID. ");
                    return;

                }

               

                conn.Open();

                string query = "Procedures_StudentSendingCourseRequest";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@courseID", System.Data.SqlDbType.Int) { Value = courseId });
                cmd.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int) { Value = studentId });
                cmd.Parameters.Add(new SqlParameter("@type", System.Data.SqlDbType.VarChar, 40) { Value = "course" });
                cmd.Parameters.Add(new SqlParameter("@comment", System.Data.SqlDbType.VarChar, 40) { Value = comment });

                cmd.ExecuteNonQuery();

                ShowSuccessMessage("Request is sent successfully");

                conn.Close();

                // Optionally, you can provide feedback to the user that the request was sent successfully.
                // You can use labels or other controls for this purpose.
            }
        }

        private bool courseExists(int courseid, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Course WHERE course_id = @courseID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@courseID", courseid));

                conn.Open();

                int courseCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return courseCount > 0;
            }
        }
    }
}
