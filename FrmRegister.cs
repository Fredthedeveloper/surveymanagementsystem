using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySqlConnector;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace newsurvey
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();

        }


       

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //Add a new Admin

            Db db = new Db();
            MySqlCommand command = new MySqlCommand("INSERT INTO`survey_admin` ( `username`, `password`) VALUES( @usn, @pass)", db.getConnection());


            
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txtpassword.Text;

            // open the connection so i can connect to my database
            db.openConnection();


            if (txtUsername.Text == "" || txtpassword.Text == "" || txtComPassword.Text == "")
            {
                MessageBox.Show("A field is empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);




            }

            else
            {
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
                      frmLogin f2 = new frmLogin();
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



        public Boolean checkUsername()
        {
            Db db = new Db();
            String username = txtUsername.Text;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `survey_admin` WHERE `Username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;


            adapter.SelectCommand = command;

            adapter.Fill(table);

            // To check if the Admin already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
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
            frmLogin F3 = new frmLogin();
            F3.ShowDialog();
            this.Close();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
    }
}
