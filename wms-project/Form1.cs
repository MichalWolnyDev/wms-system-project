using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wms_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Users[] users = new Users[2];
             users[0] = new Users();
             users[1] = new Users();
             users[0].setUsers("Admin", "qwerty", true);
             users[1].setUsers("Magazynier", "magazyn1", false);

             if ((UsernameInput.Text == users[0].uname && PasswordInput.Text == users[0].upassword) || (UsernameInput.Text == users[1].uname && PasswordInput.Text == users[1].upassword))
             {
                 new Form2().Show();
                 this.Hide();
             }
             else
             {
                 MessageBox.Show("Niepoprawne dane logowania");
                 UsernameInput.Clear();
                 PasswordInput.Clear();
                 UsernameInput.Focus();
             }
             */
            Users users = new Users();

            users.readUsers();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPwd.Checked == false)
            {
                PasswordInput.PasswordChar = '*';
            } else
            {
                PasswordInput.PasswordChar = '\0';
            }
        }

        private void ClearInputs_Click(object sender, EventArgs e)
        {
            UsernameInput.Text = "";
            PasswordInput.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
