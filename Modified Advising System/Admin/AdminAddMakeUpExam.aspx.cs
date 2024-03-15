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
    public partial class AddMakeUpExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void funcaddexam(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            //create a new connection to the database using above str (database we want)
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand Addexam = new SqlCommand("Procedures_AdminAddExam", conn);

           // string type = examtype.Text;
            string date = exam_date.Text;

            int id;
            if (Int32.TryParse(course.Text, out id))
            {
                id = Convert.ToInt32(course.Text);
                Addexam.CommandType = System.Data.CommandType.StoredProcedure;

                Addexam.Parameters.Add(new SqlParameter("@courseID", id));
                Addexam.Parameters.Add(new SqlParameter("@date", date));
                Addexam.Parameters.Add(new SqlParameter("@Type", DropDownList1.SelectedValue));
                if (!courseExists(id, conn))
                {
                    lblMessage.Text = "Course Does Not Exist ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                conn.Open();
                Addexam.ExecuteNonQuery();
                lblMessage.Text = "Make UP Exam Added ";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                conn.Close();


            }
            else
            {
                lblMessage.Text = "Please Enter a valid Course ID ";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool courseExists(int courseid, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Course WHERE course_id = @courseID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@courseID", courseid));

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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}