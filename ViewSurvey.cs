using MySqlConnector;
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



    public partial class ViewSurvey : Form
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



        public ViewSurvey()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = btnV.Height;
            panelNav.Top = btnV.Top;
            panelNav.Left = btnV.Left;
            btnV.BackColor = Color.FromArgb(116, 86, 174);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Surveydash f2 = new Surveydash();
            f2.ShowDialog();
            this.Close();
        }

        private void btnV_Click(object sender, EventArgs e)
        {
           

            this.Hide();
            ViewSurvey f3 = new ViewSurvey();
            f3.ShowDialog();
            this.Close();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            CreateSurvey f6 = new CreateSurvey();
            f6.ShowDialog();
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

        private void ViewSurvey_Load(object sender, EventArgs e)
        {
            labelname.Text = frmLogin.recall;
            labelname.Text = labelname.Text.ToUpper();


            Db db = new Db();

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= surveystu");
            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `admin_post` WHERE `Name`=@Na ", db.getConnection());
            command.Parameters.AddWithValue("@Na", Convert.ToString(labelname.Text));


            MySqlDataReader myReader = command.ExecuteReader();


            while (myReader.Read())
            {



                comboBoxTitle.Items.Add(myReader["Title"]);


            }
            db.closeConnection();

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
          
            }

        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

            Db db = new Db();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= survey_app");

            db.openConnection();
            if (comboBoxTitle.Text != "")
            {


                MySqlCommand command = new MySqlCommand("SELECT `Name`, `Title`, `QA`, `QB`, `QC`, `QD`, `QE`, `QF`, `QG`, `QH`, `QI`, `QJ`, `QK` FROM `admin_post` WHERE `Title`= @Tit AND `Name`= @Na ", db.getConnection());
                command.Parameters.AddWithValue("@Tit", Convert.ToString(comboBoxTitle.Text));
                command.Parameters.AddWithValue("@Na", Convert.ToString(labelname.Text));
                MySqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    labelname.Text = da.GetValue(0).ToString();
                    comboBoxTitle.Text = da.GetValue(1).ToString();
                    textBoxQA.Text = da.GetValue(2).ToString();
                    textBoxQB.Text = da.GetValue(3).ToString();
                    textBoxQC.Text = da.GetValue(4).ToString();
                    textBoxQD.Text = da.GetValue(5).ToString();
                    textBoxQE.Text = da.GetValue(6).ToString();
                    textBoxQF.Text = da.GetValue(7).ToString();
                    textBoxQG.Text = da.GetValue(8).ToString();
                    textBoxQH.Text = da.GetValue(9).ToString();
                    textBoxQI.Text = da.GetValue(10).ToString();
                    textBoxQJ.Text = da.GetValue(11).ToString();
                    textBoxQK.Text = da.GetValue(12).ToString();


                }
                db.closeConnection();
            }


            }

        private void labelname_TextChanged(object sender, EventArgs e)
        {
            labelname.Text = labelname.Text.ToUpper();
        }
    }
}
