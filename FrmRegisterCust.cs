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
    public partial class FrmRegisterCust : Form
    {
        public FrmRegisterCust()
        {
            InitializeComponent();
        }

        private void FrmRegisterCust_Load(object sender, EventArgs e)
        {
            
        }


        public Boolean checkUsername()
        {
            Db db = new Db();
            String username = txtUsername.Text;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `survey_consumer` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;


            adapter.SelectCommand = command;

            adapter.Fill(table);

            // To check if the Admin username already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
          
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Add a new Admin

            Db db = new Db();
            MySqlCommand command = new MySqlCommand("INSERT INTO`survey_consumer` ( `username`, `password`) VALUES( @usn, @pass)", db.getConnection());



            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txtpassword.Text;

            // open the connection so i can connect to my database
            db.openConnection();


            if (txtUsername.Text == "" || txtpassword.Text == "" || txtComPassword.Text == "")
            {
                MessageBox.Show("A field is empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else { 

            if (checkUsername())
            {
                MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtUsername.Text = "";
            }

            else if (txtpassword.Text == txtComPassword.Text)
            {

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Your account has been created Successfully!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        FrmLoginCust f2 = new FrmLoginCust();
                        f2.ShowDialog();
                        this.Close();

                    }
                else
                {
                    MessageBox.Show("ERROR");
                }


                txtUsername.Text = "";
                txtpassword.Text = "";
                txtComPassword.Text = "";






            }
            else
            {
                MessageBox.Show("Passwords does not match, Please Re-type your password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtComPassword.Text = "";
                txtpassword.Focus();


            }
            db.closeConnection();
        }


        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';

            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoginCust F3 = new FrmLoginCust();
            F3.ShowDialog();
            this.Close();
        }

        private void buttonCloseC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main F9 = new Main();
            F9.ShowDialog();
            this.Close();
        }
    }   }
