using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class StudentallCoursesWithExamsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");

        }
        private void BindGridView()
        {
            // Connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to fetch data from the view
                string query = "select * from Courses_MakeupExams";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    // Bind the data to the GridView
                    GridViewCoursesMakeupExams.DataSource = reader;
                    GridViewCoursesMakeupExams.DataBind();
                }
            }
        }
    }
}