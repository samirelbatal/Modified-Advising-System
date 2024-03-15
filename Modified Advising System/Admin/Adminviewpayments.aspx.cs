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
    public partial class Adminviewpayments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            //create a new connection to the database using above str (database we want)
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand viewpayments = new SqlCommand("SELECT * FROM Student_Payment", conn);

           viewpayments.CommandType=System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader reader = viewpayments.ExecuteReader();

            if (reader.HasRows)
            {
                viewpaymentlist.Text = "<table border='3'> <tr><th>studentID</th><th>First Name</th><th>Last Name</th><th>Payment ID</th><th>Amount</th><th>Start Date</th><th>Deadline</th><th>No.Installments</th><th>Fund Percentage</th><th>Status</th><th>Semester Code</th></tr>";

                while (reader.Read())
                {
                    viewpaymentlist.Text += "<tr>";
                    viewpaymentlist.Text += "<td>" + reader["studentID"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["f_name"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["l_name"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["payment_id"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["amount"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["startdate"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["deadline"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["n_installments"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["fund_percentage"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["status"] + "</td>";
                    viewpaymentlist.Text += "<td>" + reader["semester_code"] + "</td>";
                    viewpaymentlist.Text += "</tr>";
                }

                viewpaymentlist.Text += "</table>";
            }
            else
            {
                // Format the message to be bigger, bold, and positioned lower on the page
                viewpaymentlist.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>No payments found</div>";
            }
            conn.Close();


        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
    }
}