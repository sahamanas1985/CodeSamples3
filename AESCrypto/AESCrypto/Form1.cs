using System.Configuration;

namespace AESCrypto
{
    public partial class Form1 : Form
    {
        private readonly string AESKey;

        public Form1()
        {
            InitializeComponent();
            AESKey = ConfigurationManager.AppSettings["AESKey"];
        }
               

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string plaintext = txtInputText.Text;
            try
            {
                string encryptedText = IDMAES.EncryptString_Aes(AESKey, plaintext);
                txtOutputText.Text = encryptedText;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                       
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string encryptedtext = txtInputText.Text;
                string decryptedText = IDMAES.DecryptString_Aes(AESKey, encryptedtext);
                txtOutputText.Text = decryptedText;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}