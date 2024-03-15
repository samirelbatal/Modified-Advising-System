using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            // Get user inputs
            string pass = password.Text;
            string idlogin = id.Text;

            // Check if any of the fields are empty
            if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(idlogin))
            {
                // Display an error message if any field is empty
                Label1.Text = "<p style='color:red'>Please enter both ID and password.</p>";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.FN_AdvisorLogin(@ID, @password)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ID", idlogin));
                    cmd.Parameters.Add(new SqlParameter("@password", pass));

                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    conn.Close();

                    if (result != null && result != DBNull.Value)
                    {
                        bool loginSuccess = Convert.ToBoolean(result);

                        if (loginSuccess)
                        {
                            Session["user"] = idlogin;
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            Label1.Text = "<p style='color:red'>Invalid credentials. Please try again.</p>";
                        }
                    }
                    else
                    {
                        Label1.Text = "<p style='color:red'>Error in login process. Please try again.</p>";
                    }
                }
            }
        }

    }
}
