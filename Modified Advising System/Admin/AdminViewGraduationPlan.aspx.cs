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
    public partial class AdminViewGraduationPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            //create a new connection to the database using above str (database we want)
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand viewgradplans = new SqlCommand("SELECT * FROM Advisors_Graduation_Plan", conn);

            viewgradplans.CommandType = System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader reader = viewgradplans.ExecuteReader();

            if (reader.HasRows)
            {
                viewgradplanlist.Text = "<table border='3'> <tr><th>Plan ID</th><th>Semester Code</th><th>Semester Credit Hours</th><th>Expected Graduation Date</th><th>Advisor ID</th><th>Student ID</th><th>Advisor Name</th></tr>";

                while (reader.Read())
                {
                    viewgradplanlist.Text += "<tr>";
                    viewgradplanlist.Text += "<td>" + reader["plan_id"] + "</td>";
                    viewgradplanlist.Text += "<td>" + reader["semester_code"] + "</td>";
                    viewgradplanlist.Text += "<td>" + reader["semester_credit_hours"] + "</td>";
                    viewgradplanlist.Text += "<td>" + reader["expected_grad_date"] + "</td>";
                    viewgradplanlist.Text += "<td>" + reader["advisor_id"] + "</td>";
                    viewgradplanlist.Text += "<td>" + reader["student_id"] + "</td>";
                    viewgradplanlist.Text += "<td>" + reader["advisor_name"] + "</td>";
                    viewgradplanlist.Text += "</tr>";
                }

                viewgradplanlist.Text += "</table>";
            }
            else
            {
                // Format the message to be bigger, bold, and positioned lower on the page
                viewgradplanlist.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>No Graduation Plans Found</div>";
            }
            conn.Close();
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
    }
}