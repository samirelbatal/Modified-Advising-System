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
    public partial class Studentaddphonenumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");

        }
        protected void addphoneButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve user ID from the cookie
                HttpCookie userIdCookie = Request.Cookies["UserID"];

                if (userIdCookie != null)
                {
                    int studentId = Convert.ToInt32(userIdCookie.Value);

                    // Retrieve semester code from the TextBox
                    string phonenum = phonenumtext.Text;

                    // Validate that the user entered at least 3 characters for the semester code
                    if (phonenum.Length != 0)
                    {
                        // Proceed with the logic using the entered semester code
                        string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            conn.Open();

                            string query = "Procedures_StudentaddMobile";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentId });
                                cmd.Parameters.Add(new SqlParameter("@mobile_number", SqlDbType.VarChar, 40) { Value = phonenum });

                                SqlDataReader reader = cmd.ExecuteReader();

                                errormessage.Text = "<div class='message' style='color: green; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>Your Phone Number is added successfully</div>";
                            }
                        }
                    }
                    else
                    {
                        errormessage.Text = "<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>Please enter a Phone Number</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and print the same error message
                errormessage.Text = $"<div class='message' style='color: red; font-size: 24px; font-weight: bold; text-align: center; margin-top: 50px;'>This Phone Number is already saved</div>";
            }
        }

    }
}