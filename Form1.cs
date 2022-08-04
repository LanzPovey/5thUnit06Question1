//NAME: Lanz Povey
//DATE: June 3rd 2016
//TEACHER: Mr. Wachs
//ASSIGNEMENT: Computer Science 20S, Unit 5: Looping. Question 3.
//PURPOSE: The purpose of this program is to fufill the needs of gamblers (though more specifically, the gamblers at the Assiniboia Downs Race Track) by acting as a race that they can beat on between two rocket ships in a space race to the finish!
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _5thUnit06Question1
{
    public partial class frmRocketRacing : Form
    {
        double cash = 100.00;
        // Change this Variable from an Integer to a Double so both the total of the Bet and the Cash can be added together after the race.
        // The Double cash variable has to be Global since if it was in the Start Race Button code, it would reset each time that button is clicked.
        public frmRocketRacing()
        {
            InitializeComponent();
        }
        private void frmRocketRacing_Load(object sender, EventArgs e)
        {
            cmbPickYourRocket.Items.Add("Rocket 1");
            cmbPickYourRocket.Items.Add("Rocket 2");
        }
        private void btnStartRace_Click(object sender, EventArgs e)
        {
            lblResults.Text = ""; // This resets the Results Label Text so that it doesn't concatenate messages over itself over and over again.
            if (cmbPickYourRocket.Text == "") MessageBox.Show("Choose what rocket you're betting on! (Here's a hint, the one that's the most red ALWAYS wins!)");
            else if (txbBetMoney.Text == "") MessageBox.Show("Put in the amount of money you're going to give us, ERM, I mean WIN!");
            else
            {
                double bet = Convert.ToDouble(txbBetMoney.Text);
                if (bet > cash) MessageBox.Show("You don't even have enough money for that! I recommend getting a small loan of a million dollars from the bank! (Our bank of course)");
                else
                {
                    // Sets how many Y pixels seperate the image from the top of the screen, via the Y axis.
                    const int STARTING_LINE = 350, FINISH_LINE = -20;
                    picRocket1.Top = STARTING_LINE;
                    picRocket2.Top = STARTING_LINE;
                    Random random = new Random();
                    while (picRocket1.Top > FINISH_LINE && picRocket2.Top > FINISH_LINE)
                    {
                        picRocket1.Top -= random.Next(0, 50);
                        picRocket2.Top -= random.Next(0, 50);
                        System.Threading.Thread.Sleep(25);
                        // This makes the rocket pause after every random movement, so it won't instantly appear at the finish line.
                    }
                    if (picRocket1.Top <= FINISH_LINE && picRocket2.Top <= FINISH_LINE)
                    {
                        lblResults.Text = "Happy? Now, since it's a tie NOBODY get's the money! " +
                            "Come one, this gold throne ain't gonna build itself you know!";
                    }
                    else if (picRocket1.Top <= FINISH_LINE)
                    {
                        lblResults.Text = "Rocket 1 wins the race,";
                        if (cmbPickYourRocket.Text == "Rocket 1")
                        {
                            lblResults.Text += " so you win double your bet!";
                            cash += +(bet * 2);
                        }
                        else
                        {
                            lblResults.Text += " but you lose your bet!";
                            cash -= bet;
                        }
                    }
                    else if (picRocket2.Top <= FINISH_LINE)
                    {
                        lblResults.Text = "Rocket 2 wins the race,";
                        if (cmbPickYourRocket.Text == "Rocket 2")
                        {
                            lblResults.Text += " so you win double your bet!";
                            cash += +(bet * 2);
                        }
                        else
                        {
                            lblResults.Text += " but you lose your bet!";
                            cash -= bet;
                        }
                    }
                }
                txbBetMoney.Select(txbBetMoney.Text.Length,0);
                lblCash.Text = String.Format("{0:C}", cash);
                // This line of code both adds the dollar sign at the end of the code and rounds it off to 2 decimal points!
                txbBetMoney.Focus();
                // This makes it so that the mouse cursor goes back unto the bet option, so they can easily change their bet and so that they won't spam click enter and break the system.
            }
            if (cash <= 0)
            {
                MessageBox.Show("You lose, but I WIN! Thanks for all the money! (Now, I can use this money, to make more money and use that money to maxe EVEN MORE money!");
                Application.Exit();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
