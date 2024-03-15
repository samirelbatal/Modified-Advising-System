using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Modified_Advising_System
{
    public partial class AdminLinkInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkInstructor(object sender, EventArgs e)
        {
            string c = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection conn = new SqlConnection(c);

            SqlCommand proc = new SqlCommand("Procedures_AdminLinkInstructor", conn);


            int Instructor_id;
            int Course_id;
            int Slot_id;



            if (Int32.TryParse(INSTRUCTOR.Text, out Instructor_id) && Int32.TryParse(COURSE.Text, out Course_id)
                && Int32.TryParse(SLOT.Text, out Slot_id))
            {
                Instructor_id = Convert.ToInt32(INSTRUCTOR.Text);
                Course_id = Convert.ToInt32(COURSE.Text);
                Slot_id = Convert.ToInt32(SLOT.Text);


                if (!CourseExists(Course_id, conn))
                {
                    lblMessage.Text = "Course doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }

                if (!InstructorExists(Instructor_id, conn))
                {
                    lblMessage.Text = "Instructor doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }

                if (!SlotExists(Slot_id, conn))
                {
                    lblMessage.Text = "Slot doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }

                if (LinkExists(Instructor_id, Course_id, Slot_id, conn))
                {
                    lblMessage.Text = "Instructor Already gives this course at this slot";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                proc.CommandType = System.Data.CommandType.StoredProcedure;

                proc.Parameters.Add(new SqlParameter("@cours_id", Course_id));
                proc.Parameters.Add(new SqlParameter("@instructor_id", Instructor_id));
                proc.Parameters.Add(new SqlParameter("@slot_id", Slot_id));

                conn.Open();
                proc.ExecuteNonQuery();
                lblMessage.Text = "Link made Successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                conn.Close();



            }
            else
            {

                lblMessage.Text = "Please fill out the data correctly";
                lblMessage.ForeColor = System.Drawing.Color.Red;




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

        private bool SlotExists(int Slot_id, SqlConnection conn)
        {
            // Query to check if the Slot id exists
            string query = "SELECT COUNT(*) FROM Slot WHERE slot_id = @Slot_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Slot_id", Slot_id));

                conn.Open();

                int SlotCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return SlotCount > 0;
            }
        }

        private bool LinkExists(int Instructor_id, int Course_id, int Slot_id, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM  Slot WHERE instructor_id = @Instructor_id and course_id = @Course_id and slot_id = @slot_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Instructor_id", Instructor_id)); 
                cmd.Parameters.Add(new SqlParameter("@Course_id", Course_id));
                cmd.Parameters.Add(new SqlParameter("@slot_id", Slot_id));

                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return count > 0;
            }
        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }

    }
}