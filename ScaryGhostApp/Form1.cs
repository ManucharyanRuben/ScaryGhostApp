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
    public partial class Ghost :  Form //test
    {
        int k = 0;
        int p = 0;
        bool play = false;
        bool t1 = false, t2 = false;

        //   SoundPlayer players = new SoundPlayer(@"C:\scream.wav");


        public Ghost()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;

        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = true;
            if (t1 == true)
            {
                variant1();
            }
            else if (t2 == true)
            {
                variant2();
            }



        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            this.Visible = false;

            int rnd = Randomize();
            if (rnd == 1)
            {


                this.Top = 20;
                this.Left = -700;
                t1 = true;
                timer4.Enabled = true;

            }
            else if (rnd == 2)
            {
                this.Top = 500;
                this.Left = 500;
                t2 = true;
                timer4.Enabled = true;
            }


            timer2.Enabled = false;
        }


        public int Randomize()
        {
            Random rand = new Random();
            int rnd = rand.Next(1, 3);
            return rnd;
        }



        public void variant1()
        {
            this.Left += 5;
            if (this.Left > 1500)
            {
                timer2.Enabled = true;
                this.Visible = false;
                t1 = false;
            }

        }

        public void variant2()
        {
            this.Top -= 35;

            if (this.Top < 0 - this.Height)
            {
                timer2.Enabled = true;
                this.Visible = false;
                t2 = false;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer4.Enabled = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // timer3.Enabled = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'k')
            {
                k++;
            }
            else if (e.KeyChar == 'i' & k == 1)
            {
                k++;
            }
            else if (e.KeyChar == 'l' & k == 2)
            {
                k++;
            }
            else if (e.KeyChar == 'l' & k == 3)
            {

                Application.Exit();
            }
            else
            {
                k = 0;
            }


            if (e.KeyChar == 'p')
            {
                p++;
            }
            else if (e.KeyChar == 'l' & p == 1)
            {
                p++;
            }
            else if (e.KeyChar == 'a' & p == 2)
            {
                p++;
            }
            else if (e.KeyChar == 'y' & p == 3)
            {
                play = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;

            }
            else
            {
                p = 0;
            }


        }






        private void timer5_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            timer2.Enabled = true;
            timer5.Enabled = false;
            //players.Play();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


            if (play == true)
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

        private void Form1_Move(object sender, EventArgs e)
        {


        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
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
