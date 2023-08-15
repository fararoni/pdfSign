using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nekdu
{
    public partial class Splash : Form
    {
        System.Windows.Forms.Timer timer;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            //MainForm main = new MainForm();
            FormBaseWizard main = new FormBaseWizard();
            main.Show();
            this.Hide();

        }
    }
}
