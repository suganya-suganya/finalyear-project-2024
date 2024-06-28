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


public partial class CAHome : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Rolldb.mdf;Integrated Security=True;User Instance=True");
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



        string loginkey = pass(6).ToString();
     

        if (RadioButtonList1.Text == "Reject")
        {
            con.Open();
            cmd = new SqlCommand("update uregtb  set Status='" + RadioButtonList1.Text + "',PublicKey='" + loginkey + "' where id='" + id + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {

            con.Open();
            cmd = new SqlCommand("update uregtb  set Status='" + RadioButtonList1.Text + "',PublicKey='" + loginkey + "' where id='" + id + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();


            string to = grdrow.Cells[5].Text;
            string from = "projectmailm@gmail.com";
            // string subject = "Key";
            // string body = TextBox1.Text;
            string password = "qmgn xecl bkqv musr";
            using (MailMessage mm = new MailMessage(from, to))
            {
                mm.Subject = "Login Key";
                mm.Body = "Login Key:" + loginkey.ToString();
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


        bind();
    }

    private void bind()
    {
        cmd = new SqlCommand("select * from uregtb where Status='waiting' ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        cmd = new SqlCommand("select * from uregtb where Status='Approved' ", con);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();



        cmd = new SqlCommand("select * from uregtb where Status='Reject' ", con);
        SqlDataAdapter da11 = new SqlDataAdapter(cmd);
        DataTable dt11 = new DataTable();
        da11.Fill(dt11);
        GridView3.DataSource = dt11;
        GridView3.DataBind();

    }
}
