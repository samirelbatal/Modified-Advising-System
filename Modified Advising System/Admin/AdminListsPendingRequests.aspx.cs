using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Modified_Advising_System
{
    public partial class AdminListsPendingRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string c = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection conn = new SqlConnection(c);

            SqlCommand sql = new SqlCommand("SELECT * FROM all_Pending_Requests", conn);
            sql.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader sdr = sql.ExecuteReader(CommandBehavior.CloseConnection);
            String html = "";
            while (sdr.Read())
            {
                int request_id = sdr.GetInt32(sdr.GetOrdinal("request_id"));
                Label Rid = new Label();
                Rid.Text = request_id.ToString(); // Convert int to string

                // Example: Retrieving advisor name, student name, and request details
                String type = sdr.GetString(sdr.GetOrdinal("type"));
                Label Request_type = new Label();
                Request_type.Text = type;
                //form1.Controls.Add(Request_type);

                String comment = sdr.GetString(sdr.GetOrdinal("comment"));
                Label Request_comment = new Label();
                Request_comment.Text = comment;
                //form1.Controls.Add(Request_comment);

                String status = sdr.GetString(sdr.GetOrdinal("status"));
                Label Request_status = new Label();
                Request_status.Text = status;
                //form1.Controls.Add(Request_status);


                Label Request_CH = new Label();
                Label Request_course_id = new Label();


                if (Request_type.Text == "course")
                {

                    int course_id = sdr.GetInt32(sdr.GetOrdinal("course_id"));
                    Request_course_id.Text = course_id.ToString(); // Convert int to string
                    Request_CH.Text = "--";


                }
                else if (Request_type.Text == "credit_hours")
                {
                    int CH = sdr.GetInt32(sdr.GetOrdinal("credit_hours"));
                    Request_CH.Text = CH.ToString(); // Convert int to string
                    Request_course_id.Text = "--";

                }
                else
                {
                    Request_CH.Text = "--";
                    Request_course_id.Text = "--";
                }



                int student_id = sdr.GetInt32(sdr.GetOrdinal("student_id"));
                Label Request_student_id = new Label();
                Request_student_id.Text = student_id.ToString(); // Convert int to string 

                int advisor_id = sdr.GetInt32(sdr.GetOrdinal("advisor_id"));
                Label Request_advisor_id = new Label();
                Request_advisor_id.Text = advisor_id.ToString();

                html = html + "<div class='flexbox2'><div class='content1'> " + Rid.Text + "</div><div class='content2'>" + Request_type.Text + "</div><div class='content3'>" + Request_comment.Text + "</div><div class='content4'>" + Request_status.Text + "</div><div class='content5'>" + Request_CH.Text + "</div> <div class='content6'>" + Request_course_id.Text + "</div><div class='content7'>" + Request_student_id.Text + "</div><div class='content8'>" + Request_advisor_id.Text + "</div> </div>";

            }
            flow.InnerHtml = html;
        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }
    }
}