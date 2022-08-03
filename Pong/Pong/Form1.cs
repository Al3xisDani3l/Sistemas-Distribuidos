using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        int vel = 5;
        int direc = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try //bloque a evaluar en caso de error…
            {
                if (direc == 1) //abajo der
                {
                    bola.Left = bola.Left + vel;
                    bola.Top = bola.Top + vel;
                    if ((bola.Top + bola.Height) >= this.Height) direc
                      = 2;
                    if ((bola.Left + bola.Width) >= this.Width) direc
                     = 3;
                }
                if (direc == 2) //arriba der
                {
                    bola.Left = bola.Left + vel;
                    bola.Top = bola.Top - vel;
                    if ((bola.Top) <= 0) direc = 1;
                    if ((bola.Left + bola.Width) >= this.Width)
                        direc = 4;
                }
                if (direc == 3) //abajo iz
                {
                    bola.Left = bola.Left - vel;
                    bola.Top = bola.Top + vel;
                    if ((bola.Top) >= this.Height) direc = 4;
                    if ((bola.Left) <= 0) direc = 1;
                }
                if (direc == 4) //arriba iz
                {
                    bola.Left = bola.Left - vel;
                    bola.Top = bola.Top - vel;
                    if ((bola.Top) <= 0) direc = 3;
                    if (bola.Left <= 0) direc = 2;
                }

            }
        
            catch // bloque en caso de error
            {
                MessageBox.Show("error de dirección");
                Close();
            }
        }

        private void bola_Click(object sender, EventArgs e)
        {
            //vel++;
            timer1.Interval--;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
