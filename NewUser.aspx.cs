using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class NewUser : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Rolldb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }
   


    string publickey;

    protected void Button1_Click(object sender, EventArgs e)
    {


     


        cmd = new SqlCommand("select * from uregtb where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' ", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            dr.Close();

            Response.Write("<Script> alert('Already Register Username and Password!') </Script>");


        }
        else
        {
            dr.Close();


            cmd = new SqlCommand("insert into uregtb values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + RadioButtonList1.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" +
                TextBox5.Text + "','" + TextBox9.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + publickey + "','waiting')", con);
            //  con.Open();
            cmd.ExecuteNonQuery();
            // con.Close();
            Response.Write("<Script> alert('New User Info Saved!') </Script>");






          
        }
        con.Close();




    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";

        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";






    }
}
