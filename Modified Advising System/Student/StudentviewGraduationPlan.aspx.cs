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
    public partial class StudentviewGraduationPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(Request.Cookies["UserID"].Value);

                string connectionString = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand gradPlan = new SqlCommand("SELECT student_name, plan_id, semester_code, semester_credit_hours, expected_grad_date, advisor_id, student_id, course_id, name FROM FN_StudentViewGP(@student_ID)", connection))
                    {
                        gradPlan.Parameters.Add(new SqlParameter("@student_ID", studentID));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(gradPlan))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                GridView1.DataSource = dataTable;
                                GridView1.DataBind();
                            }
                            else
                            {
                                Response.Write("No graduation plan found for the given student ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDashboard.aspx");

        }
    }
}