using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class AdminAddingCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddCourse(object sender, EventArgs e)
        {
            string c = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection conn = new SqlConnection(c);

            SqlCommand proc = new SqlCommand("Procedures_AdminAddingCourse", conn);


            String Cname = name.Text;

        
            int Csemester;
            int CH;
            int Cbit;
            if (Int32.TryParse(semester.Text, out Csemester) && Int32.TryParse(hours.Text, out CH)
                && Int32.TryParse(bit.Text, out Cbit ) && !String.IsNullOrWhiteSpace(Cname))
            {
                Csemester = Convert.ToInt32(semester.Text);
                CH = Convert.ToInt32(hours.Text);
                Cbit = Convert.ToInt32(bit.Text);

                if(Cbit !=0 && Cbit != 1)
                {
                    lblMessage.Text = "Course Bit is either 0 or 1";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }

                if (CourseExists(Cname, conn))
                {
                    lblMessage.Text = "Course name already taken ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }

                proc.CommandType = System.Data.CommandType.StoredProcedure;

                proc.Parameters.Add(new SqlParameter("@major", DropDownList1.SelectedValue));
                proc.Parameters.Add(new SqlParameter("@semester", Csemester));
                proc.Parameters.Add(new SqlParameter("@credit_hours", CH));
                proc.Parameters.Add(new SqlParameter("@name", Cname));
                proc.Parameters.Add(new SqlParameter("@is_offered", Cbit));


                conn.Open();
                proc.ExecuteNonQuery();
                lblMessage.Text = "Course added successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                conn.Close();

            }
            else
            {
                lblMessage.Text = "Please fill out the data correctly";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }



        }

        private bool CourseExists(string course_name, SqlConnection conn)
        {
            // Query to check if the course name exists
            string query = "SELECT COUNT(*) FROM Course WHERE name = @course_name";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@course_name", course_name));

                conn.Open();

                int courseCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return courseCount > 0;
            }
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }





    }
}