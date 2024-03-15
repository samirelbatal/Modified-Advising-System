using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Modified_Advising_System
{
    public partial class students : System.Web.UI.Page
    {



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"]?.ToString();
            string major = DropDownList1.SelectedValue;
            int advisorId = Convert.ToInt32(Session["user"]);
            SqlConnection conn = new SqlConnection(connStr);

            using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorViewAssignedStudents]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdvisorID", advisorId);
                cmd.Parameters.AddWithValue("@major", major);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Dictionary<int, StudentInfo> students = new Dictionary<int, StudentInfo>();

                while (reader.Read())
                {
                    int studentId = Convert.ToInt32(reader["student_id"]);

                    if (students.ContainsKey(studentId))
                    {
                        // Student already exists, update courses
                        students[studentId].Courses.Add(reader["Course_name"].ToString());
                    }
                    else
                    {
                        // Add a new student entry
                        StudentInfo student = new StudentInfo
                        {
                            StudentId = studentId,
                            StudentName = reader["Student_name"].ToString(),
                            Major = reader["major"].ToString(),
                            Courses = new List<string> { reader["Course_name"].ToString() }
                        };

                        students.Add(studentId, student);
                    }
                }

                conn.Close();

                // Display the results
                DisplayResults(students);
            }
        }

        private void DisplayResults(Dictionary<int, StudentInfo> students)
        {
            Response.Write("<table border='1'>");
            Response.Write("<tr><th>Student ID</th><th>Student Name</th><th>Student Major</th><th>Courses</th></tr>");

            foreach (var student in students.Values)
            {
                Response.Write("<tr>");
                Response.Write("<td>" + student.StudentId + "</td>");
                Response.Write("<td>" + student.StudentName + "</td>");
                Response.Write("<td>" + student.Major + "</td>");
                Response.Write("<td>" + string.Join(", ", student.Courses) + "</td>");
                Response.Write("</tr>");
            }

            Response.Write("</table>");
        }

        private class StudentInfo
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public string Major { get; set; }
            public List<string> Courses { get; set; }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cssLink = "<link rel='stylesheet' type='text/css' href='styles.css' />";
            LiteralControl literalCssLink = new LiteralControl(cssLink);
            Page.Header.Controls.Add(literalCssLink);
        }
    }


}
    
