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
    public partial class surveyDashCust : Form
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

        public surveyDashCust()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


            panelNav.Height = BtnDashboard.Height;
            panelNav.Top = BtnDashboard.Top;
            panelNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(116, 86, 174);
        }

        private void surveyDashCust_Load(object sender, EventArgs e)
        {
            labelname.Text = FrmLoginCust.recall;
            labelname.Text = labelname.Text.ToUpper();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            surveyDashCust f7 = new  surveyDashCust ();
            f7.ShowDialog();
            this.Close();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoginCust f8 = new  FrmLoginCust ();
            f8.ShowDialog();
            this.Close();
        }

        private void buttonCloseC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnsSurvey f4 = new AnsSurvey();
            f4.ShowDialog();
            this.Close();
        }

        private void buttonClick(object sender, EventArgs e)
        {

        }

        private void playAI(object sender, EventArgs e)
        {

        }

        private void resetGame(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
