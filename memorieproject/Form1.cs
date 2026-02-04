using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memorieproject
{
    public partial class Form1 : Form
    {
        private int totalSeconds = 0;
        private const int TIMER_INTERVAL = 1; // << change: increment in seconds per Tick
        Random random = new Random();


        public Form1()
        {
            InitializeComponent();
        }


        private void Button_click(object sender, EventArgs e)
        {
            Button butt = sender as Button;
            butt.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void score_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTimeLabel()
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            timer.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            totalSeconds += TIMER_INTERVAL;
            UpdateTimeLabel();
            timer1.Enabled = true;
        }
    }
}