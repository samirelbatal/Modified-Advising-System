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
    public partial class AdminViewSemestersWithOfferedCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection s = new SqlConnection(conn);

            SqlCommand sql = new SqlCommand("SELECT * FROM Semster_offered_Courses", s);
            sql.CommandType = CommandType.Text;


            s.Open();
            SqlDataReader sdr = sql.ExecuteReader(CommandBehavior.CloseConnection);
            String html = "";
            while (sdr.Read())
            {
                String Cname = sdr.GetString(sdr.GetOrdinal("name"));
                Label Course_name = new Label();
                Course_name.Text = Cname;
                // form1.Controls.Add(name);

                int Cid = sdr.GetInt32(sdr.GetOrdinal("course_id"));
                Label Course_id = new Label();
                Course_id.Text = Cid.ToString();

                String Scode = sdr.GetString(sdr.GetOrdinal("semester_code"));
                Label Semester_Code = new Label();
                Semester_Code.Text = Scode;
                // form1.Controls.Add(email);



                html = html + "<div class='flexbox2'><div class='content1'>" + Course_name.Text + "</div><div class='content2'>" + Course_id.Text + "</div><div class='content3'>" + Semester_Code.Text + "</div></div>";


            }
            flow.InnerHtml = html;




        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }

    }
}
