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

namespace ScaryGhostApp
{
    public partial class Ghsot : Form
    {
        int kill = 0;
        int play = 0;
        bool IsPlay = false;
        bool IsChoosenFirst = false, IsChoosenSecond = false;

        SoundPlayer playSound = new SoundPlayer(@"Resources\Sounds\scream.wav");

        SoundPlayer playSoundTrack = new SoundPlayer(@"Resources\Sounds\scary.wav");

        public Ghsot()
        {
            InitializeComponent();
        }

        private void Ghost_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }


        private void TimerDo_Tick(object sender, EventArgs e)
        {
            this.Visible = true;
            if (IsChoosenFirst == true)
            {
                FirstOption();
            }
            else if (IsChoosenSecond == true)
            {
                SecondOption();
            }

        }

        private void TimerRanomeMove_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            this.Visible = false;

            int rnd = Randomize();
            if (rnd == 1)
            {


                this.Top = 20;
                this.Left = -700;
                IsChoosenFirst = true;
                timer4.Enabled = true;

            }
            else if (rnd == 2)
            {
                this.Top = 500;
                this.Left = 500;
                IsChoosenSecond = true;
                timer4.Enabled = true;
            }


            timer2.Enabled = false;
        }


        public int Randomize()
        {
            Random rand = new Random();
            int rnd = rand.Next(1, 3);
            playSoundTrack.Play();
            return rnd;
        }



        public void FirstOption()
        {
            this.Left += 5;
            if (this.Left > 1500)
            {
                timer2.Enabled = true;
                this.Visible = false;
                IsChoosenFirst = false;
            }

        }

        public void SecondOption()
        {
            this.Top -= 35;

            if (this.Top < 0 - this.Height)
            {
                timer2.Enabled = true;
                this.Visible = false;
                IsChoosenSecond = false;
            }
        }

        private void TimerStart_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer4.Enabled = false;
        }


        private void Ghost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'k')
            {
                kill++;
            }
            else if (e.KeyChar == 'i' & kill == 1)
            {
                kill++;
            }
            else if (e.KeyChar == 'l' & kill == 2)
            {
                kill++;
            }
            else if (e.KeyChar == 'l' & kill == 3)
            {

                Application.Exit();
            }
            else
            {
                kill = 0;
            }


            if (e.KeyChar == 'p')
            {
                play++;
            }
            else if (e.KeyChar == 'l' & play == 1)
            {
                play++;
            }
            else if (e.KeyChar == 'a' & play == 2)
            {
                play++;
            }
            else if (e.KeyChar == 'y' & play == 3)
            {
                IsPlay = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;

            }
            else
            {
                play = 0;
            }


        }

        private void TimerSound_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            timer2.Enabled = true;
            timer5.Enabled = false;
            playSound.Play();
        }

        private void Ghost_KeyDown(object sender, KeyEventArgs e)
        {


            if (IsPlay == true)
            {



                if (e.KeyCode == Keys.Up)
                {

                    this.Top -= 10;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    this.Top += 10;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    this.Left -= 10;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    this.Left += 10;
                }
            }
        }



        private void TimerSize_Tick(object sender, EventArgs e)
        {
            this.Height += 40;
            this.Width += 40;
            this.Top -= 8;
            this.Left -= 8;


            //if (this.Top < 0 - this.Height)
            //{
            //    timer2.Enabled = true;
            //    timer1.Enabled = false;

            //}
        }
    }
}