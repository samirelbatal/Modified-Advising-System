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
    public partial class Adminissueinstallments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pay_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            //create a new connection to the database using above str (database we want)
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand installment = new SqlCommand("Procedures_AdminIssueInstallment ", conn);
            //store the paymentid from the textbox
            int payment;

            if (Int32.TryParse(PaymentID.Text, out payment))
            {
                payment = Convert.ToInt32(PaymentID.Text);
                installment.CommandType = System.Data.CommandType.StoredProcedure;
                installment.Parameters.Add(new SqlParameter("@payment_id", payment));
                if (!paymentExists(payment, conn))
                {
                    lblMessage.Text = "Payment Does not exist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                conn.Open();
                installment.ExecuteNonQuery();
                lblMessage.Text = "Installment Issued for Payment ID: "+payment;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                conn.Close();


            }
            else
            {
                lblMessage.Text = "Invalid Payment ID";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        private bool paymentExists(int paymentid, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Payment WHERE payment_id = @payment_id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@payment_id", paymentid));

                conn.Open();

                int paymentCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return paymentCount > 0;
            }
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_DashBoard.aspx");
        }
    }
}