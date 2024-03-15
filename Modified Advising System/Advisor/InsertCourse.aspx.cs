using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Modified_Advising_System
{
    public partial class InsertCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Insert(object sender, EventArgs e)
        {
            String idlogin = studentid.Text;
            int advisorId = Convert.ToInt32(Session["user"]);

            if (string.IsNullOrEmpty(idlogin))
            {
                Label1.Text = "<p style='color:red'>Cannot add course. Student ID is null or empty. Please try again.</p>";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string semesterCode = semcode.Text;
            string courseName = coursename.Text;

            // Check if the inserted semester code exists
            if (!SemesterExists(semesterCode, conn))
            {
                Label1.Text = "<p style='color:red'>Cannot add course. Semester code does not exist.</p>";
                return;
            }

            int graduationPlanId = GetGraduationPlanId(idlogin, semesterCode, conn);
            if (!StudentExists(idlogin, conn))
            {
                Label1.Text = "<p style='color:red'>Cannot add course. Student ID does not exist.</p>";
                return;
            }

            // Check if the student is assigned to the advisor
            if (!IsStudentAssignedToAdvisor(idlogin, advisorId, conn))
            {
                Label1.Text = "<p style='color:red'>Cannot add course. Student is assigned to another advisor.</p>";
                return;
            }
            if (graduationPlanId == -1)
            {
                Label1.Text = "<p style='color:red'>Student does not have a graduation plan. Please create a graduation plan first.</p>";
                return;
            }

            if (CourseExistsInGradPlanCourse(graduationPlanId, semesterCode, courseName, conn))
            {
                Label1.Text = "<p style='color:red'>Course already exists in the graduation plan.</p>";
                return;
            }

            int courseId = -1;
            string getCourseIdQuery = "SELECT course_id FROM Course WHERE name = @CourseName";

            using (SqlCommand cmd = new SqlCommand(getCourseIdQuery, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@CourseName", courseName));

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    courseId = Convert.ToInt32(result);
                }
            }

            if (courseId != -1)
            {
                SqlCommand regproc = new SqlCommand("[Procedures_AdvisorAddCourseGP]", conn);
                regproc.CommandType = CommandType.StoredProcedure;

                regproc.Parameters.Add(new SqlParameter("@student_id", idlogin));
                regproc.Parameters.Add(new SqlParameter("@Semester_code", semesterCode));
                regproc.Parameters.Add(new SqlParameter("@course_name", courseName));

                conn.Open();
                regproc.ExecuteNonQuery();
                conn.Close();

                Label1.Text = "<p style='color:green'>Course added successfully for student ID: " + idlogin + "</p>";
            }
            else
            {
                Label1.Text = "<p style='color:red'>Course does not exist. Please try again.</p>";
            }
        }

        private int GetGraduationPlanId(string studentId, string semesterCode, SqlConnection conn)
        {
            int graduationPlanId = -1;

            string query = "SELECT plan_id FROM Graduation_Plan WHERE student_id = @StudentId AND semester_code = @SemesterCode";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@StudentId", studentId));
                cmd.Parameters.Add(new SqlParameter("@SemesterCode", semesterCode));

                conn.Open();

                object result = cmd.ExecuteScalar();

                conn.Close();

                if (result != null)
                {
                    graduationPlanId = Convert.ToInt32(result);
                }
            }

            return graduationPlanId;
        }

        private bool CourseExistsInGradPlanCourse(int graduationPlanId, string semesterCode, string courseName, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM GradPlan_Course WHERE plan_id = @GraduationPlanId AND Semester_code = @SemesterCode AND course_id = (SELECT course_id FROM Course WHERE name = @CourseName)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@GraduationPlanId", graduationPlanId));
                cmd.Parameters.Add(new SqlParameter("@SemesterCode", semesterCode));
                cmd.Parameters.Add(new SqlParameter("@CourseName", courseName));

                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return count > 0;
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
