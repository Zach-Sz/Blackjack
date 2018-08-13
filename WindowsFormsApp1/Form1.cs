using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form : System.Windows.Forms.Form
    {
        Random rnd = new Random();
        int j = 0;
        int f = 0;

        int playercount = 0;
        int compcount = 0;
        int playerscore = 0;
        int compscore = 0;

        public Form()
        {

            int[] playerinithand = randomplayer();
            int[] compinithand = randomcomp();

            InitializeComponent();
            System.Windows.Forms.MessageBox.Show("Welcome to Blackjack. Please select OK to enter the game.", "Blackjack", MessageBoxButtons.OK);

            pictureBox1.Image = imageList1.Images[(playerinithand[0] - 1)];
            pictureBox2.Image = imageList1.Images[(playerinithand[1] - 1)];

            pictureBox8.Image = imageList1.Images[(compinithand[0] - 1)];

            if (playerinithand[0] == 11 || playerinithand[0] == 12 || playerinithand[0] == 13)
                playerinithand[0] = 10;
            if (playerinithand[1] == 11 || playerinithand[1] == 12 || playerinithand[1] == 13)
                playerinithand[1] = 10;
            if (compinithand[0] == 11 || compinithand[0] == 12 || compinithand[0] == 13)
                compinithand[0] = 10;

            playercount = playerinithand[0] + playerinithand[1];
            compcount = compinithand[0];

            label7.Text = playercount.ToString();
            label8.Text = compcount.ToString();
        }

        // Close button shuts down the game unless th user decides to keep playing
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to exit?", "Blackjack", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Close();
        }

        private Int32[] randomplayer()
        {
            int[] randomnumberpl = new int[] { rnd.Next(1, 13), rnd.Next(1, 13) };
            return randomnumberpl;
        }

        private Int32[] randomcomp()
        {
            int[] randomnumberco = new int[] { rnd.Next(1, 13), rnd.Next(1, 13) };
            return randomnumberco;
        }

        private Int32 randomnum()
        {
            int randomnumberco = rnd.Next(1, 13);
            return randomnumberco;
        }

        private void startup()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;
            pictureBox13.Image = null;
            pictureBox14.Image = null;

            int[] playerinithand = randomplayer();
            int[] compinithand = randomcomp();

            pictureBox1.Image = imageList1.Images[(playerinithand[0] - 1)];
            pictureBox2.Image = imageList1.Images[(playerinithand[1] - 1)];

            pictureBox8.Image = imageList1.Images[(compinithand[0] - 1)];

            if (playerinithand[0] == 11 || playerinithand[0] == 12 || playerinithand[0] == 13)
                playerinithand[0] = 10;
            if (playerinithand[1] == 11 || playerinithand[1] == 12 || playerinithand[1] == 13)
                playerinithand[1] = 10;
            if (compinithand[0] == 11 || compinithand[0] == 12 || compinithand[0] == 13)
                compinithand[0] = 10;

            playercount = playerinithand[0] + playerinithand[1];
            compcount = compinithand[0];

            label7.Text = playercount.ToString();
            label8.Text = compcount.ToString();
        }

        public void button3_Click(object sender, EventArgs e)
        {

            while (j == 4)
            {
                int number = randomnum();
                pictureBox7.Image = imageList1.Images[(number - 1)];
                if (number == 11 || number == 12 || number == 13)
                    number = 10;
                playercount = number + playercount;
                label7.Text = playercount.ToString();
                j = 5;
            }

            while (j == 3)
            {
                int number = randomnum();
                pictureBox6.Image = imageList1.Images[(number - 1)];
                if (number == 11 || number == 12 || number == 13)
                    number = 10;
                playercount = number + playercount;
                label7.Text = playercount.ToString();
                j = 4;
            }

            while (j == 2)
            {
                int number = randomnum();
                pictureBox5.Image = imageList1.Images[(number - 1)];
                if (number == 11 || number == 12 || number == 13)
                    number = 10;
                playercount = number + playercount;
                label7.Text = playercount.ToString();
                j = 3;
            }

            while (j == 1)
            {
                int number = randomnum();
                pictureBox4.Image = imageList1.Images[(number - 1)];
                if (number == 11 || number == 12 || number == 13)
                    number = 10;
                playercount = number + playercount;
                label7.Text = playercount.ToString();
                j = 2;
            }

            while (j == 0)
            {
                int number = randomnum();
                pictureBox3.Image = imageList1.Images[(number - 1)];
                if (number == 11 || number == 12 || number == 13)
                    number = 10;
                playercount = number + playercount;
                label7.Text = playercount.ToString();
                j = 1;
            }

            if (playercount > 21)
                playerover();
            if (j >= 5)
                System.Windows.Forms.MessageBox.Show("Cannot get anymore cards. Please click Stand in order to proceed", "Blackjack", MessageBoxButtons.OK);

        }

        private void playerover()
        {
            int k = 0;
            DialogResult loseresult = System.Windows.Forms.MessageBox.Show("You went over 21 and lost. Would you like to continue?", "Blackjack", MessageBoxButtons.YesNo);
            if (loseresult == DialogResult.No)
            {
                Close();
            }
            else
            {
                compscore = compscore + 1;
                label13.Text = compscore.ToString();
                playercount = 0;
                compcount = 0;
                k = 0;
                j = 0;
                startup();
            }
        }
        private void result()
        {
            int k = 0;

            if (playercount == compcount || (playercount > 21 & compcount > 21))
            {
                DialogResult tieresult = System.Windows.Forms.MessageBox.Show("It's a tie. Would you like to continue?", "Blackjack", MessageBoxButtons.YesNo);
                if (tieresult == DialogResult.No)
                {
                    Close();
                }
                else
                {
                    playercount = 0;
                    compcount = 0;
                    k = 0;
                    j = 0;
                    startup();
                }
            }
            else if ((playercount > compcount & playercount <= 21) || compcount > 21)
            {
                DialogResult winresult = System.Windows.Forms.MessageBox.Show("Congratulations! You won! Would you like to continue?", "Blackjack", MessageBoxButtons.YesNo);
                if (winresult == DialogResult.No)
                {
                    Close();
                }
                else
                {
                    playerscore = playerscore + 1;
                    label12.Text = playerscore.ToString();
                    playercount = 0;
                    compcount = 0;
                    k = 0;
                    j = 0;
                    startup();

                }
            }
            else if ((playercount > 21 & compcount <= 21) || compcount > playercount)
            {
                DialogResult loseresult = System.Windows.Forms.MessageBox.Show("You lost. Would you like to continue?", "Blackjack", MessageBoxButtons.YesNo);
                if (loseresult == DialogResult.No)
                {
                    Close();
                }
                else
                {
                    compscore = compscore + 1;
                    label13.Text = compscore.ToString();
                    playercount = 0;
                    compcount = 0;
                    k = 0;
                    j = 0;
                    startup();

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;

            while (compcount <= 17)
            {
                int number = randomnum();

                if (k == 5)
                {
                    pictureBox14.Image = imageList1.Images[(number - 1)];
                    if (number == 11 || number == 12 || number == 13)
                        number = 10;
                    compcount = number + compcount;
                    label8.Text = compcount.ToString();
                }

                if (k == 4)
                {
                    pictureBox13.Image = imageList1.Images[(number - 1)];
                    if (number == 11 || number == 12 || number == 13)
                        number = 10;
                    compcount = number + compcount;
                    label8.Text = compcount.ToString();
                    k = 5;
                }

                if (k == 3)
                {
                    pictureBox12.Image = imageList1.Images[(number - 1)];
                    if (number == 11 || number == 12 || number == 13)
                        number = 10;
                    compcount = number + compcount;
                    label8.Text = compcount.ToString();
                    k = 4;
                }

                if (k == 2)
                {
                    pictureBox11.Image = imageList1.Images[(number - 1)];
                    if (number == 11 || number == 12 || number == 13)
                        number = 10;
                    compcount = number + compcount;
                    label8.Text = compcount.ToString();
                    k = 3;
                }

                if (k == 1)
                {
                    pictureBox10.Image = imageList1.Images[(number - 1)];
                    if (number == 11 || number == 12 || number == 13)
                        number = 10;
                    compcount = number + compcount;
                    label8.Text = compcount.ToString();
                    k = 2;
                }

                if (k == 0)
                {
                    pictureBox9.Image = imageList1.Images[(number - 1)];
                    if (number == 11 || number == 12 || number == 13)
                        number = 10;
                    compcount = number + compcount;
                    label8.Text = compcount.ToString();
                    k = 1;
                }

            }

            result();

            }

        }

}

