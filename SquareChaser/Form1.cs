using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SquareChaser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SoundPlayer beep = new SoundPlayer(Properties.Resources.score_beep);

        SoundPlayer cheers = new SoundPlayer(Properties.Resources.cheers);

        SoundPlayer whoosh = new SoundPlayer(Properties.Resources.whoosh);

        Random randGen = new Random();

        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 4;
        int player2Speed = 4;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush yellowBrush = new SolidBrush(Color.Goldenrod);
        SolidBrush greenBrush = new SolidBrush(Color.ForestGreen);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        Rectangle scoreSquare;
        Rectangle player1;
        Rectangle player2;
        Rectangle speedBoost1;
        Rectangle speedBoost2;
        Rectangle speedBoost3;
        Rectangle speedBoost4;

        private void Form1_Load(object sender, EventArgs e)
        {
            player1 = new Rectangle(100, 200, 30, 30);
            player2 = new Rectangle(680, 200, 30, 30);

            Random randGen = new Random();

            scoreSquare = new Rectangle(GetRandomX(), GetRandomY(), 15, 15);

            
            speedBoost1 = new Rectangle(GetRandomX(), GetRandomY(), 15, 15);


            speedBoost2 = new Rectangle(GetRandomX(), GetRandomY(), 15, 15);

            speedBoost3 = new Rectangle(GetRandomX(), GetRandomY(), 15, 15);

            speedBoost4 = new Rectangle(GetRandomX(), GetRandomY(), 15, 15);

            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;

            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height-player1.Height-40)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width-20)
            {
                player1.X += player1Speed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height-player2.Height-40)
            {
                player2.Y += player2Speed;
            }

            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            if (rightArrowDown == true && player2.X < this.Width-player2.Width-20)
            {
                player2.X += player2Speed;
            }

            //make speed boosts work (move player to a new random spot if they hit a boost)
            if (player1.IntersectsWith(speedBoost1))
            {
                player1Speed += 2;

                whoosh.Play();
                
                Random randGen = new Random();
                player1.X = GetRandomX();
                player1.Y = GetRandomY();

                speedBoost1.X = GetRandomX();
                speedBoost1.Y = GetRandomY();
            }

            if (player1.IntersectsWith(speedBoost2))
            {
                player1Speed += 2;

                whoosh.Play();

                Random randGen = new Random();
                player1.X = GetRandomX();
                player1.Y = GetRandomY();

                speedBoost2.X = GetRandomX();
                speedBoost2.Y = GetRandomY();
            }

            if (player1.IntersectsWith(speedBoost3))
            {
                player1Speed += 2;

                whoosh.Play();


                Random randGen = new Random();
                player1.X = GetRandomX();
                player1.Y = GetRandomY();

                speedBoost3.X = GetRandomX();
                speedBoost3.Y = GetRandomY();
            }

            if (player1.IntersectsWith(speedBoost4))
            {
                player1Speed += 2;

                whoosh.Play();


                Random randGen = new Random();
                player1.X = GetRandomX();
                player1.Y = GetRandomY();

                speedBoost4.X = GetRandomX();
                speedBoost4.Y = GetRandomY();
            }

            if (player2.IntersectsWith(speedBoost1))
            {
                player2Speed += 2;


                whoosh.Play();

                Random randGen = new Random();
                player2.X = GetRandomX();
                player2.Y = GetRandomY();

                speedBoost1.X = GetRandomX();
                speedBoost1.Y = GetRandomY();
            }

            if (player2.IntersectsWith(speedBoost2))
            {
                player2Speed += 2;

                whoosh.Play();

                Random randGen = new Random();
                player2.X = GetRandomX();
                player2.Y = GetRandomY();

                speedBoost2.X = GetRandomX();
                speedBoost2.Y = GetRandomY();
            }

            if (player2.IntersectsWith(speedBoost3))
            {
                player2Speed += 2;

                whoosh.Play();

                Random randGen = new Random();
                player2.X = GetRandomX();
                player2.Y = GetRandomY();

                speedBoost3.X = GetRandomX();
                speedBoost3.Y = GetRandomY();
            }

            if (player2.IntersectsWith(speedBoost4))
            {
                player2Speed += 2;

                whoosh.Play();


                Random randGen = new Random();
                player2.X = GetRandomX();
                player2.Y = GetRandomY();

                speedBoost4.X = GetRandomX();
                speedBoost4.Y = GetRandomY();
            }

            //add points for running into the green (move player to a new random spot if they hit, add point)
            if (player1.IntersectsWith(scoreSquare) && player1Score < 5)
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                beep.Play();

                Random randGen = new Random();

                player1.X = GetRandomX();
                player1.Y = GetRandomY();

                scoreSquare.X = GetRandomX();
                scoreSquare.Y = GetRandomY();

            }

            if (player2.IntersectsWith(scoreSquare) && player2Score < 5)
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                beep.Play();

                Random randGen = new Random();

                player2.X = GetRandomX();
                player2.Y = GetRandomY();

                scoreSquare.X = GetRandomX();
                scoreSquare.Y = GetRandomY();

            }

            if (player1Score == 5)
            {
                winnerLabel.Text = "PLAYER 1 WINS";
                cheers.Play();
                timer1.Enabled = false;
            }

            if (player2Score == 5)
            {
                winnerLabel.Text = "PLAYER 2 WINS";
                cheers.Play();
                timer1.Enabled = false;
            }


            Refresh();
        }


        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(greenBrush, scoreSquare);
            e.Graphics.FillRectangle(yellowBrush, speedBoost1);
            e.Graphics.FillRectangle(yellowBrush, speedBoost2);
            e.Graphics.FillRectangle(yellowBrush, speedBoost3);
            e.Graphics.FillRectangle(yellowBrush, speedBoost4);
            e.Graphics.FillRectangle(blackBrush, player1);
            e.Graphics.FillRectangle(blackBrush, player2);
        }

        //gets a random x coordinate
        public int GetRandomX()
        {

            int x = randGen.Next(0,this.Width - 50);
            return x;
        }

        //gets a random y coordinate
        public int GetRandomY()
        {

           int y = randGen.Next(0, this.Height - 50);
            return y;
        }
    }
}
