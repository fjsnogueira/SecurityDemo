using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XSSDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                lblEntered.Text = String.Format("User Name : {0} </br> Mail : {1}", txtName.Text, txtEmail.Text);
            }
        }
    }
}