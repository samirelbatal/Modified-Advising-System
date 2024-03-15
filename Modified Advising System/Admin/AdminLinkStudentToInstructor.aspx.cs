using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Modified_Advising_System
{
    public partial class AdminLinkStudentToInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkStudent(object sender, EventArgs e)
        {

            string c = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection conn = new SqlConnection(c);

            SqlCommand proc = new SqlCommand("Procedures_AdminLinkStudent", conn);

            int Instructor_id;
            int Student_id;
            int Course_id;
            String Semester_code = CODE.Text;

            if (!Int32.TryParse(INSTRUCTOR.Text, out Instructor_id) || !Int32.TryParse(COURSE.Text, out Course_id)
               || !Int32.TryParse(STUDENT.Text, out Student_id) || String.IsNullOrWhiteSpace(Semester_code))
            {
                lblMessage.Text = "Please fill out the data correctly";
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                Instructor_id = Convert.ToInt32(INSTRUCTOR.Text);
                Student_id = Convert.ToInt32(STUDENT.Text);
                Course_id = Convert.ToInt32(COURSE.Text);

                if (!InstructorExists(Instructor_id, conn))
                {
                    lblMessage.Text = "Instructor doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!StudentExists(Student_id, conn))
                {
                    lblMessage.Text = "Student doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if(!IC(Instructor_id, Course_id, conn))
                {
                    lblMessage.Text = "Instructor doesn't teach this course";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (!cs(Semester_code,Course_id, conn))
                {
                    lblMessage.Text = "Course is not offered in this semester";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!CourseExists(Course_id, conn))
                {
                    lblMessage.Text = "Course doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }
                if (!Semester_Code_Exists(Semester_code, conn))
                {
                    lblMessage.Text = "Semester Code doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }
                if (LinkMade(Instructor_id,Student_id,Course_id,Semester_code,conn))
                {
                    lblMessage.Text = "Instructor Already gives Course to the Student in this Semester";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                proc.CommandType = System.Data.CommandType.StoredProcedure;

                proc.Parameters.Add(new SqlParameter("@instructor_id", Instructor_id));
                proc.Parameters.Add(new SqlParameter("@cours_id", Course_id));
                proc.Parameters.Add(new SqlParameter("@studentID", Student_id));
                proc.Parameters.Add(new SqlParameter("@semester_code", Semester_code));

                conn.Open();
                proc.ExecuteNonQuery();
                lblMessage.Text = "Link made Successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                conn.Close();




            }
        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }


        protected bool LinkMade(int Instructor_id, int Student_id , int Course_id , String Semester_code, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM Student_Instructor_Course_take WHERE instructor_id = @Instructor_id and student_id = @Student_id and course_id = @Course_id and semester_code = @Semester_code ";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Student_id", Student_id));
                cmd.Parameters.Add(new SqlParameter("@Instructor_id", Instructor_id));
                cmd.Parameters.Add(new SqlParameter("@course_id", Course_id));
                cmd.Parameters.Add(new SqlParameter("@Semester_code", Semester_code));



                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return count > 0;
            }

        }

        private bool Semester_Code_Exists(String Semester_Code, SqlConnection conn)
        {
            // Query to check if the Semester id exists
            string query = "SELECT COUNT(*) FROM Semester WHERE semester_code = @Semester_Code";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Semester_Code", Semester_Code));

                conn.Open();

                int Count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return Count > 0;
            }
        }
        private bool IC(int instructor, int course, SqlConnection conn)
        {
            // Query to check if the Semester id exists
            string query = "SELECT COUNT(*) FROM Instructor_Course WHERE instructor_id=@instructor_id and course_id=@course_id ";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@instructor_id",instructor ));
                cmd.Parameters.Add(new SqlParameter("@course_id", course));

                conn.Open();

                int Count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return Count > 0;
            }
        }

        private bool cs(string semestercode, int course, SqlConnection conn)
        {
            // Query to check if the Semester id exists
            string query = "SELECT COUNT(*) FROM  Course_Semester WHERE semester_code=@semester_code and course_id=@course_id ";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@semester_code", semestercode));
                cmd.Parameters.Add(new SqlParameter("@course_id", course));

                conn.Open();

                int Count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return Count > 0;
            }
        }



        private bool StudentExists(int Student_id, SqlConnection conn)
        {
            // Query to check if the Student id exists
            string query = "SELECT COUNT(*) FROM Student WHERE student_id = @Student_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Student_id", Student_id));

                conn.Open();

                int StudentCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return StudentCount > 0;
            }
        }
        private bool CourseExists(int Course_id, SqlConnection conn)
        {
            // Query to check if the course id exists
            string query = "SELECT COUNT(*) FROM course WHERE course_id = @Course_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Course_id", Course_id));

                conn.Open();

                int CourseCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return CourseCount > 0;
            }
        }


        private bool InstructorExists(int Instructor_id, SqlConnection conn)
        {
            // Query to check if the Instructor id exists
            string query = "SELECT COUNT(*) FROM Instructor WHERE instructor_id = @Instructor_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Instructor_id", Instructor_id));

                conn.Open();

                int InstructorCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return InstructorCount > 0;
            }
        }

    }
}