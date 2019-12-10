using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp9АРКАНОИД_ФИНАЛ
{
    public partial class REGISTRSTION : Form
    {

        public string pathImage { get; set; }
        public REGISTRSTION()
        {
            InitializeComponent();
        }

        void Registerr()
        {
            if(LoginBox.Text != string.Empty)
            {
                if(PasswordBox.Text != string.Empty)
                {
                    SqlConnection connection = new SqlConnection(Program.st_connect);
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"INSERT INTO[dbo].[USERS]" +
                            $"([login_user],[password_user],[type_user],[photo_user])" +
                            $"VALUES" +
                            $"('{LoginBox.Text}','{PasswordBox.Text}',0,'{pathImage}')");
                        command.Connection = connection;
                        int rows = command.ExecuteNonQuery();
                        if(rows > 0)
                        {
                            MessageBox.Show($"Добавлено {rows} пользователей");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registerr();
            this.Close();
            AUTHORISATION f = new AUTHORISATION();
            f.Show();
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Multiselect = false;
            if(filedialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(
                    filedialog.FileName,
                    AppDomain.CurrentDomain.BaseDirectory + "/" + Path.GetFileName(filedialog.FileName)
                    );
                pathImage = Path.GetFileName(filedialog.FileName);
                pictureBox1.Image = Image.FromFile(filedialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void REGISTRSTION_Load(object sender, EventArgs e)
        {

        }
    }
}
