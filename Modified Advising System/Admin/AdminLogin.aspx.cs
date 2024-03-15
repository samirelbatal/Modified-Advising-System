using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void choose(object sender, EventArgs e)
        {

            Response.Redirect("../chooseUser.aspx");

        }



        protected void Login(object sender, EventArgs e)
        {
            String id = USERNAME.Text;
            String pass = PASSWORD.Text;
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(pass))
            {
                lblMessage.Text = "Please Fill All the Required Fields";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (id == "55-27170" && pass == "samirelbatal")
            {
                Response.Redirect("Admin_Dashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Incorrect ID or Password";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }



        }
    }
}