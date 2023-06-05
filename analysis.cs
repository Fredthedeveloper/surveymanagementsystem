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
using MySqlConnector;

namespace newsurvey
{
    public partial class analysis : Form
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

        public analysis()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


            panelNav.Height = btnA.Height;
            panelNav.Top = btnA.Top;
            panelNav.Left = btnA.Left;
            btnA.BackColor = Color.FromArgb(116, 86, 174);

           
        }

        private void analysis_Load(object sender, EventArgs e)
        {
            labelname.Text = frmLogin.recall;
            labelname.Text = labelname.Text.ToUpper();




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

        private void btnL_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f8 = new frmLogin();
            f8.ShowDialog();
            this.Close();
        }

        private void buttonCloseC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelname_Click(object sender, EventArgs e)
        {

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            this.Hide();
            analysis f13 = new analysis();
            f13.ShowDialog();
            this.Close();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= survey_app");

            db.openConnection();
            if (txtTitle.Text != "")
            {


                MySqlCommand command = new MySqlCommand("SELECT Title, COUNT(optionA) FROM consumer_ans WHERE optionA='yes'  AND Title= @Tit GROUP BY Title", db.getConnection());

                command.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));

                MySqlDataReader da = command.ExecuteReader();

                while (da.Read())
                {

                    txtTitle.Text = da.GetValue(0).ToString();
                    textBox1.Text = da.GetValue(1).ToString();




                }




                db.closeConnection();

            }


            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand comand = new MySqlCommand("SELECT Title, COUNT(optionA) FROM consumer_ans WHERE optionA='No'  AND Title= @Tit GROUP BY Title", db.getConnection());
                comand.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader dap = comand.ExecuteReader();
                while (dap.Read())
                {
                    txtTitle.Text = dap.GetValue(0).ToString();
                    textBox2.Text = dap.GetValue(1).ToString();


                }

            }
            db.closeConnection();


            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand mom = new MySqlCommand("SELECT Title, COUNT(optionA) FROM consumer_ans WHERE optionA='None'  AND Title= @Tit GROUP BY Title", db.getConnection());
                mom.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader hap = mom.ExecuteReader();
                while (hap.Read())
                {
                    txtTitle.Text = hap.GetValue(0).ToString();
                    textBox13.Text = hap.GetValue(1).ToString();


                }

            }
            db.closeConnection();





            db.openConnection();
            if (txtTitle.Text != "")
            {


                MySqlCommand commande = new MySqlCommand("SELECT Title, COUNT(optionB) FROM consumer_ans WHERE optionB='yes'  AND Title= @Tit GROUP BY Title", db.getConnection());

                commande.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));

                MySqlDataReader dat = commande.ExecuteReader();

                while (dat.Read())
                {

                    txtTitle.Text = dat.GetValue(0).ToString();
                    textBox3.Text = dat.GetValue(1).ToString();




                }




                db.closeConnection();

            }




            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand comande = new MySqlCommand("SELECT Title, COUNT(optionB) FROM consumer_ans WHERE optionB='No'  AND Title= @Tit GROUP BY Title", db.getConnection());
                comande.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader dapt = comande.ExecuteReader();
                while (dapt.Read())
                {
                    txtTitle.Text = dapt.GetValue(0).ToString();
                    textBox8.Text = dapt.GetValue(1).ToString();


                }

            }
            db.closeConnection();


            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand dad = new MySqlCommand("SELECT Title, COUNT(optionB) FROM consumer_ans WHERE optionB='None'  AND Title= @Tit GROUP BY Title", db.getConnection());
                dad.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader rad = dad.ExecuteReader();
                while (rad.Read())
                {
                    txtTitle.Text = rad.GetValue(0).ToString();
                    textBox12.Text = rad.GetValue(1).ToString();


                }

            }
            db.closeConnection();




            db.openConnection();
            if (txtTitle.Text != "")
            {


                MySqlCommand commander = new MySqlCommand("SELECT Title, COUNT(optionC) FROM consumer_ans WHERE optionC='yes'  AND Title= @Tit GROUP BY Title", db.getConnection());

                commander.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));

                MySqlDataReader dark = commander.ExecuteReader();

                while (dark.Read())
                {

                    txtTitle.Text = dark.GetValue(0).ToString();
                    textBox9.Text = dark.GetValue(1).ToString();




                }




                db.closeConnection();

            }



            db.openConnection();
            if (txtTitle.Text != "")
            {


                MySqlCommand commandant = new MySqlCommand("SELECT Title, COUNT(optionC) FROM consumer_ans WHERE optionC='No'  AND Title= @Tit GROUP BY Title", db.getConnection());

                commandant.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));

                MySqlDataReader darker = commandant.ExecuteReader();

                while (darker.Read())
                {

                    txtTitle.Text = darker.GetValue(0).ToString();
                    textBox10.Text = darker.GetValue(1).ToString();




                }




                db.closeConnection();

            }


            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand sis = new MySqlCommand("SELECT Title, COUNT(optionC) FROM consumer_ans WHERE optionC='None'  AND Title= @Tit GROUP BY Title", db.getConnection());
                sis.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader prd = sis.ExecuteReader();
                while (prd.Read())
                {
                    txtTitle.Text = prd.GetValue(0).ToString();
                    textBox11.Text = prd.GetValue(1).ToString();


                }

            }
            db.closeConnection();





            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand huawei = new MySqlCommand("SELECT Title, AVG(Q4) FROM consumer_ans WHERE Title = @Tit GROUP BY Title", db.getConnection());
                huawei.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader pho = huawei.ExecuteReader();
                while (pho.Read())
                {
                    txtTitle.Text = pho.GetValue(0).ToString();
                    textBox4.Text = pho.GetValue(1).ToString();


                }

            }
            db.closeConnection();




            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand Uk = new MySqlCommand("SELECT Title, AVG(Q5) FROM consumer_ans WHERE Title = @Tit GROUP BY Title", db.getConnection());
                Uk.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader red = Uk.ExecuteReader();
                while (red.Read())
                {
                    txtTitle.Text = red.GetValue(0).ToString();
                    textBox5.Text = red.GetValue(1).ToString();


                }

            }
            db.closeConnection();




            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand Ucas = new MySqlCommand("SELECT Title, AVG(Q6) FROM consumer_ans WHERE Title = @Tit GROUP BY Title", db.getConnection());
                Ucas.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader won = Ucas.ExecuteReader();
                while (won.Read())
                {
                    txtTitle.Text = won.GetValue(0).ToString();
                    textBox6.Text = won.GetValue(1).ToString();


                }

            }
            db.closeConnection();





            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand cassey = new MySqlCommand("SELECT Title, AVG(Q7) FROM consumer_ans WHERE Title = @Tit GROUP BY Title", db.getConnection());
                cassey.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader wins = cassey.ExecuteReader();
                while (wins.Read())
                {
                    txtTitle.Text = wins.GetValue(0).ToString();
                    textBox7.Text = wins.GetValue(1).ToString();


                }

            }
            db.closeConnection();





            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand card = new MySqlCommand("SELECT Title, AVG(Q8) FROM consumer_ans WHERE Title = @Tit GROUP BY Title", db.getConnection());
                card.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader whimp = card.ExecuteReader();
                while (whimp.Read())
                {
                    txtTitle.Text = whimp.GetValue(0).ToString();
                    textBox14.Text = whimp.GetValue(1).ToString();


                }

            }
            db.closeConnection();




            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand vsonet = new MySqlCommand("SELECT Title, AVG(Q9) FROM consumer_ans WHERE Title = @Tit GROUP BY Title", db.getConnection());
                vsonet.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader whipped = vsonet.ExecuteReader();
                while (whipped.Read())
                {
                    txtTitle.Text = whipped.GetValue(0).ToString();
                    textBox15.Text = whipped.GetValue(1).ToString();


                }

            }
            db.closeConnection();




            db.openConnection();
            if (txtTitle.Text != "")
            {
                MySqlCommand Toubietech = new MySqlCommand("SELECT Title, AVG(Q10) FROM consumer_ans WHERE Title = @Tit GROUP BY Title", db.getConnection());
                Toubietech.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader samsung = Toubietech.ExecuteReader();
                while (samsung.Read())
                {
                    txtTitle.Text = samsung.GetValue(0).ToString();
                    textBox16.Text = samsung.GetValue(1).ToString();


                }

            }
            db.closeConnection();






            db.openConnection();
            if (txtTitle.Text != "")
            {


                MySqlCommand Nikola = new MySqlCommand("SELECT `Title`, `QA`, `QB`, `QC`, `QD`, `QE`, `QF`, `QG`, `QH`, `QI`, `QJ`, `QK` FROM `admin_post` WHERE `Title`= @Tit", db.getConnection());
                Nikola.Parameters.AddWithValue("@Tit", Convert.ToString(txtTitle.Text));
                MySqlDataReader Tesla = Nikola.ExecuteReader();
                while (Tesla.Read())
                {

                    txtTitle.Text = Tesla.GetValue(0).ToString();
                    textBoxQA.Text = Tesla.GetValue(1).ToString();
                    textBoxQB.Text = Tesla.GetValue(2).ToString();
                    textBoxQC.Text = Tesla.GetValue(3).ToString();
                    textBoxQD.Text = Tesla.GetValue(4).ToString();
                    textBoxQE.Text = Tesla.GetValue(5).ToString();
                    textBoxQF.Text = Tesla.GetValue(6).ToString();
                    textBoxQG.Text = Tesla.GetValue(7).ToString();
                    textBoxQH.Text = Tesla.GetValue(8).ToString();
                    textBoxQI.Text = Tesla.GetValue(9).ToString();
                    textBoxQJ.Text = Tesla.GetValue(10).ToString();
                    textBoxQK.Text = Tesla.GetValue(11).ToString();


                }
                db.closeConnection();








            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxQK_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
