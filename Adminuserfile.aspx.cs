﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;


public partial class Doctoruserfile : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename= |DataDirectory|\Rolldb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }
    string key, mail;

    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string id = grdrow.Cells[0].Text;

        con.Open();
        cmd = new SqlCommand("select * from Userfiletb where id='" + id + "' ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            key = dr["Keys"].ToString();
        }
        con.Close();



        con.Open();
        cmd = new SqlCommand("update userfiletb  set Status='Approved',date='" + TextBox1.Text + "',Time='" + TextBox2.Text + "' where id='" + id + "' ", con);
        cmd.ExecuteNonQuery();
        con.Close();
        bind();

        con.Open();
        cmd = new SqlCommand("select * from uregtb where UserName='" + grdrow.Cells[4].Text + "' ", con);
        SqlDataReader dr1 = cmd.ExecuteReader();
        if (dr1.Read())
        {
            mail = dr1["Email"].ToString();
        }
        con.Close();


        string to = mail;
        string from = "projectmailm@gmail.com";
        // string subject = "Key";
        // string body = TextBox1.Text;
        string password = "qmgn xecl bkqv musr";
        using (MailMessage mm = new MailMessage(from, to))
        {
            mm.Subject = "Keys";
            mm.Body = "File Id" + id + "Your Download Key:" + key + " key Valid" + TextBox1.Text + TextBox2.Text;
            //if (fuAttachment.HasFile)
            //{
            //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
            //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
            //}
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(from, password);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);

        }

    }

    private void bind()
    {
        cmd = new SqlCommand("select * from userfiletb where Status='waiting' and AdminName='" + Session["dname"].ToString() + "'", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        cmd = new SqlCommand("select * from userfiletb where Status='Approved' and AdminName='" + Session["dname"].ToString() + "' ", con);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();

    }
}