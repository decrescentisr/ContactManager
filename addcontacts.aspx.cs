using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactManager
{
    public partial class addcontacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sets security level to Manager, Employee and Non-Employee only
            if (Session["Security"].ToString() == "Employee" || Session["Security"].ToString() == "Manager" || Session["Security"].ToString() == "Non-Employee")
            {
                //Do nothing
            }
            else if (Session["Security"].ToString() == "")
            {
                //If the user did not select Manager, Employee or Non-Employee at registration then they are redirected back to the portal
                Server.Transfer("portal.html", true);
            }
            else
            {
                //Anyone else is redirected back to the login page
                Server.Transfer("login.aspx", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); //Connects to database through ConnectionString in the Web.Config file

            try
            {
                con.Open(); //Opens database connection

                //uses parameterization to prevent SQL injection
                //inserts information to database after form submission
                string command = "INSERT INTO Contact(FirstName,LastName,DOB,Email,Phone,BusinessName) VALUES(@firstname, @lastname, @dob, @email, @phone,@business)";
                SqlCommand com = new SqlCommand(command, con);

                //Adds parameters with value to database based on information submitted in the form                
                com.Parameters.AddWithValue("@firstname", txtFirst.Text);
                com.Parameters.AddWithValue("@lastname", txtLast.Text);
                com.Parameters.AddWithValue("@dob", txtDOB.Text);
                com.Parameters.AddWithValue("@email", txtEmail.Text);
                com.Parameters.AddWithValue("@phone", txtPhone.Text);
                com.Parameters.AddWithValue("@business", txtBusiness.Text);

                com.ExecuteNonQuery();

                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Something went wrong. Please try again."; //posts exception if system error
                throw;
            }
            finally
            {
                con.Close(); //Closes connection
                Response.AddHeader("REFRESH", "10;URL=portal.html"); //Refreshes and redirects to portal.html within 10s.
            }

        }

        //Clear method when user clicks clear button
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFirst.Text = string.Empty;
            txtLast.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtBusiness.Text = string.Empty;
        }
    }
}