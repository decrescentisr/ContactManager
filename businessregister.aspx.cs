using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactManager
{
    public partial class businessregister : System.Web.UI.Page
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
            //Inserts into Business database for rest of form information outside of file upload control
            try
            {
                con.Open(); //Opens connection
                
                //uses parameterization to prevent SQL injection
                string command = "INSERT INTO Business(BusinessName,Address,Phone, CompanyType) VALUES(@business, @address, @phone, @company)";
                SqlCommand com = new SqlCommand(command, con); //Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
                //Adds parameters with value to database based on information submitted in the form
                com.Parameters.AddWithValue("@business", txtName.Text);
                com.Parameters.AddWithValue("@address", txtAddress.Text);
                com.Parameters.AddWithValue("@phone", txtPhone.Text);
                com.Parameters.AddWithValue("@company", ddlCompany.SelectedItem.Text);
                com.ExecuteNonQuery();

                lblMessage.Visible = true;

            }
            catch (Exception ex) //posts exception if system error
            {
                lblMessage.Text = "Something went wrong. Please try again.";
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
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
    }
}