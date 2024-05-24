using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OHAHA.Entites;


namespace OHAHA
{
    public partial class ClientForm : Form
    {
        private DatabaseOperation operation;
        private AddClient db;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            operation = new DatabaseOperation(cLIENTBindingSource);
            cLIENTBindingSource.DataSource = operation._con.CLIENTs.ToList();
        }
        private int getSelectedId;
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do you want to delete the client ID {getSelectedId}", "Delete Confirmation",
                MessageBoxButtons.YesNo);
            
            if (result == DialogResult.Yes)
            {
                operation.deleteClients(getSelectedId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operation.addClient();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            operation.searchClient(searchTextbox.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            operation.updateClient(getSelectedId);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            getSelectedId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoanForm openLoan = new LoanForm (getSelectedId, cLIENTBindingSource);
            openLoan.ShowDialog();


        }
        private int getSelectedCol;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                getSelectedCol = e.ColumnIndex;
            }
        }
    }
}
