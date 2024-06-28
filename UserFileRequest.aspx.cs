using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class UserFileRequest : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|datadirectory|\Rolldb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }
    private void bind()
    {
        cmd = new SqlCommand("select * from filetb   ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        cmd = new SqlCommand("select * from Userfiletb  where UserName='" + Session["uname"].ToString() + "'", con);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();

    }

    string s1, s2,s3;
    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string id = grdrow.Cells[0].Text;

        con.Open();
        cmd = new SqlCommand("select * from filetb where id='" + id + "'  ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s1 = dr["Bpvalue"].ToString();
            s2 = dr["Sugarvalue"].ToString();
             s3 = dr["Keys"].ToString();
           //Keys

        }
        con.Close();
        //else
        //{
        //    dr.Close();

        con.Open();
        cmd = new SqlCommand("insert into Userfiletb values('" + grdrow.Cells[0].Text + "','" + grdrow.Cells[1].Text + "','" + grdrow.Cells[2].Text + "','" + grdrow.Cells[3].Text + "','" + Session["uname"].ToString() + "','waiting','" + s3 + "','','','" + s1 + "','" + s2 + "' )", con);
        cmd.ExecuteNonQuery();

        Response.Write("<Script> alert('Key Requst Send') </Script>");
        con.Close();
        //}
        //con.Close();
        bind();





    }
}