using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cssLink = "<link rel='stylesheet' type='text/css' href='styles.css' />";
            LiteralControl literalCssLink = new LiteralControl(cssLink);
            Page.Header.Controls.Add(literalCssLink);

            int advisorId = Convert.ToInt32(Session["user"]);
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string query = "SELECT * FROM FN_Advisors_Requests(@AdvisorID)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@AdvisorID", SqlDbType.Int) { Value = advisorId });
            
            if (!requestsfound(advisorId, conn))
            {
                DisplayStyledMessage("There are no requests for this this advisor.", "red");
                return;
            }
        }

        private void DisplayStyledMessage(string message, string color)
        {
            Label1.Text = "<p class='styled-message' style='color:" + color + "'>" + message + "</p>";
        }
        private bool requestsfound(int advisorId, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM request WHERE advisor_id = @AdvisorId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@AdvisorId", advisorId));

                conn.Open();

                int assignmentCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return assignmentCount > 0;
            }
        }
    }
}
