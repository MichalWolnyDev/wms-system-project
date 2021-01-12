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
            this.Controls.Add(dataGridView1);
            InitializeComponent();
            InitializeDataGridView();


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
            if (!string.IsNullOrWhiteSpace(ItemName.Text) && !string.IsNullOrWhiteSpace(itemPrice.Text) && !string.IsNullOrWhiteSpace(itemDescription.Text))
            {
                datamnp.addData(ItemName.Text, itemPrice.Text, itemDescription.Text);
                // refresh dataGrid after adding some item
                InitializeDataGridView();
                MessageBox.Show("Dodano przedmiot");
            }
            else
            {
                MessageBox.Show("Uzupełnij pola");
            }
         
        
        }

        private void InitializeDataGridView()
        {
            try
            {
                var result = datamnp.displayData();
                // Automatically generate the DataGridView columns.
                dataGridView1.AutoGenerateColumns = true;

                // Set up the data source.
                dataGridView1.DataSource = result;

                // Automatically resize the visible rows.
                dataGridView1.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Put the cells in edit mode when user enters them.
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania danych");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}
