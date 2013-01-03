using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace SQLInjection
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ToString());
                string username=Request.Form["UserName"];
                string password=Request.Form["Password"];
                SqlCommand sqlCommand = new SqlCommand(
                    String.Format("Select name from Employee where name='{0}' and password='{1}'",
                    username, password), sqlConnection);
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    string name=dataReader[0].ToString();
                    sqlConnection.Close();
                    if (name == username)
                    {
                        Response.Redirect("Success.aspx");
                    }
                    else
                    {
                        Response.Redirect("Failure.aspx");
                    }
                }
                
            }
        }
    }
}