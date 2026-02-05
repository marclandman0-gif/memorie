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

        List<string> icons = new List<string>()
        {
        "%", "%", "Q", "Q", "S", "S", "m", "m" ,"*", "*", 
        "n", "n", "!", "!", "(", "(", "C", "C"
        };

        Label firstClicked, secondClicked;
        

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Black)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckerForWinner();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }
            else
                timer2.Start();
        }

        private void CheckerForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
               label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            MessageBox.Show ("You matched all the icons!", "Congratulations");
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void AssignIconsToSquares()
        {
           Label label;
            int randomNumber;


            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            { 
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];

                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);

            }
        }
    }
}