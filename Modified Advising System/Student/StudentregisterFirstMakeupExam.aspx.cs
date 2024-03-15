using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Security.AccessControl;

namespace Modified_Advising_System
{
    public partial class StudentregisterFirstMakeupExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCoursesDropDown();
            }
        }
        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");

        }
        private void PopulateCoursesDropDown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String studentID = Request.Cookies["UserID"].Value;

                string query = "Select s.course_id, name from Student_Instructor_Course_take s inner join Course c on s.course_id=c.course_id  where s.student_id =" + studentID;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ddlCourses.DataSource = dt;
                    ddlCourses.DataBind();
                }
            }
        }
        protected void btnRegisterFirstMakeup_Click(object sender, EventArgs e)
        {
            string selectedCourseID = ddlCourses.SelectedValue;
            int course_id = getCourseId(selectedCourseID);
            string studentCurr_sem = semsterCode.Text;
            int studentID = Convert.ToInt32(Request.Cookies["UserID"].Value);



            if (string.IsNullOrEmpty(selectedCourseID) || selectedCourseID == "-- Select Course --")
            {
                lblResult.Text = "Please select a valid Course.";
                lblResult.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (!IsValidSemesterCode(studentCurr_sem) || studentCurr_sem is null)
            {
                lblResult.Text = "Please enter a valid Semester Code.";
                lblResult.ForeColor = System.Drawing.Color.Red;
                return;
            }


            if (!checkEligiblity(studentID, course_id, studentCurr_sem))
            {
                lblResult.Text = "You are not eligible!";
                lblResult.ForeColor = System.Drawing.Color.Red;
                return;
            }



            RegisterFirstMakeup(studentID, course_id, studentCurr_sem);
        }

        private Boolean checkEligiblity(int studentID, int course_id, string studentCurr_sem)
        {
            if (DoesRecordExist(studentID, course_id, "First_makeup") || DoesRecordExist(studentID, course_id, "Second_makeup"))
            {
                string alertMessage = $"alert('Student is not eligible for a makeup exam. Reason: You already Registered Makeup Exam');";
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", alertMessage, true);
                return false;
            }

            if (!sameSemesterCode(studentID, course_id, studentCurr_sem))
            {
                string alertMessage = $"alert('You did not take the course this semster');";
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", alertMessage, true);
                return false;


            }
            if (!HasFailedGrade(studentID, course_id))
            {
                string alertMessage = $"alert('Didn't Fail the course');";
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", alertMessage, true);
                return false;
            }

            return true;
        }
        private bool IsMakeupExamTimingValid(int courseId, string studentCurrSem)
        {
            // Check the timing based on the course (even or odd) and semester code
            // Modify this logic based on your specific requirements

            int courseNumber = GetSemesterNumber(courseId);
            Response.Write(courseNumber);
            string semesterCode = studentCurrSem;

            // Extract the numeric part from the semester code
            if (int.TryParse(semesterCode.Substring(1), out int semesterYear))
            {
                // Determine whether the semester is optional (Summer round 1 or round 2)
                bool isOptionalSemester = semesterCode.Contains("R");
                // Determine whether the semester is odd or even
                bool isEvenSemester = (semesterCode.StartsWith("S") && !isOptionalSemester)
                    || (isOptionalSemester && semesterCode.EndsWith("R2"));

                // Determine whether the course is even or odd
                bool isEvenCourse = courseNumber % 2 == 0;



                if ((isEvenCourse && isEvenSemester && !isOptionalSemester) ||
                    (!isEvenCourse && !isEvenSemester && !isOptionalSemester) ||
                    (isEvenCourse && isEvenSemester && isOptionalSemester) ||
                    (!isEvenCourse && !isEvenSemester && isOptionalSemester))
                {
                    return true;
                }
            }

            return false;
        }

        private int GetSemesterNumber(int courseId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT semester FROM Course WHERE course_id = @SelectedCourseId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedCourseId", courseId);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private int getCourseId(String selectedCourseName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT course_id FROM Course WHERE name = @SelectedCourseName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedCourseName", selectedCourseName);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        protected void RegisterFirstMakeup(int studentID, int courseID, string studentCurr_sem)
        {



            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to execute the stored procedure
                string query = "Procedures_StudentRegisterFirstMakeup";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters to the stored procedure
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@courseID", courseID);
                    command.Parameters.AddWithValue("@studentCurr_sem", studentCurr_sem);

                    try
                    {
                        command.ExecuteNonQuery();
                        string alertMessage = $"alert('Successfuly Registered');";
                        ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", alertMessage, true);
                        lblResult.Text = "";


                    }
                    catch (Exception ex)
                    {
                        lblResult.Text = "Error: " + ex.Message;
                    }
                }
            }
        }


        public static bool IsValidSemesterCode(string semesterCode)
        {
            // Define the pattern for semester codes
            string pattern = @"^(S)(\d{2})(R\d)?$|^(W)(\d{2})$";

            // Check if the input matches the pattern

            if (Regex.IsMatch(semesterCode, pattern, RegexOptions.IgnoreCase))
            {

                return true;

            }

            return false;
        }

        // Helper function to check if a record exists in Student_Instructor_Course_take
        private bool DoesRecordExist(int studentId, int courseId, string examType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            // Use ADO.NET to check if a record exists in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Student_Instructor_Course_take WHERE student_id = @StudentID AND course_id = @CourseID AND exam_type = @ExamType", connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@CourseID", courseId);
                    command.Parameters.AddWithValue("@ExamType", examType);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        private bool sameSemesterCode(int studentId, int courseId, string studentCurr_sem)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            // Use ADO.NET to check if a record exists in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Student_Instructor_Course_take WHERE student_id = @StudentID AND course_id = @CourseID AND semester_code = @studentCurr_sem", connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@CourseID", courseId);
                    command.Parameters.AddWithValue("@studentCurr_sem", studentCurr_sem);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // Helper function to check if a student has a failed grade in a normal exam
        private bool HasFailedGrade(int studentId, int courseId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            // Use ADO.NET to check if a record exists in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Student_Instructor_Course_take WHERE student_id = @StudentID AND course_id = @CourseID AND exam_type = 'Normal' AND grade IN ('F', 'FF', NULL)", connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@CourseID", courseId);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }


    }



}