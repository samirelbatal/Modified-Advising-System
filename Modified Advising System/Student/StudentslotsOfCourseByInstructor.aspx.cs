using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class StudentslotsOfCourseByInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load courses on page load
                PopulateCoursesDropDown();
            }


        }

        private void PopulateInstructorsDropDown(int course_id)
        {
            ddlInstructors.Items.Clear();

            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "select i.instructor_id,i.name from Instructor i inner join Instructor_Course ic on i.instructor_id=ic.instructor_id where ic.course_id=@SelectedCourseId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedCourseId", course_id);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ddlInstructors.DataSource = dt;
                    ddlInstructors.DataBind();
                }
            }

        }
        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int course_id = getCourseId(ddlCourses.SelectedValue);
            PopulateInstructorsDropDown(course_id);
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
        private int getInstructorId(String selectedInstructorName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT instructor_id FROM instructor WHERE name = @selectedInstructorName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@selectedInstructorName", selectedInstructorName);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        private void PopulateCoursesDropDown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Select course_id,name from course where is_offered=1";
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
        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");

        }
        protected void btnViewSlots_Click(object sender, EventArgs e)
        {
            if (ddlCourses.SelectedValue == "")
            {
                string script = "alert('Please Select a Course');";
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);

            }
            if (ddlInstructors.SelectedValue == "")
            {
                string script = "alert('Please Select an Instructor');";
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);

            }
            int courseID = getCourseId(ddlCourses.SelectedValue);
            int instructorID = getInstructorId(ddlInstructors.SelectedValue);

            GridView1.DataSource = GetSlots(courseID, instructorID);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                string script = "alert('No Slots for this Instructor');";
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);

            }
        }

        private DataTable GetSlots(int courseID, int instructorID)
        {
            DataTable dataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM FN_StudentViewSlot(@courseid, @instructorid)", connection))
                {
                    command.Parameters.AddWithValue("@courseid", courseID);
                    command.Parameters.AddWithValue("@instructorid", instructorID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }
    }
}