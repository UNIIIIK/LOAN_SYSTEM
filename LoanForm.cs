using OHAHA.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OHAHA
{
    public partial class LoanForm : Form
    {
        private MaltoEntities _context;
        private readonly BindingSource _bindingSource;
        private int _id;
        private int getSelectedId;
        private int oten;

        public LoanForm(int id, BindingSource bindingSource) : this()
        {
            _bindingSource = bindingSource;
            _id = id;
        }
        public LoanForm()
        {
            InitializeComponent();
            _context = new MaltoEntities();
        }

        private void InitializeDataGridView()
        {
            
        }

        private void LoanForm_Load(object sender, EventArgs e)
        {
            MaltoEntities _context = new MaltoEntities();

            getSelectedId = _id;


            var resulta = _context.Loans.Where(t => t.ClientId == getSelectedId).ToList();

            loanBindingSource.DataSource = resulta;


            var info = _context.CLIENTs.Where(q => q.Id == _id).FirstOrDefault();
            label1.Text = info.FirstName + " " + info.Lastname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddLoanForm frm = new AddLoanForm(_id, loanBindingSource);
            frm.ShowDialog();
        }
        private void AddLoanForm_LoanAdded(object sender, AddLoanForm.LoanEventArgs e)
        {
          
        }
        private void LoadLoans()
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var paid = _context.Loans.FirstOrDefault(q => q.LoanID == oten);

            if (paid != null)
            {
                if (paid.Status == "Paid")
                {
                    paid.Status = "Unpaid";
                }
                else
                {
                    paid.Status = "Paid";
                }

                _context.SaveChanges();
                loanBindingSource.DataSource = _context.Loans.Where(q => q.ClientId == _id).ToList();
            }
            else
            {

                MessageBox.Show("Record not found for the specified ID.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            getSelectedId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            oten = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }
    }
}
