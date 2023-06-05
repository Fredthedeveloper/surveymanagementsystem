using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace newsurvey
{
    public partial class Surveydash : Form
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn

            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse




            );


        public Surveydash()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


            panelNav.Height = BtnDashboard.Height;
            panelNav.Top = BtnDashboard.Top;
            panelNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(116, 86, 174);
        }

        private void Surveydash_Load(object sender, EventArgs e)
        {
            labelname.Text = frmLogin.recall;
            labelname.Text = labelname.Text.ToUpper();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            

            this.Hide();
           Surveydash f7 = new Surveydash();
            f7.ShowDialog();
            this.Close();
        }

        private void btnV_Click(object sender, EventArgs e)
        {

           


            this.Hide();
            ViewSurvey f8 = new ViewSurvey();
            f8.ShowDialog();
            this.Close();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            


            this.Hide();
            CreateSurvey f2 = new CreateSurvey();
            f2.ShowDialog();
            this.Close();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            this.Hide();
            analysis f13 = new analysis();
            f13.ShowDialog();
            this.Close();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            frmLogin f8 = new frmLogin();
            f8.ShowDialog();
            this.Close();
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnDashboard_Leave(object sender, EventArgs e)
        {
           
        }

        private void btnV_Leave(object sender, EventArgs e)
        {
           
        }

        private void btnC_Leave(object sender, EventArgs e)
        {
           
        }

        private void btnA_Leave(object sender, EventArgs e)
        {
           
        }

        private void btnL_Leave(object sender, EventArgs e)
        {
            
        }

        private void buttonS_Leave(object sender, EventArgs e)
        {
            
        }

        private void buttonCloseC_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
