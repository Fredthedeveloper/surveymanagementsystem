﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newsurvey
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister f3 = new frmRegister();
            f3.ShowDialog();
            this.Close();
        }

        private void buttonCloseC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            FrmRegisterCust f3 = new FrmRegisterCust ();
            f3.ShowDialog();
            this.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox3.Dispose();
        
           
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
