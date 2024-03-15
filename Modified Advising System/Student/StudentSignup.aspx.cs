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
    public partial class StudentSignup : System.Web.UI.Page
    {



        protected void signup(object sender, EventArgs e)
        {
           



                // Retrieve connection string from Web.config
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

                // Create SqlConnection and SqlCommand
                using (SqlConnection connect = new SqlConnection(connStr))
                {
                    connect.Open();

                    using (var command = connect.CreateCommand())
                    {
                        command.CommandText = "Procedures_StudentRegistration";
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        command.Parameters.AddWithValue("@first_name", txtFirstname.Text);
                        command.Parameters.AddWithValue("@last_name", txtLastName.Text);
                        command.Parameters.AddWithValue("@password", txtPassword.Text);
                        command.Parameters.AddWithValue("@faculty", txtFaculty.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@major", txtMajor.Text);
                        command.Parameters.AddWithValue("@semester", Convert.ToInt32(txtSemester.Text));

                        // Output parameter for Student_id
                        SqlParameter studentIdParam = command.Parameters.Add("@Student_id", SqlDbType.Int);
                        studentIdParam.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        // Retrieve the output value
                        int studentId = Convert.ToInt32(studentIdParam.Value);



                        // Set a cookie with the user ID
                        HttpCookie userIdCookie = new HttpCookie("UserID", studentId.ToString());
                        Response.Cookies.Add(userIdCookie);


                        Response.Redirect("StudentDashboard.aspx");

                        // Close the connection
                        connect.Close();
                    }
                }
            
           
        }
    }
}