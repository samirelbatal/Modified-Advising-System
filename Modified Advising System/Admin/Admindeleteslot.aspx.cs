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
    public partial class Admindeleteslot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Deleteslot(object sender, EventArgs e)
        {
            try
            {
                string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
                //create a new connection to the database using above str (database we want)
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand deleteslots = new SqlCommand("Procedures_AdminDeleteSlots", conn);
                string sem = currentsem.Text;
                deleteslots.CommandType = System.Data.CommandType.StoredProcedure;

                deleteslots.Parameters.Add(new SqlParameter("@current_semester", sem));

                if (!semExists(sem, conn))
                {
                    lblMessage.Text = "Semester: " + sem + " does not exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                conn.Open();
                deleteslots.ExecuteNonQuery();
                lblMessage.Text = "Slots deleted for courses not in the semester: " + sem;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                conn.Close();
           
            }
            
            catch (Exception ex)
            {
                lblMessage.Text = "Enter Valid Semester: ";
                lblMessage.ForeColor = System.Drawing.Color.Green;

            }

        }

        private bool semExists(String semcode, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Semester WHERE semester_code = @current_semester";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@current_semester", semcode));

                conn.Open();

                int semCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return semCount > 0;
            }
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
    }
}