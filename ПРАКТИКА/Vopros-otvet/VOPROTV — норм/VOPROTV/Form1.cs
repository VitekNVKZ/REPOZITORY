using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Media;

namespace VOPROTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;

            label3.Width = this.Width;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.AutoSize = false;


            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;


            string q = "Select  Count([Vopros-otvet].Kod) AS [Count-Kod] FROM[Vopros-otvet]; ";
            var R = GetTble(q);
            dataGridView1.DataSource = R;

            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            label1.Text = Convert.ToString(dataGridView1[0, 0].Value);

            string qw = "Select  * FROM[Vopros-otvet]; ";
            var Z = GetTable(qw);

            dataGridView2.DataSource = Z;

        }
        public DataTable GetTble(string q)
        {
            OleDbConnection Этап1sqlConnection1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;   
                                                                        Data Source=C:\Vopros-otvet\Vopros-otvet.accdb; 
                                                                            Persist Security Info=False;");
            OleDbDataAdapter queryAdapter = new OleDbDataAdapter(q, Этап1sqlConnection1);
            DataTable R = new DataTable();
            queryAdapter.Fill(R);
            Этап1sqlConnection1.Close();
            return R;

        }
        public DataTable GetTable(string qw)
        {
            OleDbConnection Этап1sqlConnection1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;   
                                                                        Data Source=C:\Vopros-otvet\Vopros-otvet.accdb; 
                                                                            Persist Security Info=False;");
            OleDbDataAdapter queryAdapter = new OleDbDataAdapter(qw, Этап1sqlConnection1);
            DataTable R = new DataTable();
            queryAdapter.Fill(R);
            Этап1sqlConnection1.Close();
            return R;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            pictureBox6.Visible = true;
            int st = Convert.ToInt32(label1.Text);
            Random ran = new Random();
            int[] mas = new int[st];
            int a, n, b, m;
            n = 0;
            m = 0;
            for (int i = 0; i <= st - 1; i++)
            {
                mas[i] = 0;
            }
            do
            {
                a = ran.Next(st);
                if (mas[a] == 0)
                {
                    n++;
                    mas[a] = n;

                    textBox1.AppendText(Convert.ToString(a + "\r\n"));
                }

            } while (n != st);

            // рандомим ответы в 3й текстбокс

            for (int i = 0; i < 4; i++)
            {
                mas[i] = 0;
            }
            do
            {
                b = ran.Next(st);

                if (mas[b] == 0)
                {
                    m++;
                    mas[b] = m;

                    textBox3.AppendText(Convert.ToString(b + "\r\n"));
                }

            } while (m != 4);

            int eq = Convert.ToInt32(label2.Text);
            int er = Convert.ToInt32(textBox1.Lines[eq]);
            label3.Text = Convert.ToString(dataGridView2[1, er].Value);
            eq = eq + 1;
            label2.Text = Convert.ToString(eq);
            button2.Visible = true;
            button1.Visible = false;
            textBox2.AppendText(Convert.ToString(dataGridView2[2, er].Value + "\r\n"));//берем верный ответ


            if (er > 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    er = er - 1;
                    textBox2.AppendText(Convert.ToString(dataGridView2[2, er].Value + "\r\n"));
                }
            }

            else
            {
                for (int i = 0; i < 3; i++)
                {
                    er = er + 1;
                    textBox2.AppendText(Convert.ToString(dataGridView2[2, er].Value + "\r\n"));
                }
            }

            int ot1, ot2, ot3, ot4;
            ot1 = Convert.ToInt32(textBox3.Lines[0]);
            label4.Text = textBox2.Lines[ot1];

            ot2 = Convert.ToInt32(textBox3.Lines[1]);
            label5.Text = textBox2.Lines[ot2];

            ot3 = Convert.ToInt32(textBox3.Lines[2]);
            label6.Text = textBox2.Lines[ot3];

            ot4 = Convert.ToInt32(textBox3.Lines[3]);
            label7.Text = textBox2.Lines[ot4];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;

            if (Convert.ToInt32(label8.Text) < 0)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
            }
            if (Convert.ToInt32(label8.Text) < (-5))
            {
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
            }

            if (Convert.ToInt32(label8.Text) == 0)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
            }
            if (Convert.ToInt32(label8.Text) > 0)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
                pictureBox8.Visible = false;
            }
            if (Convert.ToInt32(label8.Text) > 6)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
            }




            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            int st = Convert.ToInt32(label1.Text);
            Random ran = new Random();
            int[] mas = new int[st];
            int a, n, b, m;
            n = 0;
            m = 0;
            for (int i = 0; i <= st - 1; i++)
            {
                mas[i] = 0;
            }
            do
            {
                a = ran.Next(st);
                if (mas[a] == 0)
                {
                    n++;
                    mas[a] = n;

                    textBox1.AppendText(Convert.ToString(a + "\r\n"));
                }

            } while (n != st);

            // рандомим ответы в 3й текстбокс

            textBox3.Clear();

            for (int i = 0; i < 4; i++)
            {
                mas[i] = 0;
            }
            do
            {
                b = ran.Next(st);

                if (mas[b] == 0)
                {
                    m++;
                    mas[b] = m;

                    textBox3.AppendText(Convert.ToString(b + "\r\n"));
                }

            } while (m != 4);
            //
            int eq = Convert.ToInt32(label2.Text);
            int er = Convert.ToInt32(textBox1.Lines[eq]);
            label3.Text = Convert.ToString(dataGridView2[1, er].Value);
            eq = eq + 1;
            label2.Text = Convert.ToString(eq);
            textBox2.Clear();
            textBox2.AppendText(Convert.ToString(dataGridView2[2, er].Value + "\r\n"));//берем верный ответ


            if (er > 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    er = er - 1;
                    textBox2.AppendText(Convert.ToString(dataGridView2[2, er].Value + "\r\n"));
                }
            }

            else
            {
                for (int i = 0; i < 3; i++)
                {
                    er = er + 1;
                    textBox2.AppendText(Convert.ToString(dataGridView2[2, er].Value + "\r\n"));
                }
            }

            int ot1, ot2, ot3, ot4;
            ot1 = Convert.ToInt32(textBox3.Lines[0]);
            label4.Text = textBox2.Lines[ot1];

            ot2 = Convert.ToInt32(textBox3.Lines[1]);
            label5.Text = textBox2.Lines[ot2];

            ot3 = Convert.ToInt32(textBox3.Lines[2]);
            label6.Text = textBox2.Lines[ot3];

            ot4 = Convert.ToInt32(textBox3.Lines[3]);
            label7.Text = textBox2.Lines[ot4];

            button2.Enabled = false;
            if (Convert.ToInt32(label1.Text) == Convert.ToInt32(label2.Text) + 1)
            {
                button3.Visible = true;
                MessageBox.Show("Вопросы кончились, красавчик. Жми 'Выход'");

                button2.Visible = false;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {


            SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.close);
            audio.Play();

            System.Threading.Thread.Sleep(2000);

            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            int ot5;
            ot5 = Convert.ToInt32(label8.Text);
            if (label4.Text == textBox2.Lines[0])
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.verno);
                audio.Play();
                label8.Text = Convert.ToString(ot5 + 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox2.Visible = true;

            }
            else
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.ne_verno);
                audio.Play();
                label8.Text = Convert.ToString(ot5 - 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox3.Visible = true;

            }

            if (Convert.ToInt32(label1.Text) == Convert.ToInt32(label2.Text) + 1)
            {
                button3.Visible = true;
                button2.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            int ot5;
            ot5 = Convert.ToInt32(label8.Text);
            if (label5.Text == textBox2.Lines[0])
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.verno);
                audio.Play();
                label8.Text = Convert.ToString(ot5 + 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox2.Visible = true;

            }
            else
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.ne_verno);
                audio.Play();
                label8.Text = Convert.ToString(ot5 - 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox3.Visible = true;

            }

            if (Convert.ToInt32(label1.Text) == Convert.ToInt32(label2.Text) + 1)
            {
                button3.Visible = true;
                MessageBox.Show("Вопросы кончились, красавчик. Жми 'Выход'");
                button2.Visible = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            int ot5;
            ot5 = Convert.ToInt32(label8.Text);
            if (label6.Text == textBox2.Lines[0])
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.verno);
                audio.Play();
                label8.Text = Convert.ToString(ot5 + 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox2.Visible = true;

            }
            else
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.ne_verno);
                audio.Play();
                label8.Text = Convert.ToString(ot5 - 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox3.Visible = true;

            }

            if (Convert.ToInt32(label1.Text) == Convert.ToInt32(label2.Text) + 1)
            {
                button3.Visible = true;
                MessageBox.Show("Вопросы кончились, красавчик. Жми 'Выход'");
                button2.Visible = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            int ot5;
            ot5 = Convert.ToInt32(label8.Text);
            if (label7.Text == textBox2.Lines[0])
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.verno); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
                audio.Play();
                label8.Text = Convert.ToString(ot5 + 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox2.Visible = true;


            }
            else
            {
                SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.ne_verno);
                audio.Play();
                label8.Text = Convert.ToString(ot5 - 1);
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                this.Text = "Угадайка. Ваш счет " + label8.Text + " балл/ов/а";
                button2.Enabled = true;
                pictureBox3.Visible = true;

            }

            if (Convert.ToInt32(label1.Text) == Convert.ToInt32(label2.Text) + 1)
            {
                button3.Visible = true;
                MessageBox.Show("Вопросы кончились, красавчик. Жми 'Выход'");
                button2.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.open);
            audio.Play();
        }


        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.close);
            //audio.Play();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SoundPlayer audio = new SoundPlayer(Ugadayka.Properties.Resources.close);
            //audio.Play();
        }
    }
}
