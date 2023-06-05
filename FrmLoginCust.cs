using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace newsurvey
{
    public partial class FrmLoginCust : Form
    {
        int attempt = 1;

        public FrmLoginCust()
        {
            InitializeComponent();
        }

        private void FrmLoginCust_Load(object sender, EventArgs e)
        {

        }
        public static string username;
        public static string recall
        {
            get { return username; }
            set { username = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (attempt < 4)
            {
                Db db = new Db();

                recall = txtUsername.Text;

                db.openConnection();

                String username = txtUsername.Text;
                String password = txtpassword.Text;

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `survey_consumer` WHERE `Username` = @usn and `Password` = @pass", db.getConnection());

                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

                adapter.SelectCommand = command;

                adapter.Fill(table);
                MySqlDataReader dr = command.ExecuteReader();


                if (dr.Read() == true)
                {
                    this.Hide();
                    surveyDashCust F5 = new surveyDashCust();
                    F5.ShowDialog();
                    this.Close();
                }

                else
                {

                    MessageBox.Show("Invalid Username or Password!,No of login attempt is " + attempt, "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtpassword.Text = "";
                    txtUsername.Focus();

                }


                // check if the username field is empty
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // check if the password field is empty
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (attempt == 4)
            {
                MessageBox.Show("login attempt exceeded");
                txtUsername.Enabled = false;
                txtpassword.Enabled = false;
                this.Close();
            }
            attempt++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';


            }
            else
            {
                txtpassword.PasswordChar = '*';

            }
        }

        private void buttonCloseC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegisterCust F3 =new FrmRegisterCust();
            F3.ShowDialog();
            this.Close();
        }
    }
}
