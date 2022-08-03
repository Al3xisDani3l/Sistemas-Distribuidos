using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A6___Conversion_de_unidades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var text = (TextBox)sender;

            float result = 0;

            if (!string.IsNullOrEmpty(text.Text))
            {
                if (float.TryParse(text.Text, out result))
                {
                    label1.Text = $"{result + 273.15} K";

                    label3.Text = $"{(result * (9 / 5)) + 32} F";
                }
                else
                {
                    MessageBox.Show("Introduce solo caracteres numericos");
                    text.Clear();
                }
            }

           

        }
    }
}
