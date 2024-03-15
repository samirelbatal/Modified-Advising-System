using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class deletecourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string semCode = TextBox2.Text;
                int advisorId = Convert.ToInt32(Session["user"]);

                int courseID = Convert.ToInt32(TextBox3.Text);
                string studentId = sid.Text; 
                int graduationPlanId = -1;
                if (string.IsNullOrEmpty(studentId))
                {
                    Label1.Text = "<p style='color:red'>Cannot delete course. Student ID is null or empty. Please try again.</p>";
                    return;
                }
                // Get plan ID from Graduation_Plan
                using (SqlCommand cmd = new SqlCommand("SELECT plan_id FROM Graduation_Plan WHERE student_id = @student_id", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@student_id", studentId));

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        graduationPlanId = Convert.ToInt32(reader["plan_id"]);
                    }

                    conn.Close();
                }

                if (!IsStudentAssignedToAdvisor(studentId, advisorId, conn))
                {
                    DisplayStyledMessage("Cannot delete course. Student is not assigned to the advisor.", "red");
                    return;
                }

                if (graduationPlanId == -1 || !PlanExists(graduationPlanId.ToString(), conn))
                {
                    DisplayStyledMessage("Cannot delete course. Graduation plan does not exist for the student.", "red");
                    return;
                }

                // Check if the course is associated with the specified plan
                if (!IsCourseInGradPlan(graduationPlanId, semCode, courseID, conn))
                {
                    DisplayStyledMessage("Cannot delete course. Course is not associated with the specified plan.", "red");
                    return;
                }

                // Proceed with the deletion
                using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorDeleteFromGP]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@studentID", studentId));
                    cmd.Parameters.Add(new SqlParameter("@sem_code", semCode));
                    cmd.Parameters.Add(new SqlParameter("@courseID", courseID));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    DisplayStyledMessage("Course deleted successfully.", "green");
                }
            }
        }

        private void DisplayStyledMessage(string message, string color)
        {
            Label1.Text="<div class='center-content styled-message' style='color:" + color + "'>" + message + "</div>";
        }

        private bool IsCourseInGradPlan(int graduationPlanId, string semesterCode, int courseID, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM GradPlan_Course WHERE plan_id = @GraduationPlanId AND semester_code = @SemesterCode AND course_id = @CourseID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@GraduationPlanId", graduationPlanId));
                cmd.Parameters.Add(new SqlParameter("@SemesterCode", semesterCode));
                cmd.Parameters.Add(new SqlParameter("@CourseID", courseID));

                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return count > 0;
            }
        }

        private bool PlanExists(string pid, SqlConnection conn)
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
