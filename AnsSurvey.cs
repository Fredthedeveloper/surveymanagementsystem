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
    public partial class AnsSurvey : Form
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

        public AnsSurvey()
        {
            InitializeComponent();
            FillCombo();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = btnA.Height;
            panelNav.Top = btnA.Top;
            panelNav.Left = btnA.Left;
            btnA.BackColor = Color.FromArgb(116, 86, 174);
        }
        
        int numbers;
        int numbersa;
        int numbersb;
        void FillCombo()
        {
            Db db = new Db();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=survey_app");

            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `admin_post`", db.getConnection());

            MySqlDataReader myReader;
            try
            {
                db.openConnection();
                myReader = command.ExecuteReader();


                while (myReader.Read())
                {
                    String Tname = myReader.GetString("Title");
                    comboBoxTitle.Items.Add(Tname);


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }




        private void buttonCloseC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnsSurvey_Load(object sender, EventArgs e)
        {
            labelname.Text = FrmLoginCust.recall;
            labelname.Text = labelname.Text.ToUpper();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            surveyDashCust f2 = new  surveyDashCust ();
            f2.ShowDialog();
            this.Close();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            this.Hide();
           AnsSurvey f5 = new  AnsSurvey ();
            f5.ShowDialog();
            this.Close();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoginCust f8 = new FrmLoginCust();
            f8.ShowDialog();
            this.Close();
        }

        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= survey_app");

            db.openConnection();
            if (comboBoxTitle.Text != "")
            {


                MySqlCommand command = new MySqlCommand("SELECT `Name`, `Title`, `QA`, `QB`, `QC`, `QD`, `QE`, `QF`, `QG`, `QH`, `QI`, `QJ`, `QK` FROM `admin_post` WHERE `Title`= @Tit", db.getConnection());
                command.Parameters.AddWithValue("@Tit", Convert.ToString(comboBoxTitle.Text));
                MySqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    labelna.Text = da.GetValue(0).ToString();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }


        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            numbers=  0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numbers = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numbers = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numbers = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numbers = 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numbers = 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numbers = 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numbers = 7;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numbers = 8;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            numbers = 9;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            numbers = 10;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            numbersa = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            numbersa= 1;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            numbersa = 2;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            numbersa = 3;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            numbersa = 4;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            numbersa = 5;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            numbersa = 6;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            numbersa = 7;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            numbersa = 8;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            numbersa = 9;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            numbersa = 10;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            numbersb = 0;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            numbersb = 1;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            numbersb = 2;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            numbersb = 3;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            numbersb = 4;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            numbersb = 5;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            numbersb = 6;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            numbersb = 7;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            numbersb = 8;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            numbersb = 9;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            numbersb = 10;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Db db = new Db();

            MySqlCommand command = new MySqlCommand("INSERT INTO `consumer_ans` ( `Name`,`Title`, `optionA`, `optionB`, `optionC`, `Q4`, `Q5`, `Q6`, `Q7`, `Q8`, `Q9`, `Q10`) VALUES( @Na, @Tit, @qa, @qb, @qc, @qd, @qe, @qf, @qg, @qh, @qi, @qj)", db.getConnection());

            string mike = "";

            if (radioButton1.Checked)
            {
               mike = "yes";
            }
            else if (radioButton2.Checked)
            {
                mike = "No";
            }
            else
            {
                mike = "None";
            }

            string alfred = "";
            if (radioButton4.Checked)
            {
                alfred = "yes";
            }
            else if (radioButton3.Checked)
            {
                alfred = "No";
            }
            else
            {
                alfred = "None";
            }


            string NCC = "";
            if (radioButton5.Checked)
            {
                NCC = "yes";
            }
            else if (radioButton6.Checked)
            {
                NCC = "No";
            }
            else
            {
                NCC = "None";
            }






            command.Parameters.Add("@Na", MySqlDbType.VarChar).Value = labelna.Text;
            command.Parameters.Add("@Tit", MySqlDbType.VarChar).Value = comboBoxTitle.Text;
            command.Parameters.Add("@qa", MySqlDbType.VarChar).Value = mike;
            
            command.Parameters.Add("@qb", MySqlDbType.VarChar).Value = alfred;
           
            command.Parameters.Add("@qc", MySqlDbType.VarChar).Value = NCC;
            
          //0
            command.Parameters.Add("@qd", MySqlDbType.Int16).Value = numbers;

            // 10

            //0
            command.Parameters.Add("@qe", MySqlDbType.Int16).Value = numbersa;
           
          

          
            command.Parameters.Add("@qf", MySqlDbType.Int16).Value = numbersb;
            
         




            command.Parameters.Add("@qg", MySqlDbType.Int16).Value = numericUpDown1.Text;
            command.Parameters.Add("@qh", MySqlDbType.Int16).Value = numericUpDown4.Text;
            command.Parameters.Add("@qi", MySqlDbType.Int16).Value = numericUpDown3.Text;
            command.Parameters.Add("@qj", MySqlDbType.Int16).Value = numericUpDown2.Text;



            db.openConnection();

            if (!checkTextBoxesValues())
            {


                if (checkText())
                {
                    MessageBox.Show("your answers has been sent already", "Duplicate Survey Answers FOUND", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Thank you for answering the survey", "Survey Answered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        comboBoxTitle.Text = "";
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        numbers = 0;
                        numbersa = 0;
                        numbersb = 0;
                        numericUpDown1.Value = 0;
                        numericUpDown2.Value = 0;
                        numericUpDown3.Value = 0;
                        numericUpDown4.Value = 0;

                        this.Hide();
                        surveyDashCust f2 = new surveyDashCust();
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
                MessageBox.Show("Answer all the survey question please", "Empty Data Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }


            db.closeConnection();
        }

        public Boolean checkTextBoxesValues()
        {

            String Tit = comboBoxTitle.Text;
            
            int qd = numbers;
            int qe = numbersa;
            int qf = numbersb;
            String qg = numericUpDown1.Text;
            String qh = numericUpDown4.Text;
            String qi = numericUpDown3.Text;
            String qj = numericUpDown2.Text;

            if (Tit.Equals("") || qd.Equals("0") || qe.Equals("0") || qf.Equals("0")
                || qg.Equals("0") || qh.Equals("0") || qi.Equals("0") || qj.Equals("0") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkText()
        {

            Db db = new Db();
            String Title = comboBoxTitle.Text;
            int questd = numbers;
            int queste = numbersa;
            int questf = numbersb;
            String questg = numericUpDown1.Text;
            String questh = numericUpDown4.Text;
            String questi = numericUpDown3.Text;
            String questj = numericUpDown2.Text;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `consumer_ans` WHERE `Title` = @Tit  AND `Q4` = @qd AND `Q5` = @qe AND `Q6` = @qf AND `Q7` = @qg AND `Q8` = @qh AND `Q9` = @qi AND `Q10` = @qj ", db.getConnection());

            command.Parameters.Add("@Tit", MySqlDbType.String).Value = Title;
            command.Parameters.Add("@qd", MySqlDbType.Int16).Value = questd;
            command.Parameters.Add("@qe", MySqlDbType.Int16).Value = queste;
            command.Parameters.Add("@qf", MySqlDbType.Int16).Value = questf;
            command.Parameters.Add("@qg", MySqlDbType.Int16).Value = questg;
            command.Parameters.Add("@qh", MySqlDbType.Int16).Value = questh;
            command.Parameters.Add("@qi", MySqlDbType.Int16).Value = questi;
            command.Parameters.Add("@qj", MySqlDbType.Int16).Value = questj;


            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the data already exists in the database 
            if (table.Rows.Count > 0)
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
