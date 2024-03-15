using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class Admindeletecourse : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void delete(object sender, EventArgs e)
        {
            try
            {
                string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
                //create a new connection to the database using above str (database we want)
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand deletecourse = new SqlCommand("Procedures_AdminDeleteCourse", conn);

                int id;
                if (Int32.TryParse(courseid.Text, out id))
                {
                    // The input is a valid integer
                    // You can proceed with your code here

                    id = Int16.Parse(courseid.Text);

                    deletecourse.CommandType = System.Data.CommandType.StoredProcedure;

                    deletecourse.Parameters.Add(new SqlParameter("@courseID", id));

                    if (!courseExists(id, conn))
                    {
                        lblMessage.Text = "Course Does not exist";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    conn.Open();
                    deletecourse.ExecuteNonQuery();
                    lblMessage.Text = "Course Deleted";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    conn.Close();
                }
                else
                {
                    lblMessage.Text = "Invalid Course ID";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Course Can't be deleted";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }



            
        }

        private bool courseExists(int courseid, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Course WHERE course_id = @courseID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@courseID",courseid));

                conn.Open();

                int courseCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return courseCount > 0;
            }
        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
        }
}