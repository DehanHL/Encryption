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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //AES Global Variables
        CspParameters cssp = new CspParameters();
        RSACryptoServiceProvider rsa;

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
                int shift = (int)abc[index] - 65;
                result[i] = (byte)(((int)inByte[i] + shift) % 256);
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
                int shift = (int)abc[index] - 65;
                result[i] = (byte)(((int)inByte[i] + 256 - shift) % 256);
                index++;

                if (i == 256)
                {
                    index = 0;
                }
            }
            return result;
        }

       /* public byte[] AesEnc(byte[] inByte)
        {
            byte[] result = new byte[inByte.Length];

            Aes aes = Aes.Create();
            ICryptoTransform cTrans = aes.CreateEncryptor();

            byte[] eKey = RSA.Encrypt(aes.Key, false);

            return result;
        }*/

        //Save Method
        private void SaveFile(byte[] inByte)
        {
            string ext = Path.GetExtension(tbxPath.Text);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Files (*" + ext + ") | *" + ext;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, inByte);                
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
                    SaveFile(chipherByte);
                    MessageBox.Show("File has been succesfully encrypted");
                }
                //Decrypt
                else
                {
                    byte[] chipherByte = CipherDec(FileByte);
                    SaveFile(chipherByte);
                    MessageBox.Show("File has been succesfully decrypted");
                }
            }
            catch
            {
                MessageBox.Show("File is in use");
                return;
            }
            
        }
    }
}
