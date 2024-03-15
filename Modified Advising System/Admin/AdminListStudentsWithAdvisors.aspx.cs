using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Modified_Advising_System
{
    public partial class AdminListStudentsWithAdvisors : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            string c = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection conn = new SqlConnection(c);

            SqlCommand sql = new SqlCommand("AdminListStudentsWithAdvisors", conn);
            sql.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader sdr = sql.ExecuteReader(CommandBehavior.CloseConnection);
            String html = "";
            while (sdr.Read())
            {
                String Advisor_name = sdr.GetString(sdr.GetOrdinal("advisor_name"));
                Label advisorLabel = new Label();
                advisorLabel.Text =  Advisor_name;
               // form1.Controls.Add(advisorLabel);

                String Student_fname = sdr.GetString(sdr.GetOrdinal("f_name"));
                Label fnameLabel = new Label();
                fnameLabel.Text =  Student_fname;
                //form1.Controls.Add(fnameLabel);

                String Student_lname = sdr.GetString(sdr.GetOrdinal("l_name"));
                Label lnameLabel = new Label();
                lnameLabel.Text =  Student_lname;
               // form1.Controls.Add(lnameLabel);

                int Advisor_id = sdr.GetInt32(sdr.GetOrdinal("advisor_id"));
                Label Aid = new Label();
                Aid.Text = Advisor_id.ToString(); // Convert int to string

                int Student_id = sdr.GetInt32(sdr.GetOrdinal("Student_id"));
                Label Sid = new Label();
                Sid.Text = Student_id.ToString();


                html = html + "<div class='flexbox2'><div class='content1'>" + fnameLabel.Text + "</div><div class='content2'>" + lnameLabel.Text + "</div><div class='content3'>" + Sid.Text + "</div><div class='content4'>" + advisorLabel.Text + "</div><div class='content5'>" + Aid.Text + "</div></div>";

                //Add a line break between each student's information
            }
            flow.InnerHtml = html;
        }
        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }
    }

    

}