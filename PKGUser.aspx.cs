using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;


public partial class PKGUser : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Server=43.255.152.25;Database=FantasySolution_New;User ID=FantasySolutionnew;Password=FantasySolutionnew;Trusted_Connection=False");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    public static string pass(int length)
    {
        const string chars = "abcdefghijklmnopqstuuvwxyz";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

  
    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string id = grdrow.Cells[0].Text;

        string dname = grdrow.Cells[2].Text;

        string publickey = pass(6).ToString();
      

        con.Open();
        cmd = new SqlCommand("update uregtb  set PublicKey='" + publickey + "' where DName='" + dname + "' ", con);
        cmd.ExecuteNonQuery();
        con.Close();


        con.Open();
        cmd = new SqlCommand("Delete from  uregtb  where id='" + id + "' ", con);
        cmd.ExecuteNonQuery();
        con.Close();


        con.Open();
        cmd = new SqlCommand("update doctb  set PublicKey='" + publickey + "' where UserName='" + dname + "' ", con);
        cmd.ExecuteNonQuery();
        con.Close();



        //string to = grdrow.Cells[5].Text;
        //string from = "projectmailm@gmail.com";
        //// string subject = "Key";
        //// string body = TextBox1.Text;
        //string password = "qmgn xecl bkqv musr";
        //using (MailMessage mm = new MailMessage(from, to))
        //{
        //    mm.Subject = "Public Key";
        //    mm.Body = "Public Key :" + publickey.ToString();
        //    //if (fuAttachment.HasFile)
        //    //{
        //    //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
        //    //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
        //    //}
        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.EnableSsl = true;
        //    NetworkCredential NetworkCred = new NetworkCredential(from, password);
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = NetworkCred;
        //    smtp.Port = 587;
        //    smtp.Send(mm);
        //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);

        //}





        con.Open();
        cmd = new SqlCommand("select * from uregtb where DName='" + dname.ToString() + "'", con);
       SqlDataReader  dr = cmd.ExecuteReader();
       while (dr.Read())
       {

           DropDownList1.Items.Add(dr["Email"].ToString());
       }

        con.Close();

        for (int ii = 0; ii < DropDownList1.Items.Count; ii++)
        {

            //string to1 = DropDownList1.Items[ii].Text;
            //string from1 = "projectmailm@gmail.com";
            //// string subject = "Key";
            //// string body = TextBox1.Text;
            //string password1 = "qmgn xecl bkqv musr";
            //using (MailMessage mm = new MailMessage(from1, to1))
            //{
            //    mm.Subject = "Public Key";
            //    mm.Body = "Public Key :" + publickey.ToString();
            //    //if (fuAttachment.HasFile)
            //    //{
            //    //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
            //    //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
            //    //}
            //    mm.IsBodyHtml = false;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential NetworkCred = new NetworkCredential(from1, password1);
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = 587;
            //    smtp.Send(mm);
            //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);

            //}



            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            //try
            // {
            MailAddress fromAddress = new MailAddress("info@fantasysolution.in");
            message.From = fromAddress;
            message.To.Add(DropDownList1.Items[ii].Text);
            message.Subject = "Change Public Key";
            message.IsBodyHtml = true;
            message.Body = "Public Key :" + publickey.ToString();
            // string FileName = Server.MapPath(ff);
            //message.Attachments.Add(new Attachment(FileName));
            smtpClient.Host = "relay-hosting.secureserver.net";   //-- Donot change.
            smtpClient.Port = 25; //--- Donot change
            smtpClient.EnableSsl = false;//--- Donot change
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("info@fantasysolution.in", "Fantasy5535");

            smtpClient.Send(message);

            //lblConfirmationMessage.Text = "Your email successfully sent.";
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Mail Send.');", true);










        }





        bind();
    }

    private void bind()
    {
        cmd = new SqlCommand("select * from uregtb ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

       


    }
}