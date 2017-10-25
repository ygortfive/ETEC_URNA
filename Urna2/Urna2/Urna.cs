using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urna2
{
    public partial class Urna : Form
    {
        public Urna()
        {
            InitializeComponent();
            txt_num.MaxLength = 2;
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            //txt_num.AppendText("1");
            /*
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "1";
            }
            else if (lbl_num2.Text == "") 
            {
                lbl_num2.Text = "1";
            }
             */
        }
        /*
        private void btn_2_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "2";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "2";
            }
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "3";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "3";
            }
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "4";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "4";
            }
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "5";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "5";
            }
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "6";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "6";
            }
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "7";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "8";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "8";
            }

        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "9";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "9";
            }
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            if (lbl_num1.Text == "")
            {
                lbl_num1.Text = "0";
            }
            else if (lbl_num2.Text == "")
            {
                lbl_num2.Text = "0";
            }
        }

        private void btn_Corrigir_Click(object sender, EventArgs e)
        {
            lbl_num1.Text = "";
            lbl_num2.Text = "";
        }
         */

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer pal = new System.Media.SoundPlayer(@"");
            //pal.Play();
        }

        private void btn_1_Click_1(object sender, EventArgs e)
        {
            txt_num.AppendText("1");
        }

        private void txt_num_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
