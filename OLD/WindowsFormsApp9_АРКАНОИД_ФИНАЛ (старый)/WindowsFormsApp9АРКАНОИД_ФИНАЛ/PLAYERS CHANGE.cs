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
using Microsoft.Office.Interop.Excel;



namespace WindowsFormsApp9АРКАНОИД_ФИНАЛ
{
    public partial class Form1 : Form
    {
        private object ARCANOIDDataSet;

        int n = 0;
        public Form1()
        {
            InitializeComponent();
            this.Width = 628;
            this.Height = 465;

            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 12);
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Wheat;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button2.Enabled = false;
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            string s = "SELECT Id , Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY id OFFSET " + n.ToString() + " ROWS FETCH NEXT 10 ROWS ONLY";
            //Делаем запрос к БД через адаптер, что бы потом поместить даные в DATASET
            SqlDataAdapter adap = new SqlDataAdapter(s, conn);
            //создаем пустой датасет
            DataSet ds = new DataSet();
            //соединяем датасет с нашим набором данных
            adap.Fill(ds);
            //соединяем датасет с визуальным компонентом
            dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count >= 10)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            conn.Close();
            dataGridView1.Columns[0].Visible = false;
            if (Program.type_user == false)
            {
                button4.Visible = false;
                button5.Visible = false;
            }
            else
            {
                button4.Visible = true;
                button5.Visible = true;
            }
            dataGridView1.CurrentCell = dataGridView1[1, 0];

        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.SelectionStart = 0;
            textBox2.SelectionLength = textBox2.Text.Length;
            textBox2.Focus();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            this.Width = 900;
            this.Height = 465;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form3 ff = new Form3();
            //ff.Show();
            Microsoft.Office.Interop.Excel.Application myExcel = new Microsoft.Office.Interop.Excel.Application();
            //создаем виртуальный объект Excel

            //создать книгу в объекте Excel
            myExcel.Application.Workbooks.Add(Type.Missing);
            //Настраиваем ячейки
            myExcel.Quit();

            //this.Close();
            if (Program.type_user == false)
            {

                USERS_FORM f = new USERS_FORM();
                if (!f.Visible)
                    f.Show();
                //this.Close();
            }
            else
            {
                Form3 f = new Form3();
                if (!f.Visible)
                    f.Show();
                //this.Close();
            }
            // this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            n = n - 10;
            if (n <= 0)
            {
                button2.Enabled = false;
            }
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            string s = "SELECT Id ,Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY id OFFSET " + n.ToString() + " ROWS FETCH NEXT 10 ROWS ONLY";
            //Делаем запрос к БД через адаптер, что бы потом поместить даные в DATASET
            SqlDataAdapter adap = new SqlDataAdapter(s, conn);
            //создаем пустой датасет
            DataSet ds = new DataSet();
            //соединяем датасет с нашим набором данных
            adap.Fill(ds);
            //соединяем датасет с визуальным компонентом
            dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count >= 10)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            conn.Close();
            dataGridView1.Columns[0].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = n + 10;
            button2.Enabled = true;
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            string s = "SELECT Id ,Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY id OFFSET " + n.ToString() + " ROWS FETCH NEXT 10 ROWS ONLY";
            //Делаем запрос к БД через адаптер, что бы потом поместить даные в DATASET
            SqlDataAdapter adap = new SqlDataAdapter(s, conn);
            //создаем пустой датасет
            DataSet ds = new DataSet();
            //соединяем датасет с нашим набором данных
            adap.Fill(ds);
            //соединяем датасет с визуальным компонентом
            dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count >= 10)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            conn.Close();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int k = dataGridView1.CurrentRow.Index;
            Program.id_user = Convert.ToInt32(dataGridView1[0, k].Value);
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            string s = "DELETE FROM PLAYERS WHERE id=" + Program.id_user.ToString();
            SqlCommand comm = new SqlCommand(s, conn);
            comm.ExecuteScalar();
            conn.Close();
            MessageBox.Show("Чел удален");



            n = n + 10;
            button2.Enabled = true;
            SqlConnection conn1 = new SqlConnection(Program.st_connect);
            conn1.Open();
            string s1 = "SELECT Id ,Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY id OFFSET " + n.ToString() + " ROWS FETCH NEXT 10 ROWS ONLY";
            //Делаем запрос к БД через адаптер, что бы потом поместить даные в DATASET
            SqlDataAdapter adap = new SqlDataAdapter(s1, conn);
            //создаем пустой датасет
            DataSet ds = new DataSet();
            //соединяем датасет с нашим набором данных
            adap.Fill(ds);
            //соединяем датасет с визуальным компонентом
            dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count >= 10)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            conn1.Close();
            dataGridView1.Columns[0].Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text.Trim() == "" ||//проверка на пустоту
                    textBox2.Text.Trim() == "" )
                    
                {
                    MessageBox.Show("Не все поля заполнены");
                }
                else
                {

                    int k = dataGridView1.CurrentRow.Index;
                    Program.Id = Convert.ToInt32(dataGridView1[0, k].Value);//запоминаем id выбранного юзера
                    SqlConnection conn = new SqlConnection(Program.st_connect);
                    conn.Open();

                    string s = "UPDATE PLAYERS " +
                    " SET " + "Name_players= " +"'" + textBox1.Text.Trim() + "'," +
                    "score = " + "'" + textBox2.Text.Trim() + "'," +
                    "data_igra = " + "'" + dateTimePicker1.Value.ToShortDateString() + "'," +
                    "vremya_igra = " + "'" + dateTimePicker2.Value.ToShortTimeString() + "' WHERE Id=" + Program.Id.ToString();
                    SqlCommand comm = new SqlCommand(s, conn);
                    comm.ExecuteScalar();

                    conn.Close();

                    SqlConnection conn1 = new SqlConnection(Program.st_connect);
                    conn1.Open();
                    string s1 = "SELECT Id , Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY id OFFSET " + n.ToString() + " ROWS FETCH NEXT 10 ROWS ONLY";
                    //Делаем запрос к БД через адаптер, что бы потом поместить даные в DATASET
                    SqlDataAdapter adap = new SqlDataAdapter(s1, conn);
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

                }
            }
          catch
            {
                MessageBox.Show("Что то пошло не так");
            }
            

            this.Width = 628;
            this.Height = 465;



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.SelectionStart = 0;
            textBox2.SelectionLength = textBox2.Text.Length;
            textBox2.Focus();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            {

                Microsoft.Office.Interop.Excel.Application myExcel = new Microsoft.Office.Interop.Excel.Application();
                //создаем виртуальный объект Excel
                                                                                                                     
                //создать книгу в объекте Excel
                myExcel.Application.Workbooks.Add(Type.Missing);
                //Настраиваем ячейки

                myExcel.Columns.ColumnWidth = 20;
                //Пишем заголовки ячеек
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    myExcel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;// заголовки программно
                }

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                    {
                        myExcel.Cells[j + 2, i + 1] = dataGridView1[i, j].Value.ToString();
                    }
                }
                //скрываем столбец А
                Range range = (Range)myExcel.Columns[1, Type.Missing];
                range.EntireColumn.Hidden = true;
                myExcel.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            if (radioButton1.Checked)
            {
                string s = "SELECT Id ,Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY score DESC OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY ";
                SqlDataAdapter adap = new SqlDataAdapter(s, conn);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else if (radioButton2.Checked)
            {
                string s = "SELECT Id, Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY data_igra DESC OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY ";
                
                SqlDataAdapter adap = new SqlDataAdapter(s, conn);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

            else if (radioButton3.Checked)
            {
                n = n + 10;
                button2.Enabled = true;
                SqlConnection conn1 = new SqlConnection(Program.st_connect);
                conn1.Open();
                string s = "SELECT Id ,Name_players as 'Имя игрока', score as 'Счёт', data_igra as 'Дата', vremya_igra as 'Время' FROM PLAYERS ORDER BY id OFFSET " + n.ToString() + " ROWS FETCH NEXT 10 ROWS ONLY";
                //Делаем запрос к БД через адаптер, что бы потом поместить даные в DATASET
                SqlDataAdapter adap = new SqlDataAdapter(s, conn);
                //создаем пустой датасет
                DataSet ds = new DataSet();
                //соединяем датасет с нашим набором данных
                adap.Fill(ds);
                //соединяем датасет с визуальным компонентом
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count >= 10)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
                conn1.Close();
                dataGridView1.Columns[0].Visible = false;

                conn.Close();
            }
        }
    }
}
