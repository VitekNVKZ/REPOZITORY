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
using System.Diagnostics;

namespace WindowsFormsApp9АРКАНОИД_ФИНАЛ
{
    public partial class AUTHORISATION : Form
    {
        public AUTHORISATION()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            REGISTRSTION f = new REGISTRSTION();
            f.Show();
            textBox1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //получаем логин и пароль в переменные
            //сразу чистим краевые пробелы (трим)
            string login_user = textBox1.Text.Trim();
            string password_user = textBox2.Text.Trim();
            if (login_user == "" || password_user == "")
            {
                MessageBox.Show("Вы не ввели данные");
            }
            else
            {
                //создаем подключение к БД
                SqlConnection connect = new SqlConnection(Program.st_connect);
                //открываем подключение
                connect.Open();
                //строка н поиск юзера
                string s = "select * from users where login_user = '" + login_user + "' and password_user = '" + password_user + "'";
                //делаем запрос к БД
                SqlCommand command = new SqlCommand(s, connect);
                //получаем данные которые вернул запрос
                SqlDataReader reader = command.ExecuteReader();
                //читаем одну строку из набора данных
                if (reader.HasRows)
                {
                    reader.Read();
                    //получаем данные. В скобках это номера столбцов как в запросе(0-8)
                    Program.id_user = reader.GetInt32(0);
                    Program.type_user = reader.GetBoolean(3);

                    if (Program.type_user == false)
                    {
                        USERS_FORM f = new USERS_FORM();
                        f.Show();
                        //this.Close();
                    }
                    else
                    {
                        Form3 f = new Form3();
                        f.Show();
                    }


                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
                connect.Close();
            }
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            REGISTRSTION f = new REGISTRSTION();
            f.Show();
            textBox1.Enabled = true;
            this.Hide();
        }

        private void AUTHORISATION_Load(object sender, EventArgs e)
        {
            //LOADING frm4 = new LOADING();
            //frm4.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void AUTHORISATION_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            //this.Close();
            //this.Hide();
            Process[] List;
            List = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in List)
            {
                proc.Kill();
            }
        }

        private void AUTHORISATION_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            //this.Close();
            //this.Hide();
            string name = "Арканоид";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
                               //ToLower() - метод для переведения всех букв в нижний регистр, или как то так
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }


        }

        //public void CloseProcess()
        //{
        //    Process[] List;
        //    List = Process.GetProcessesByName("EXCEL");
        //    foreach (Process proc in List)
        //    {
        //        proc.Kill();
        //    }
        //}
    }
}


