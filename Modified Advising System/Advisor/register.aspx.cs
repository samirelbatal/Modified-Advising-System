using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RedirectToLogin(object sender, EventArgs e)
        {
            // Redirect to login.aspx
            Response.Redirect("login.aspx");
        }
        protected void Register(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string pass = password_reg.Text;
                string office = office_reg.Text;
                string name = name_reg.Text;
                string email = email_reg.Text;

                // Check if any of the fields are empty
                if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(office) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                {
                    Label1.Text = "<p style='color:red'>Please fill in all fields.</p>";
                    return;
                }

                using (SqlCommand regproc = new SqlCommand("[Procedures_AdvisorRegistration]", conn))
                {
                    regproc.CommandType = CommandType.StoredProcedure;

                    regproc.Parameters.Add(new SqlParameter("@advisor_name", name));
                    regproc.Parameters.Add(new SqlParameter("@password", pass));
                    regproc.Parameters.Add(new SqlParameter("@email", email));
                    regproc.Parameters.Add(new SqlParameter("@office", office));

                    SqlParameter id = regproc.Parameters.Add("@Advisor_id", SqlDbType.Int);
                    id.Direction = ParameterDirection.Output;

                    conn.Open();
                    regproc.ExecuteNonQuery();
                    int advisorid = Convert.ToInt32(id.Value);

                    conn.Close();

                    Label1.Text = "Advisor ID: " + advisorid;
                }
            }

        }
    }
}
