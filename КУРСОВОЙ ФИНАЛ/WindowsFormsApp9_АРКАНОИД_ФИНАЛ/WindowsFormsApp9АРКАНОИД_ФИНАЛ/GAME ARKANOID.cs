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

namespace WindowsFormsApp9АРКАНОИД_ФИНАЛ
{
    public partial class Form2 : Form
    {
        bool goRight;
        bool goLeft;
        int speed = 10;
        int ballx = 5;
        int bally = 5;
        int score = 0;

        private Random rnd = new Random();

        public Form2()
        {
            InitializeComponent();
            

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "block")
                {
                    Color RandomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    x.BackColor = RandomColor;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

           
        }

        private void Form2_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

            //если игрок нажимает кнопку лево и игрок находится внутри панели. ставим нашу ракетку слева, булеан тру

            if (e.KeyCode == Keys.Left && player.Left >0)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && player.Left + player.Width < 670)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Left += ballx;
            ball.Top += bally;
            label1.Text = "Очки " + score;
            if (goLeft)
            {
                player.Left -= speed;
            }
            if (goRight)
            {
                player.Left += speed;
            }
            if (player.Left < 1)
            {
                goLeft = false;
            }
            else if (player.Left + player.Width > 670)
            {
                goRight = false;
            }
            if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
            {
                ballx = -ballx;
            }
            if (ball.Top < 0 || ball.Bounds.IntersectsWith(player.Bounds))
            {
                bally = -bally;
            }
            if (ball.Top +ball.Height > ClientSize.Height)
            {
                GameOver();
                MessageBox.Show("Вы проиграли");
                timer1.Stop();
            }
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        bally = -bally;
                        score++;
                    }
                }
            }

                if (score > 34)
            {
                GameOver();
                MessageBox.Show("Вы победили");
                timer1.Stop();
            }
            //имя игрока и его счет в верхнем поле названия окна
            this.Text = "Имя " + player.Text.ToString() + ", Счет " + score;
        }
        void GameOver()
        {
            timer1.Stop();

            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();

            DateTime dateTimeVariable = DateTime.Now;
            string date1 = dateTimeVariable.ToString("yyyy-MM-dd");
            string date2 = dateTimeVariable.ToString("H:mm:ss");
            string s = "INSERT INTO PLAYERS " +
                "(id_players, Name_players, score, data_igra, vremya_igra) VALUES" +
                "('" + Program.id_user + "'," +
                "'" + player.Text.ToString() + "'," +
                "'" + score + "', " +
                "'" + date1 + "', " +
                "'" + date2 + "')";
            SqlCommand command = new SqlCommand(s, conn);

            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            string s = "SELECT login_user FROM USERS WHERE id_user= " + Program.id_user;
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            reader.GetString(0);
            player.Text = reader.GetString(0);
            label2.Text = "Имя игрока " + reader.GetString(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.type_user == false)
            {
                USERS_FORM f = new USERS_FORM();
                if (!f.Visible)
                    f.Show();
            }
            else
            {
                Form3 f = new Form3();
                if (!f.Visible)
                    f.Show();
            }
        }
    }
}
