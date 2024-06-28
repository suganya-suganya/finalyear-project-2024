using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

using System.IO;
using System.Text;
using DiffieHellmanMerkle;

public partial class AdminFileUpload : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Rolldb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Label5.Text = Session["dname"].ToString();
        stopWatch = new Stopwatch();
    }
    public Stopwatch stopWatch;
    public static byte[] alicePublicKey;
    byte[] SecretA = null;
    string pubkey;
    decimal dd, ee, a;
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {



            ECDiffieHellmanMerkle A = new ECDiffieHellmanMerkle(ECDHAlgorithm.ECDH_384);
            ECDiffieHellmanMerkle B = new ECDiffieHellmanMerkle(ECDHAlgorithm.ECDH_384);
            A.KeyDerivationFunction = ECDHKeyDerivationFunction.HASH;

            A.HashAlgorithm = DerivedKeyHashAlgorithm.SHA256_ALGORITHM;

            SecretA = A.RetrieveSecretKey(B.PublicKey);

            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
          
            pubkey = Convert.ToBase64String(SecretA);

            if (pubkey != "")
            {

                Label6.Text = " key:" + pubkey.ToString();

                stopWatch.Start();

                string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + filename));
                string filePath = Server.MapPath("~/Upload/" + filename);

                decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);

                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                br.Close();
                fs.Close();

                // decimal siz = Math.Round(((decimal)System.IO.FileInfo(filePath).Length / (decimal)1024), 2);

                // decimal siz = System.IO.FileInfo(filePath).

                FileInfo fInfo = new FileInfo(filePath);
                long Result = fInfo.Length;
                decimal siz = Math.Round(((decimal)fInfo.Length / (decimal)1024), 2);

                cmd = new SqlCommand("insert into filetb values(@AdminName,@FileInfo,@FileName,@size,@keys,@Bpvalue,@Sugarvalue)", con);
                cmd.Parameters.AddWithValue("@AdminName", Label5.Text);
                cmd.Parameters.AddWithValue("@FileInfo", TextBox1.Text);
                cmd.Parameters.AddWithValue("@FileName", filename);
                cmd.Parameters.AddWithValue("@size", size.ToString() + "KB");
                cmd.Parameters.AddWithValue("@keys", pubkey.ToString());

                cmd.Parameters.AddWithValue("@Bpvalue", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Sugarvalue", TextBox3.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                string filePath1 = Server.MapPath("~/Encrypt/" + filename);
                EncryptFile(filePath, filePath1, pubkey.ToString());

                stopWatch.Stop();

                TimeSpan ts = stopWatch.Elapsed;
                a = Convert.ToDecimal(ts.TotalSeconds.ToString());
                stopWatch.Reset();

                Response.Write("<Script> alert('File Encrypt and Saved') </Script>");
                fillChart();
            }
            else
            {
                Response.Write("<Script> alert('File Maybe corrupt  Please Change File..!') </Script>");
            }
           
        }
        catch
        {
           
        }

        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";


    }
    private void fillChart()
    {


        Chart1.Series["Time"].Points.AddXY("Encryption Time ", a);




        Chart1.Titles.Add("Encryption Time");
        Chart1.Series["Time"].IsValueShownAsLabel = true;


    }
    private void EncryptFile(string inputFile, string outputFile,string keys)
    {


        string password = @"myKey123";
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] key = UE.GetBytes(password);

        string cryptFile = outputFile;
        FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

        RijndaelManaged RMCrypto = new RijndaelManaged();

        CryptoStream cs = new CryptoStream(fsCrypt,
            RMCrypto.CreateEncryptor(key, key),
            CryptoStreamMode.Write);

        FileStream fsIn = new FileStream(inputFile, FileMode.Open);

        int data;
        while ((data = fsIn.ReadByte()) != -1)
            cs.WriteByte((byte)data);

        fsIn.Close();
        cs.Close();
        fsCrypt.Close();
        Response.Write("Encryption Sucessfully Completed");

    }
}