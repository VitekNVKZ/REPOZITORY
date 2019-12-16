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
    public partial class LOADING : Form
    {
        public LOADING()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            timer1.Interval = 3000;
            timer1.Enabled = true;

        }
    }
}
