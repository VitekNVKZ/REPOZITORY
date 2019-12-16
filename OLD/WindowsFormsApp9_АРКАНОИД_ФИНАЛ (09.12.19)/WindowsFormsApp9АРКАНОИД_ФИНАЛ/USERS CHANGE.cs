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
    public partial class Form6 : Form
    {

        public string pathImage { get; set; }
        public Form6()
        {
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.RoyalBlue;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Plum;
        }


        

        private void button1_Click(object sender, EventArgs e)
        {

            int k = dataGridView1.CurrentRow.Index;
            Program.id_user = Convert.ToInt32(dataGridView1[0, k].Value);//запоминаем id выбранного юзера
            SqlConnection connect = new SqlConnection(Program.st_connect);
            connect.Open();
            string s = "UPDATE USERS set " +
                "login_user='" + LoginBox.Text.Trim() + "', " +
                "password_user='" + PasswordBox.Text.Trim() + "'," +
                "type_user='" + comboBox1.SelectedIndex + "'," +
                "photo_user='" + label3.Text + "' " +
                "WHERE id_user = " + Program.id_user.ToString();
            SqlCommand comm = new SqlCommand(s, connect);
            comm.ExecuteScalar();
            connect.Close();


            SqlConnection conn1 = new SqlConnection(Program.st_connect);
            conn1.Open();
            string s1 = "SELECT * FROM USERS";
            //Делаем запрос к БД через адаптер, что бы потом поместить даные в DATASET
            SqlDataAdapter adap = new SqlDataAdapter(s1, conn1);
            //создаем пустой датасет
            DataSet ds1 = new DataSet();
            //соединяем датасет с нашим набором данных
            adap.Fill(ds1);
            //соединяем датасет с визуальным компонентом
            dataGridView1.DataSource = ds1.Tables[0];
            if (ds1.Tables[0].Rows.Count >= 10)
            {
                button2.Enabled = true;
            }
            conn1.Close();
            dataGridView1.Columns[0].Visible = false;

            LoginBox.Text = "";
            PasswordBox.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Изменено");
    }

        private void Form6_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRCANOIDDataSet.USERS". При необходимости она может быть перемещена или удалена.
            this.uSERSTableAdapter.Fill(this.aRCANOIDDataSet.USERS);
            dataGridView1.CurrentCell = dataGridView1[1, 0];

            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            int k = dataGridView1.CurrentRow.Index;
            Program.id_user = Convert.ToInt32(dataGridView1[0, k].Value);

            string s = "SELECT photo_user FROM USERS WHERE Id_user = " + Program.id_user;
            SqlCommand comm = new SqlCommand(s, conn);
            SqlDataReader read = comm.ExecuteReader();
            read.Read();
            string s1 = read.GetString(0);
            pictureBox1.Image = Image.FromFile(s1);
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3 ff = new Form3();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoginBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            PasswordBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //pictureBox1.Image = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //pictureBox1.Image.GetFileName(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);


            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value) ==true)
                {
                comboBox1.SelectedIndex = 1;

                }
           else
            {
                comboBox1.SelectedIndex = 0;
            }
            label3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            PasswordBox.SelectionStart = 0;
            PasswordBox.SelectionLength = LoginBox.Text.Length;
            PasswordBox.Focus();

            //SqlCommand command = new SqlCommand();
            //SqlDataReader read = command.ExecuteReader();
            //read.Read();
            //string q = read.GetString(9);
            //q.pictureBox1.Image = Image.FromFile(q);

            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            int k = dataGridView1.CurrentRow.Index;
            Program.id_user = Convert.ToInt32(dataGridView1[0, k].Value);

            string s = "SELECT photo_user FROM USERS WHERE Id_user = " + Program.id_user;
            SqlCommand comm = new SqlCommand(s, conn);
            SqlDataReader read = comm.ExecuteReader();
            read.Read();
            string s1 = read.GetString(0);
            pictureBox1.Image = Image.FromFile(s1);





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoginBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            PasswordBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value) == true)
            {
                comboBox1.SelectedIndex = 1;

            }
            else
            {
                comboBox1.SelectedIndex = 0;
            }
            label3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            PasswordBox.SelectionStart = 0;
            PasswordBox.SelectionLength = LoginBox.Text.Length;
            PasswordBox.Focus();

        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.Text = Path.GetFileName(openFileDialog1.FileName);
                File.Copy(openFileDialog1.FileName, AppDomain.CurrentDomain.BaseDirectory + label3.Text, true);//true = перезапись имени файла без ошибок

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}

