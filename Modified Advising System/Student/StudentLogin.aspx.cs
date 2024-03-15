using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

namespace Modified_Advising_System
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {

            
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_Management_System"].ToString();

            using (SqlConnection connect = new SqlConnection(connStr))
            {

                string userid = username.Text;
                string pass = password.Text;
                if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(pass))
                {
                    // Display a warning message if the entered value is not an integer
                    invalidAuth.Text = "<div class='message' style='color: red; font-size: 15px; font-weight: bold; text-align: center; margin-top: 1px;'>All fields must be filled</div>";
                    return;
                }
                else if (!int.TryParse(userid, out _))
                {
                    invalidAuth.Text = "<div class='message' style='color: red; font-size: 15px; font-weight: bold; text-align: center; margin-top: 1px;'>Invalid ID or Password</div>";
                    return;
                }

                int ID = Int16.Parse(username.Text);
                pass = password.Text;
              

                connect.Open();

                using (var command = connect.CreateCommand())
                {
                    command.CommandText = "SELECT dbo.FN_StudentLogin(@Student_id, @password) AS checks";

                    command.Parameters.AddWithValue("@Student_id", ID);
                    command.Parameters.AddWithValue("@password", pass);

                    int success = 0;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToInt16(reader["checks"]);
                        }
                    }

                    if (success == 1)
                    {
                        // Set a cookie with the user ID
                        HttpCookie userIdCookie = new HttpCookie("UserID", ID.ToString());
                        Response.Cookies.Add(userIdCookie);
                        Response.Redirect("StudentDashboard.aspx");
                    }
                    if(success == 0)
                    {
                        invalidAuth.Text = "<div class='message' style='color: red; font-size: 15px; font-weight: bold; text-align: center; margin-top: 1px;'>Invalid ID or Password</div>";
                    }


                }
            }
        }



        protected void choose(object sender, EventArgs e)
        {

            Response.Redirect("../chooseUser.aspx");

        }



    }
}



