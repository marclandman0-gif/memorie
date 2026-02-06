using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace memorieproject
{
    public partial class Form1 : Form
    {
        // Houdt bij hoeveel seconden zijn verstreken (wordt hier nog niet gebruikt)
        private int totalSeconds = 0;

        // Interval voor een timer (1 seconde per tick)
        private const int TIMER_INTERVAL = 1;

        // Random object om willekeurige iconen te kiezen
        Random random = new Random();

        // Lijst met iconen (elk icoon komt twee keer voor)
        List<string> icons = new List<string>()
        {
            "%", "%", "Q", "Q", "S", "S", "m", "m",
            "*", "*", "n", "n", "!", "!", "(", "(",
            "C", "C"
        };

        // Labels die onthouden welke kaarten zijn aangeklikt
        Label firstClicked, secondClicked;

        public Form1()
        {
            InitializeComponent();

            // Verdeel de iconen willekeurig over het speelveld
            AssignIconsToSquares();
        }

        // Wordt uitgevoerd wanneer een label wordt aangeklikt
        private void label_Click(object sender, EventArgs e)
        {
            // Als er al twee kaarten open zijn, niks doen
            if (firstClicked != null && secondClicked != null)
                return;

            // Het aangeklikte object omzetten naar een Label
            Label clickedLabel = sender as Label;

            // Als het geen label is, stoppen
            if (clickedLabel == null)
                return;

            // Als de kaart al zichtbaar is, niks doen
            if (clickedLabel.ForeColor == Color.Black)
                return;

            // Eerste kaart aanklikken
            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black; // Maak het icoon zichtbaar
                return;
            }

            // Tweede kaart aanklikken
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            // Check of alle paren gevonden zijn
            CheckerForWinner();

            // Als de iconen gelijk zijn → paar gevonden
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }
            else
            {
                // Start timer om kaarten weer te verbergen
                timer2.Start();
            }
        }

        // Controleert of alle iconen zichtbaar zijn
        private void CheckerForWinner()
        {
            Label label;

            // Loop door alle labels in het speelveld
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                // Als er nog een verborgen kaart is → nog niet gewonnen
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            // Alle kaarten zijn gevonden → speler wint
            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }

        // Timer die kaarten weer omdraait als ze niet matchen
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            // Verberg beide kaarten weer
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset de geselecteerde kaarten
            firstClicked = null;
            secondClicked = null;
        }

        // Verdeelt de iconen willekeurig over de labels
        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;

            // Loop door alle vakjes in het speelveld
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                // Alleen labels gebruiken
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                // Kies een willekeurig icoon
                randomNumber = random.Next(0, icons.Count);

                // Zet het icoon in het label
                label.Text = icons[randomNumber];

                // Verwijder het icoon zodat het niet opnieuw gebruikt wordt
                icons.RemoveAt(randomNumber);
            }
        }
    }
}
