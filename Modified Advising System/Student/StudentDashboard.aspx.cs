using System;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class StudentDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];
            if (userIdCookie != null)
            {
                int userId = Convert.ToInt32(userIdCookie.Value);
                // You can use userId as needed in your page
            }

            if (!IsPostBack)
            {
                LoadStudentInfo();
            }
        }
        protected void SignOut(object sender, EventArgs e)
        {
            // Clear the user ID cookie
            HttpCookie userIdCookie = new HttpCookie("UserID");
            userIdCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userIdCookie);

            // Redirect to the login page
            Response.Redirect("StudentLogin.aspx");

        }

        protected void LoadStudentInfo()
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];
            if (userIdCookie != null)
            {
                int userId = Convert.ToInt32(userIdCookie.Value);
                // Fetch student info from the database based on the user ID
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Advising_Management_System"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE student_id = @StudentID", connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                HtmlGenericControl welcomeMessage = (HtmlGenericControl)FindControl("welcomeMessage");
                                if (welcomeMessage != null)
                                {
                                    welcomeMessage.InnerText = $"Hello {reader["f_name"]}, welcome to the GUC Advising System";
                                }

                                lblFullName.InnerText = $"Full Name: {reader["f_name"]} {reader["l_name"]}";
                                lblStudentID.InnerText = $"Student ID: {reader["student_id"]}";
                               // lblStatus.InnerText = $"Status: {(Convert.ToBoolean(reader["financial_status"]) ? "Active" : "Inactive")}";
                                lblMail.InnerText = $"GUC Mail: {reader["email"]}";
                                lblFaculty.InnerText = $"Faculty: {reader["faculty"]}";
                                lblMajor.InnerText = $"Major: {reader["major"]}";
                                lblSemester.InnerText = $"Semester: {reader["semester"]}";
                                lblAssignedHours.InnerText = $"Assigned Hours: {reader["assigned_hours"]}";
                                lblRequiredHours.InnerText = $"Required Hours: {reader["acquired_hours"]}";

                            }
                        }
                    }
                }
            }
        }


    }
}

