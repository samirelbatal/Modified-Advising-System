using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class updatedate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void grad_date_TextChanged(object sender, EventArgs e)
        {
        }

        protected void Update(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int advisorId = Convert.ToInt32(Session["user"]);
            string studentId = planid.Text;
            string planId = "";

            using (SqlCommand cmd = new SqlCommand("SELECT plan_id FROM Graduation_Plan WHERE student_id = @student_id", conn))
            {
                cmd.Parameters.Add(new SqlParameter("@student_id", studentId));

                conn.Open();

                object result = cmd.ExecuteScalar();

                conn.Close();

                if (result != null)
                {
                    planId = result.ToString();
                }
            }

            string date = grad_date.Text;

            

            if (!planExists(planId, conn))
            {
                DisplayStyledMessage("Cannot update grad date. There is no grad plan for this student.", "red");
                return;
            }

            // Check if the student is assigned to the advisor
            if (!IsStudentAssignedToAdvisor(studentId, advisorId, conn))
            {
                DisplayStyledMessage("Cannot update grad date. Student is assigned to another advisor.", "red");
                return;
            }

            SqlCommand regproc = new SqlCommand("[Procedures_AdvisorUpdateGP]", conn);
            regproc.CommandType = CommandType.StoredProcedure;

            regproc.Parameters.Add(new SqlParameter("@studentID", studentId));
            regproc.Parameters.Add(new SqlParameter("@expected_grad_date", date));

            conn.Open();

            int rowsAffected = regproc.ExecuteNonQuery();

            conn.Close();

            if (rowsAffected > 0)
            {
                DisplayStyledMessage("Grad date updated successfully for student ID: " + studentId, "green");
            }
            else
            {
                DisplayStyledMessage("Failed to update grad date.", "red");
            }
        }

        private void DisplayStyledMessage(string message, string color)
        {
            Label1.Text="<p class='styled-message' style='color:" + color + "'>" + message + "</p>";
        }

        private bool planExists(string pid, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM Graduation_Plan WHERE plan_id = @plan_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@plan_id", pid));

                conn.Open();

                int plancount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return plancount > 0;
            }
        }

        private bool IsStudentAssignedToAdvisor(string studentId, int advisorId, SqlConnection conn)
        {
            // check if the student is assigned to the advisor
            string query = "SELECT COUNT(*) FROM Student WHERE student_id = @StudentId AND advisor_id = @AdvisorId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@studentID", studentId));
                cmd.Parameters.Add(new SqlParameter("@AdvisorId", advisorId));

                conn.Open();

                int assignmentCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return assignmentCount > 0;
            }
        }
    }
}
