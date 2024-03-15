using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class StudentviewUpcomingInstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInstallmentDeadline();
            }
        }

        private void LoadInstallmentDeadline()
        {
            try
            {
                int studentID = Convert.ToInt32(Request.Cookies["UserID"].Value);
                string connectionString = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("select dbo.FN_StudentUpcoming_installment(@student_ID)", connection))
                    {
                        // command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@student_ID", studentID));

                        connection.Open();

                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            lblResult.Text = ((DateTime)result).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            lblResult.Text = "No Upcoming Installments";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or display an error message.
                lblResult.Text = "An error occurred: " + ex.Message;
            }
        }
        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");

        }
    }
}