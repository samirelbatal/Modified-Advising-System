using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class StudentsendCreditHoureRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessageLabel.Visible = false;
            successMessageLabel.Visible = false;
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");
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


        protected void SendRequestButton_Click(object sender, EventArgs e)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];

            if (userIdCookie != null)
            {
                int studentId = Convert.ToInt32(userIdCookie.Value);

                // Retrieve input values
                string creditHoursText = TextBoxCourseID.Text.Trim();

                if (string.IsNullOrEmpty(creditHoursText))
                {
                    // Display a warning message if the entered value is empty
                    ShowErrorMessage("Please enter a value for Credit Hours");
                    return;
                }

                if (!int.TryParse(creditHoursText, out int credithrs))
                {
                    // Display a warning message if the entered value is not an integer
                    ShowErrorMessage("Please enter a valid integer for Credit Hours");
                    return;
                }
              

                // Proceed with the logic using the entered values
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();

                string query = "Procedures_StudentSendingCHRequest";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@credit_hours", System.Data.SqlDbType.Int) { Value = credithrs });
                cmd.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int) { Value = studentId });
                cmd.Parameters.Add(new SqlParameter("@type", System.Data.SqlDbType.VarChar, 40) { Value = "credit_hours" });
                cmd.Parameters.Add(new SqlParameter("@comment", System.Data.SqlDbType.VarChar, 40) { Value = TextBoxComment.Text.Trim() });

                cmd.ExecuteNonQuery();

                ShowSuccessMessage("Request is sent successfully");

                conn.Close();

                // Optionally, you can provide feedback to the user that the request was sent successfully.
                // You can use labels or other controls for this purpose.
            }
        }
    }
}
