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

        private void label(object sender, EventArgs e)
        {
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