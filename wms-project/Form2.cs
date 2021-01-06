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
    public partial class Form2 : Form
    {
        Form2 DataManipulation;
        DataManipulation datamnp = new DataManipulation();
        public Form2()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ItemName.Text))
            {
                datamnp.addData(ItemName.Text);
                MessageBox.Show("Dodano przedmiot");
            }
            else
            {
                MessageBox.Show("Uzupełnij pola");
            }
         
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
