using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class UserLogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Rolldb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        cmd = new SqlCommand("select * from uregtb where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' and PublicKey='" + TextBox3.Text + "' ", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
           
            Session["uname"] = TextBox1.Text;

            Session["dname"] = dr["DName"].ToString();

            Session["mob"] = dr["Mobile"].ToString();
            Session["mail"] = dr["Email"].ToString();

            Response.Redirect("UserHome.aspx");




        }
        else
        {
            Response.Write("<Script> alert('Username or Password Incorrect!') </Script>");
        }
        con.Close();
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand("select * from uregtb where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' and PublicKey='" + TextBox3.Text + "' ", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            Session["uname"] = TextBox1.Text;

          //  Session["dname"] = dr["DName"].ToString();

            Session["mob"] = dr["Mobile"].ToString();
            Session["mail"] = dr["Email"].ToString();

            Response.Redirect("UserHome.aspx");




        }
        else
        {
            Response.Write("<Script> alert('Username or Password Incorrect!') </Script>");
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";


    }
}