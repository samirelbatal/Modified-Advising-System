using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;
using System.Web.Services.Description;

namespace Modified_Advising_System
{
    public partial class CreateGradPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateGP(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int advisorId = Convert.ToInt32(Session["user"]);
            string studentId = studentid.Text;

            // Check if student ID is null or empty
            if (string.IsNullOrEmpty(studentId))
            {
                DisplayStyledMessage("Cannot add grad plan. Student ID is null or empty. Please try again.","red");
                return;
            }

            // Check if the student ID exists
            if (!StudentExists(studentId, conn))
            {
                DisplayStyledMessage("Cannot add grad plan. Student ID does not exist.","red");
                return;
            }

            // Check if the student is assigned to the advisor
            if (!IsStudentAssignedToAdvisor(studentId, advisorId, conn))
            {
                DisplayStyledMessage("Cannot add grad plan. Student is assigned to another advisor.","red");
                return;
            }

            string code = semcode.Text;

            // Check if the semester code exists
            if (!SemesterExists(code, conn))
            {
                DisplayStyledMessage("Cannot add grad plan. Invalid semester code.","red");
                return;
            }

            string hours = sem_credit_hours.Text;
            string date = grad_date.Text;

            // Check if a graduation plan already exists for the student
            if (PlanExistsForStudent(studentId,code, conn))
            {
                DisplayStyledMessage("Cannot add grad plan. A plan already exists for this student.","red");
                return;
            }

            SqlCommand regproc = new SqlCommand("[Procedures_AdvisorCreateGP]", conn);
            regproc.CommandType = CommandType.StoredProcedure;

            regproc.Parameters.Add(new SqlParameter("@student_id", studentId));
            regproc.Parameters.Add(new SqlParameter("@Semester_code", code));
            regproc.Parameters.Add(new SqlParameter("@sem_credit_hours", hours));
            regproc.Parameters.Add(new SqlParameter("@expected_graduation_date", date));
            regproc.Parameters.Add(new SqlParameter("@advisor_id", SqlDbType.Int) { Value = advisorId });

            conn.Open();

            int rowsAffected = regproc.ExecuteNonQuery();

            conn.Close();

            if (rowsAffected > 0)
            {
                DisplayStyledMessage("Grad plan added successfully for student ID: " + studentId,"green");
            }
            else
            {
                DisplayStyledMessage("Failed to add grad plan. Acquired hours may be less than 157.","red");
            }
        }

        private void DisplayStyledMessage(string message, string color)
        {
            Label1.Text = "<div class='center-content styled-message' style='color:" + color + "'>" + message + "</div>";
        }

        private bool PlanExistsForStudent(string studentId,string semestercode, SqlConnection conn)
        {
            // Query to check if a graduation plan exists for the student
            string query = "SELECT COUNT(*) FROM Graduation_Plan WHERE student_id = @StudentId and semester_code=@Semester_code ";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@StudentId", studentId));
                cmd.Parameters.Add(new SqlParameter("@Semester_code", semestercode));

                conn.Open();

                int planCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return planCount > 0;
            }
        }

        private bool StudentExists(string studentId, SqlConnection conn)
        {
            // Query to check if the student ID exists
            string query = "SELECT COUNT(*) FROM Student WHERE student_id = @StudentId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@StudentId", studentId));

                conn.Open();

                int studentCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return studentCount > 0;
            }
        }

        private bool IsStudentAssignedToAdvisor(string studentId, int advisorId, SqlConnection conn)
        {
            // Query to check if the student is assigned to the advisor
            string query = "SELECT COUNT(*) FROM Student WHERE student_id = @StudentId AND advisor_id = @AdvisorId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@StudentId", studentId));
                cmd.Parameters.Add(new SqlParameter("@AdvisorId", advisorId));

                conn.Open();

                int assignmentCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return assignmentCount > 0;
            }
        }

        private bool SemesterExists(string semesterCode, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Semester WHERE semester_code = @SemesterCode";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@SemesterCode", semesterCode));

                conn.Open();

                int semesterCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return semesterCount > 0;
            }
        }
    }
}
