using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Encryption
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //AES
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        const string aesKey = "AXe8YwuIn1zxt3FPWTZFlAa14EHdPAdN9FaZ9RQWihc=";
        const string aesVector = "bsxnWolsAyO7kCfWuyrnqg==";

        //Method to generate SHA256 hash from string
        private byte[] getHash(string pass)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            return hash;
        }

        //Encrypt with cipher
        private byte[] CipherEnc(byte[] inByte)
        {
            byte[] abc = getHash(tbxPassword.Text);
            byte[] result = new byte[inByte.Length];
            int index = 0;


            for (int i = 0; i < inByte.Length; i++)
            {
                index = index % abc.Length;
                int shift = abc[index] - 65;
                result[i] = (byte)((inByte[i] + shift) % 256);
                index++;

                if (i == 256)
                {
                    index = 0;                    
                }
            }
            return result;
        }

        //Decrypt with cipher
        private byte[] CipherDec(byte[] inByte)
        {
            byte[] abc = getHash(tbxPassword.Text);
            byte[] result = new byte[inByte.Length];
            int index = 0;

            for (int i = 0; i < inByte.Length; i++)
            {
                index = index % abc.Length;
                int shift = abc[index] - 65;
                result[i] = (byte)((inByte[i] + 256 - shift) % 256);
                index++;

                if (i == 256)
                {
                    index = 0;
                }
            }
            return result;
        }

        //Encrypting AES
        public byte[] AesEnc(byte[] inByte)
        {
            byte[] result = new byte[inByte.Length];

            aes.Key = Convert.FromBase64String(aesKey);
            aes.IV = Convert.FromBase64String(aesVector);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform trans = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream mstream = new MemoryStream())
            {
                using (CryptoStream cstream = new CryptoStream(mstream, trans, CryptoStreamMode.Write))
                {
                    cstream.Write(inByte, 0, inByte.Length);
                    cstream.Close();
                }
                result = mstream.ToArray();
            }
                return result;
        }

        //Decrypting AES
        public byte[] AesDec(byte[] inByte)
        {
            byte[] result = new byte[inByte.Length];

            aes.Key = Convert.FromBase64String(aesKey);
            aes.IV = Convert.FromBase64String(aesVector);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform trans = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream mstream = new MemoryStream())
            {
                using (CryptoStream cstream = new CryptoStream(mstream, trans, CryptoStreamMode.Write))
                {
                    cstream.Write(inByte, 0, inByte.Length);
                    cstream.Close();
                }
                result = mstream.ToArray();
            }            
            return result;
        }

        //Save Method
        private void SaveFile(byte[] inByte)
        {
            //Remove original file
            File.Delete(tbxPath.Text);

            //Save File
            if (rbEncrypt.Checked)
            {
                File.WriteAllBytes(tbxPath.Text + ".enc", inByte);
            }
            else
            {
                File.WriteAllBytes(tbxPath.Text.Replace(".enc",""), inByte);
            }
        }
        

        //Select file
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                tbxPath.Text = ofd.FileName;
            }
        }

        private void rbEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEncrypt.Checked)
            {
                rbDecrypt.Checked = false;
            }
        }

        private void rbDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDecrypt.Checked)
            {
                rbEncrypt.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbEncrypt.Checked = true;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            //Check rb
            if (!File.Exists(tbxPath.Text))
            {
                MessageBox.Show("File does not exist.");
            }
            if(String.IsNullOrEmpty(tbxPassword.Text))
            {
                MessageBox.Show("Password empty. Please enter your password");
                return;
            }

            try
            {
                byte[] FileByte = File.ReadAllBytes(tbxPath.Text);
                //Encrypt
                if (rbEncrypt.Checked)
                {                    
                    byte[] chipherByte = CipherEnc(FileByte);
                    byte[] aesByte = AesEnc(chipherByte);
                    SaveFile(aesByte);
                    MessageBox.Show("File has been succesfully encrypted");
                }
                //Decrypt
                else
                {
                    byte[] aesByte = AesDec(FileByte);
                    byte[] chipherByte = CipherDec(aesByte);                    
                    SaveFile(chipherByte);
                    MessageBox.Show("File has been succesfully decrypted");
                }
                tbxPath.Text = "";
            }
            catch
            {
                MessageBox.Show("File is in use");
                return;
            }            
        }
    }
}
