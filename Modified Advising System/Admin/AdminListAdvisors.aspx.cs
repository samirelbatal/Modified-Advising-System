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
    public partial class AdminListAdvisors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection s = new SqlConnection(conn);

            SqlCommand sql = new SqlCommand("Procedures_AdminListAdvisors", s);
            sql.CommandType = CommandType.StoredProcedure;

            s.Open();
            SqlDataReader sdr = sql.ExecuteReader(CommandBehavior.CloseConnection);
            String html = "";
            while (sdr.Read())
            {
                String Advisor_name = sdr.GetString(sdr.GetOrdinal("advisor_name"));
                Label name = new Label();
                name.Text = Advisor_name;
               // form1.Controls.Add(name);

                int Advisor_id = sdr.GetInt32(sdr.GetOrdinal("advisor_id"));
                Label id = new Label();
                id.Text =Advisor_id.ToString(); // Convert int to string
               // form1.Controls.Add(id);

                String Advisor_email = sdr.GetString(sdr.GetOrdinal("email"));
                Label email = new Label();
                email.Text =Advisor_email;
               // form1.Controls.Add(email);

                String Advisor_office = sdr.GetString(sdr.GetOrdinal("office"));
                Label office = new Label();
                office.Text =Advisor_office;
               // form1.Controls.Add(office);

                String Advisor_password = sdr.GetString(sdr.GetOrdinal("password"));
                Label password = new Label();
                password.Text =Advisor_password;
                //form1.Controls.Add(office);

                html = html + "<div class='flexbox2'><div class='content1'>" + name.Text + "</div><div class='content2'>" + id.Text + "</div><div class='content3'>" + email.Text + "</div><div class='content4'>" + office.Text + "</div><div class='content5'>" + password.Text + "</div></div>";

            }
            flow.InnerHtml = html;




        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }
    }
}