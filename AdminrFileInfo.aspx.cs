using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;


public partial class AdminFileInfo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|datadirectory|\Rolldb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;
    string filename;

    public Stopwatch stopWatch;

    protected void Page_Load(object sender, EventArgs e)
    {
        stopWatch = new Stopwatch();
        bind();
    }
    private void bind()
    {
        cmd = new SqlCommand("select * from filetb where AdminName='" + Session["dname"].ToString() + "' ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();



    }
 //   string filename;
    string keyss;

    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string id = grdrow.Cells[0].Text;

      

        con.Open();
        cmd = new SqlCommand("select * from filetb where id='" + id + "'  ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            keyss = dr["Keys"].ToString();
            filename = dr["FileName"].ToString();
            dr.Close();


            string filePath1 = Server.MapPath("~/Encrypt/" + filename);
            string filePath2 = Server.MapPath("~/Decrypt/" + filename);
            DecryptFile(filePath1, filePath2, keyss);

            string aaa = "~/Decrypt/" + filename;

            if (aaa != string.Empty)
            {
                string filePath = aaa;
                Response.ContentType = "doc/docx";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + aaa + "\"");
                Response.TransmitFile(Server.MapPath(filePath));
                Response.End();
            }

        }

        con.Close();






    }
    decimal a;
    protected void lnkView_Click1(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string id = grdrow.Cells[0].Text;



        con.Open();
        cmd = new SqlCommand("select * from filetb where id='" + id + "'", con);
        SqlDataReader drr = cmd.ExecuteReader();
        if (drr.Read())
        {
            keyss = drr["keys"].ToString();

        }
        con.Close();





        con.Open();
        cmd = new SqlCommand("select * from filetb where id='" + id + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            filename = dr["FileName"].ToString();
            string filePath1 = Server.MapPath("~/Encrypt/" + filename);
            string filePath2 = Server.MapPath("~/Decrypt/" + filename);



            stopWatch.Start();

            DecryptFile(filePath1, filePath2, keyss);


            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            a = Convert.ToDecimal(ts.TotalSeconds.ToString());



            fillChart();


            //  Response.Write("<Script> alert('File Download') </Script>");

        }

    }

    private void fillChart()
    {


        Chart1.Series["Time"].Points.AddXY("Decryption Time ", a);




        Chart1.Titles.Add("Decryption Time");
        Chart1.Series["Time"].IsValueShownAsLabel = true;


    }


    private void DecryptFile(string inputFile, string outputFile, string keys)
    {

        {
            string password = @"myKey123";

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();

        }
    }
}