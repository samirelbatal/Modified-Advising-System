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
    public partial class AdminUpdateStudentStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateStatus(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            //create a new connection to the database using above str (database we want)
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand updstatus = new SqlCommand("Procedure_AdminUpdateStudentStatus", conn);
            //store the paymentid from the textbox
            int studentid;

            if (Int32.TryParse(sidinp.Text, out studentid))
            {
                studentid = Convert.ToInt32(sidinp.Text);
                updstatus.CommandType = System.Data.CommandType.StoredProcedure;
                //assign this variavle to the input
                updstatus.Parameters.Add(new SqlParameter("@student_id", studentid));
                if (!studentExists(studentid, conn))
                {
                    lblMessage.Text = "Student Does Not Exist " ;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                conn.Open();
                updstatus.ExecuteNonQuery();
                lblMessage.Text = "Financial Status has been Updated for this Student";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                conn.Close();


            }
            else
            {
                lblMessage.Text = "Invalid Student ID";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        private bool studentExists(int studentid, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Student WHERE student_id = @student_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@student_id", studentid));

                conn.Open();

                int sCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return sCount > 0;
            }
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
    }
}
