using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9АРКАНОИД_ФИНАЛ
{
    public partial class USERS_FORM : Form
    {
        public USERS_FORM()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void USERS_FORM_FormClosing(object sender, FormClosingEventArgs e)
        {
            AUTHORISATION f = new AUTHORISATION();
            f.Show();
        }
    }
}
