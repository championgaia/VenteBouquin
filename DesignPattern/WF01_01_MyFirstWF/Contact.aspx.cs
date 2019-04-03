using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF01_01_MyFirstWF
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divMessage.Attributes.Add("style", "color:red;");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = string.Format("You said your name is {0} and your age us {1} and you email is {2}. Your favorite color is {3}",
                txtName.Text, txtAge.Text, txtEmail.Text, ddlColor.SelectedValue);
            ltMessage.Text = message;

       
        }
    }
}