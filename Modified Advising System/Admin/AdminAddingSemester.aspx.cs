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
    public partial class AdminAddingSemester : System.Web.UI.Page
    {
        protected void AddSemester(object sender, EventArgs e)
        {
            ;



            string c = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
            SqlConnection conn = new SqlConnection(c);

            String Start_date = Start.Text;
            String End_date = End.Text;
            String Scode = Code.Text;

            SqlCommand proc = new SqlCommand("AdminAddingSemester", conn);


            if (string.IsNullOrWhiteSpace(Start_date) || string.IsNullOrWhiteSpace(End_date) || string.IsNullOrWhiteSpace(Scode))

            {
                lblMessage.Text = "Please fill out the data correctly";
                lblMessage.ForeColor = System.Drawing.Color.Red;


            }
            else
            {

                if (DateTime.Parse(Start_date) > DateTime.Parse(End_date))
                {
                    lblMessage.Text = "Start date cannot be after the end date";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (DateTime.Parse(Start_date) == DateTime.Parse(End_date))
                {
                    lblMessage.Text = "Start date cannot be same day as the end date";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Scode.Length == 3)
                {
                    if ((Scode[0] != 'W' && Scode[0] != 'S') ||
                        Scode[1] < '0' || Scode[1] > '9' ||
                        Scode[2] < '0' || Scode[2] > '9')
                    {
                        lblMessage.Text = "Semester Code should be in the format (S23)";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else if (Scode.Length == 5)
                {
                    if ((Scode[0] != 'W' && Scode[0] != 'S') ||
                        Scode[1] < '0' || Scode[1] > '9' ||
                        Scode[2] < '0' || Scode[2] > '9' ||
                        Scode[3] != 'R' ||
                        (Scode[4] != '1' && Scode[4] != '2'))
                    {
                        lblMessage.Text = "Semester Code should be in the format (S23R1 or S23R2)";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else
                {
                    lblMessage.Text = "Semester Code should be in the format (S23) or (S23R1 or S23R2)";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }


                if (SemesterExists(Scode, conn))
                {
                    lblMessage.Text = "Semester Code Already Exists";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;

                }
                proc.CommandType = System.Data.CommandType.StoredProcedure;

                proc.Parameters.Add(new SqlParameter("@start_date", Start_date));
                proc.Parameters.Add(new SqlParameter("@end_date", End_date));
                proc.Parameters.Add(new SqlParameter("@semester_code", Scode));

                conn.Open();
                proc.ExecuteNonQuery();
                lblMessage.Text = "Semester added successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                conn.Close();

            }


        }
        private bool SemesterExists(string semesterCode, SqlConnection conn)
        {
            // Query to check if the semester code exists
            string query = "SELECT COUNT(*) FROM Semester WHERE semester_code = @SemesterCode";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@SemesterCode", semesterCode));

                conn.Open();

                int semesterCount = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return semesterCount > 0;
            }
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Dashboard.aspx");
        }
    }
}