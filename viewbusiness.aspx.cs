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
    public partial class viewbusiness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sets security level to Employee and Manager only
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

        //Method that allows users to search for business listing using phone number string within textbox controls  
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; //Connects to database through ConnectionString in the Web.Config file 
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand()) //Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
                {
                    string sql = "SELECT BusinessName, Address, Phone, CompanyType from Business"; //SQL statement which selects information and lists within gridview
                    if (!string.IsNullOrEmpty(txtPhone.Text.Trim())) //If textbox controls are empty, list all data
                    {
                        sql += " WHERE Phone LIKE @phone + '%'"; //List's data based on business phone number
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());//Uses SQL parameterization to prevent injection vulnerabilities

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
            //Updates Phone, Address and Business Name from Business database
            try
            {
                con.Open(); //Opens connection

                //uses parameterization in SQL statement to prevent injection
                string command = "UPDATE Business SET Phone=@phone, Address=@address" +
                    " WHERE BusinessName=@business";
                SqlCommand com = new SqlCommand(command, con); //Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
               
                //Adds parameters with value to database based on information submitted in the form. Uses SQL parameterization to prevent injection vulnerabilities.
                com.Parameters.AddWithValue("@phone", txtPhone.Text);
                com.Parameters.AddWithValue("@address", txtAddress.Text);
                com.Parameters.AddWithValue("@business", txtBusiness.Text);


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
                
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); //Connects to database through ConnectionString in the Web.Config file
            //Deletes all fields from Business database with Business Name as identifier
            try
            {
                con.Open(); //Opens connection

                //uses parameterization to prevent SQL injection
                string command = "DELETE FROM Business WHERE BusinessName = @business";
                SqlCommand com = new SqlCommand(command, con); //Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
                //Adds parameters with value to database based on information submitted in the form
                com.Parameters.AddWithValue("@business", txtBusiness.Text);


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
                
            }

        }
    }
}