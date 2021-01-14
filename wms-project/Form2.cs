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
            if (label4.Visible == false) label4.Visible = true;
            if (ItemName.Visible == false) ItemName.Visible = true;
            if (label5.Visible == false) label5.Visible = true;
            if (itemPrice.Visible == false) itemPrice.Visible = true;
            if (label6.Visible == false) label6.Visible = true;
            if (itemDescription.Visible == false) itemDescription.Visible = true;
            numericUpDown1.Visible = false;
            label1.Visible = false;
            button4.Visible = false;

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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("nienawidze zycia");
            //do your checks to see RowIndex is not -1 and other good stuffs
            //var row = dataGridView1.Rows[e.RowIndex];
           //// var changedValue = (string)row.Cells[e.ColumnIndex].Value;
            //dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
           // Console.WriteLine(changedValue);

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
            this.dataGridView1.EndEdit();
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            label1.Visible = false;
            button4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            ItemName.Visible = false;
            ItemName.Text = "";
            label5.Visible = false;
            itemPrice.Visible = false;
            itemPrice.Text = "";
            label6.Visible = false;
            itemDescription.Visible = false;
            itemDescription.Text = "";
            numericUpDown1.Visible = true;
            label1.Visible = true;
            button4.Visible = true;

          
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != null)
            {
                int count = Convert.ToInt32(numericUpDown1.Value);
                Console.WriteLine(count);
                datamnp.removeData(count);
                InitializeDataGridView();
                MessageBox.Show("Przedmiot usunięty");
            }
        }

   
    }
}
