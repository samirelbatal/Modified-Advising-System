using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class pendingrequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPendingRequests();
            }
        }

        protected void LoadPendingRequests()
        {
            int advisorId = Convert.ToInt32(Session["user"]);
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            string query = "EXEC Procedures_AdvisorViewPendingRequests @Advisor_ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Advisor_ID", SqlDbType.Int) { Value = advisorId });

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewRequests.DataSource = dt;
            GridViewRequests.DataBind();

            conn.Close();
        }





        protected void ProcessRequest(int requestId, string action)
        {
            string cssLink = "<link rel='stylesheet' type='text/css' href='styles.css' />";
            LiteralControl literalCssLink = new LiteralControl(cssLink);
            Page.Header.Controls.Add(literalCssLink);

            int advisorId = Convert.ToInt32(Session["user"]);
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            string getRequestTypeQuery = "SELECT type FROM Request WHERE request_id = @requestID";
            SqlCommand getRequestTypeCmd = new SqlCommand(getRequestTypeQuery, conn);
            getRequestTypeCmd.Parameters.AddWithValue("@requestID", requestId);

            string requestType = getRequestTypeCmd.ExecuteScalar()?.ToString();

            if (!string.IsNullOrEmpty(requestType))
            {

                if (requestType.ToLower().Contains("credit"))
                {
                    string chProcedureQuery = "EXEC Procedures_AdvisorApproveRejectCHRequest @requestID, @current_sem_code";
                    ExecuteProcedureWithSemesterCode(chProcedureQuery, requestId, "W23");
                    NotifyUser(requestId, action, isRequestAccept(requestId));

                }

                else if (requestType.ToLower().Contains("course"))
                {
                    string courseProcedureQuery = "EXEC Procedures_AdvisorApproveRejectCourseRequest @requestID, @current_semester_code";
                    ExecuteProcedureWithSemesterCode(courseProcedureQuery, requestId, "W23");

                    NotifyUser(requestId, action, isRequestAccept(requestId));

                }




                LoadPendingRequests();
            }

            conn.Close();
        }

        protected bool isRequestAccept(int requestId)
        {
            string query = "SELECT COUNT(*) FROM Request WHERE request_id = @request_id AND status='Accept'";
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@request_id", requestId));

                int reqcount = Convert.ToInt32(cmd.ExecuteScalar());

                return reqcount > 0;
            }
        }


        protected void ExecuteProcedureWithSemesterCode(string procedureQuery, int requestId, string semesterCode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(procedureQuery, conn);
                cmd.Parameters.Add(new SqlParameter("@requestID", SqlDbType.Int) { Value = requestId });
                if (procedureQuery == "EXEC Procedures_AdvisorApproveRejectCourseRequest @requestID, @current_semester_code")
                {
                    cmd.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.VarChar, 40) { Value = semesterCode });
                }
                else if (procedureQuery == "EXEC Procedures_AdvisorApproveRejectCHRequest @requestID, @current_sem_code")
                {
                    cmd.Parameters.Add(new SqlParameter("@current_sem_code", SqlDbType.VarChar, 40) { Value = semesterCode });

                }
                // Execute the stored procedure
                cmd.ExecuteNonQuery();
            }
        }

        protected void NotifyUser(int requestId, string action, bool isRequestAccepted)
        {
            if (isRequestAccepted)
            {
                // Notify the user that the request was accepted
                string script = "alert('Request " + requestId + " has been accepted.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                // Notify the user that the request was rejected
                string script = "alert('Request " + requestId + " has been rejected.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void handlerequest_Click(object sender, EventArgs e)
        {
            Button handlerequest = (Button)sender;
            int requestId = Convert.ToInt32(handlerequest.CommandArgument);
            ProcessRequest(requestId, "Handle");
        }

    }
}
