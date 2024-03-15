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
    public partial class AdminGetActiveStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            //create a new connection to the database using above str (database we want)
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand viewstudents = new SqlCommand("SELECT * FROM view_Students", conn);

            viewstudents.CommandType = System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader reader = viewstudents.ExecuteReader();

            if (reader.HasRows)
            {
                viewstudentslist.Text = "<table border='3'> <tr><th>studentID</th><th>First Name</th><th>Last Name</th><th>Password</th><th>GPA</th><th>Faculty</th><th>Email</th><th>Major</th><th>Financial Status</th><th>Semester</th><th>Acquired Hours</th><th>Assigned Hours</th><th>Advisor ID</th></tr>";

                while (reader.Read())
                {
                    viewstudentslist.Text += "<tr>";
                    viewstudentslist.Text += "<td>" + reader["student_id"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["f_name"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["l_name"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["password"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["gpa"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["faculty"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["email"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["major"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["financial_status"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["semester"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["acquired_hours"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["assigned_hours"] + "</td>";
                    viewstudentslist.Text += "<td>" + reader["advisor_id"] + "</td>";
                    viewstudentslist.Text += "</tr>";
                }

                viewstudentslist.Text += "</table>";
            }
            else
            {
                // Format the message to be bigger, bold, and positioned lower on the page
                viewstudentslist.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>No Active Students found</div>";
            }
            conn.Close();


        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
    }
    }
