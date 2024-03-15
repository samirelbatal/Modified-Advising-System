using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modified_Advising_System
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SignOutLink_Click(object sender, EventArgs e)
        {
            // Perform sign-out logic here, such as clearing session variables, redirecting to the login page, etc.
            Session.Clear(); // Clear session variables
            Response.Redirect("Login.aspx"); // Redirect to the login page
        }

    }
}