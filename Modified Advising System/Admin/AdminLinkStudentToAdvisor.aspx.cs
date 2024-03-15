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
    public partial class AdminLinkStudentToAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkStudent(object sender, EventArgs e)
        {
            string c = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection conn = new SqlConnection(c);

            SqlCommand proc = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn);

            int Advisor_id;
            int Student_id;

            if(Int32.TryParse(ADVISOR.Text, out Advisor_id) && Int32.TryParse(STUDENT.Text, out Student_id)){
                Advisor_id = Convert.ToInt32(ADVISOR.Text);
                Student_id = Convert.ToInt32(STUDENT.Text);
                if (!AdvisorExists(Advisor_id, conn))
                {
                    lblMessage.Text = "Advisor doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!StudentExists(Student_id, conn))
                {
                    lblMessage.Text = "Student doesnt Exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (CheckLinkExists(Student_id, Advisor_id, conn)){
                    lblMessage.Text = "This Advisor is already Assigned to this Student";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                proc.CommandType = System.Data.CommandType.StoredProcedure;

                proc.Parameters.Add(new SqlParameter("@studentID", Student_id));
                proc.Parameters.Add(new SqlParameter("@advisorID", Advisor_id));

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

        private bool AdvisorExists(int Advisor_id, SqlConnection conn)
        {
            // Query to check if the Instructor id exists
            string query = "SELECT COUNT(*) FROM Advisor WHERE advisor_id = @Advisor_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Advisor_id", Advisor_id));

                conn.Open();

                int AdvisorCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return AdvisorCount > 0;
            }
        }

        private bool StudentExists(int Student_id, SqlConnection conn)
        {
            // Query to check if the Slot id exists
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

        private bool CheckLinkExists(int Student_id, int Advisor_id, SqlConnection conn)
        {
            // Query to check if the Instructor id exists
            string query = "SELECT COUNT(*) FROM Student WHERE advisor_id = @Advisor_id and student_id = @Student_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Student_id", Student_id));
                cmd.Parameters.Add(new SqlParameter("@Advisor_id", Advisor_id));



                conn.Open();

                int Count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return Count > 0;
            }
        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }

    }
}