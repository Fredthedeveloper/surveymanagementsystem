using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newsurvey
{
    public partial class CreateSurvey : Form
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




        public CreateSurvey()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


            panelNav.Height = btnC.Height;
            panelNav.Top = btnC.Top;
            panelNav.Left = btnC.Left;
            btnC.BackColor = Color.FromArgb(116, 86, 174);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
           CreateSurvey f4 = new CreateSurvey();
            f4.ShowDialog();
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

        private void btnA_Layout(object sender, LayoutEventArgs e)
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

        private void CreateSurvey_Load(object sender, EventArgs e)
        {
            labelname.Text = frmLogin.recall;
            labelname.Text = labelname.Text.ToUpper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Db db = new Db();

            MySqlCommand command = new MySqlCommand("INSERT INTO `admin_post` ( `Name`, `Title`, `QA`, `QB`, `QC`, `QD`, `QE`, `QF`, `QG`, `QH`, `QI`, `QJ`, `QK`) VALUES( @Na, @Tit, @qna, @qnb, @qnc, @qnd, @qne, @qnf, @qng, @qnh, @qni, @qnj, @qnk)", db.getConnection());

            command.Parameters.Add("@Na", MySqlDbType.VarChar).Value = labelname.Text;
            command.Parameters.Add("@Tit", MySqlDbType.VarChar).Value = txtTitle.Text;
            command.Parameters.Add("@qna", MySqlDbType.VarChar).Value = textBoxQA.Text;
            command.Parameters.Add("@qnb", MySqlDbType.VarChar).Value = textBoxQB.Text;
            command.Parameters.Add("@qnc", MySqlDbType.VarChar).Value = textBoxQC.Text;
            command.Parameters.Add("@qnd", MySqlDbType.VarChar).Value = textBoxQD.Text;
            command.Parameters.Add("@qne", MySqlDbType.VarChar).Value = textBoxQE.Text;
            command.Parameters.Add("@qnf", MySqlDbType.VarChar).Value = textBoxQF.Text;
            command.Parameters.Add("@qng", MySqlDbType.VarChar).Value = textBoxQG.Text;
            command.Parameters.Add("@qnh", MySqlDbType.VarChar).Value = textBoxQH.Text;
            command.Parameters.Add("@qni", MySqlDbType.VarChar).Value = textBoxQI.Text;
            command.Parameters.Add("@qnj", MySqlDbType.VarChar).Value = textBoxQJ.Text;
            command.Parameters.Add("@qnk", MySqlDbType.VarChar).Value = textBoxQK.Text;


            db.openConnection();
            if (!checkTextBoxesValues())
            {

                if (checkText())
                {
                    MessageBox.Show("This Survey Title Already Exists, Create A Different One", "Duplicate SurveyTitle FOUND", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Your Survey has been posted", "Survey Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtTitle.Text = "";
                        textBoxQA.Text = "";
                        textBoxQB.Text = "";
                        textBoxQC.Text = "";
                        textBoxQD.Text = "";
                        textBoxQE.Text = "";
                        textBoxQF.Text = "";
                        textBoxQG.Text = "";
                        textBoxQH.Text = "";
                        textBoxQI.Text = "";
                        textBoxQJ.Text = "";
                        textBoxQK.Text = "";

                        this.Hide();
                        Surveydash f2 = new Surveydash();
                        f2.ShowDialog();
                        this.Close();




                    }
                    else
                    {
                        MessageBox.Show("ERROR! Try again");
                    }
                }

            }
            else
            {
                MessageBox.Show("Fill in all the textboxes with survey question please", "Empty Data Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }



            db.closeConnection();




        }

        public Boolean checkText()
        {

            Db db = new Db();
            String Title = txtTitle.Text;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `admin_post` WHERE `Title` = @Tit", db.getConnection());

            command.Parameters.Add("@Tit", MySqlDbType.String).Value = Title;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the id already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }




        }

        public Boolean checkTextBoxesValues()
        {

            String Tit =txtTitle.Text;
            String qa = textBoxQA.Text;
            String qb = textBoxQB.Text;
            String qc = textBoxQC.Text;
            String qd = textBoxQD.Text;
            String qe = textBoxQE.Text;
            String qf = textBoxQF.Text;
            String qg = textBoxQG.Text;
            String qh = textBoxQH.Text;
            String qi = textBoxQI.Text;
            String qj = textBoxQJ.Text;
            String qk = textBoxQK.Text;

            if (Tit.Equals("") || qa.Equals("") || qb.Equals("") || qc.Equals("") || qd.Equals("") || qe.Equals("") || qf.Equals("")
                || qg.Equals("") || qh.Equals("") || qi.Equals("")|| qj.Equals("")|| qk.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
