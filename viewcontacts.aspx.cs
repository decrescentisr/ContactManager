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
    public partial class viewcontacts : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; //Connects to database through ConnectionString in the Web.Config file
        SqlConnection con;
        SqlCommand com;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Sets security level to Employee, Manager and User only
            if (Session["Security"].ToString() == "Employee" || Session["Security"].ToString() == "Manager")
            {
                //Do nothing
            }
            else if (Session["Security"].ToString() == "Non-Employee" || Session["Security"].ToString() == "")
            {
                //If the user is not a employee or if they do not register with employee, manager or non-employee, then they are redirected back to the portal
                Server.Transfer("portal.html", true);
            }
            else
            {
                //Anyone else is redirected back to the login page
                Server.Transfer("login.aspx", true);
            }
        }

        //Method that allows users to search for business listing using business name string within textbox controls  
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; //Connects to database through ConnectionString in the Web.Config file 
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand()) //Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
                {
                    string sql = "SELECT * from Contact"; //SQL statement which selects information and lists within gridview
                    if (!string.IsNullOrEmpty(txtBusiness.Text.Trim())) //If textbox controls are empty, list all data
                    {
                        //Uses SQL parameterization to prevent injection vulnerabilities
                        sql += " WHERE BusinessName LIKE @business AND FirstName LIKE @first + '%'";//Lists data based on Business Name and First Name of contact. 
                        cmd.Parameters.AddWithValue("@business", txtBusiness.Text.Trim());
                        cmd.Parameters.AddWithValue("@first", txtFirstName.Text.Trim());

                    }
                    cmd.CommandText = sql; //Gets or sets the Transact-SQL statement, table name or stored procedure to execute at the data source.
                    cmd.Connection = con; //Connects to command
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd)) //Represents a set of data commands and a database connection that are used to fill the DataSet and update a SQL Server database. 
                    {
                        DataTable dt = new DataTable(); //Uses data table
                        sda.Fill(dt); //Fills data table with data
                        grdRoster.DataSource = dt; //Uses data source for gridview control
                        grdRoster.DataBind(); //Binds data to gridview control
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); //Connects to database through ConnectionString in the Web.Config file
            //Updates First and Last Name and Business Name from Contact database
            try
            {
                con.Open(); //Opens connection

                //uses parameterization to prevent SQL injection
                string command = "UPDATE Contact SET FirstName=@first, LastName=@last, BusinessName=@business" +
                    " WHERE Email=@email";
                SqlCommand com = new SqlCommand(command, con); //Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.

                //Adds parameters with value to database based on information submitted in the form. Uses SQL parameterization to prevent injection vulnerabilities.
                com.Parameters.AddWithValue("@first", txtFirstName.Text);
                com.Parameters.AddWithValue("@last", txtLastName.Text);
                com.Parameters.AddWithValue("@business", txtBusiness.Text);
                com.Parameters.AddWithValue("@email", txtEmail.Text);

                com.ExecuteNonQuery();

                lblUpdateMessage.Visible = true;

            }
            catch (Exception ex) //posts exception if system error
            {
                lblMessage.Text = "Something went wrong. Please try again.";
                throw;

            }
            finally
            {
                con.Close(); //Closes connection
               
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); //Connects to database through ConnectionString in the Web.Config file
            //Deletes all fields from Contact database using Business Name as identifier
            try
            {
                con.Open(); //Opens connection

                //uses parameterization to prevent injection
                string command = "DELETE FROM Contact WHERE Email = @email";
                SqlCommand com = new SqlCommand(command, con); //Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
                //Adds parameters with value to database based on information submitted in the form
                com.Parameters.AddWithValue("@email", txtEmail.Text);
                
                
                com.ExecuteNonQuery();

                lblDeleteMessage.Visible = true;

            }
            catch (Exception ex) //posts exception if system error
            {
                lblMessage.Text = "Something went wrong. Please try again.";
                throw;

            }
            finally
            {
                con.Close(); //Closes connection
                
            }

        }
    }
}