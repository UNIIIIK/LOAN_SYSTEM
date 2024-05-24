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

    public partial class AddLoanForm : Form
    {
        private int _id;
        private double percentage;
        private MaltoEntities _context;
        private readonly BindingSource _bindingSource;

        public AddLoanForm(int id, BindingSource bindingsource) : this()
        {
            _id = id;
            _bindingSource = bindingsource;

        }
        public AddLoanForm()
        {
            InitializeComponent();
            _context = new MaltoEntities();
        }


        public string Status_Paid { get; set; }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddLoan_Load(object sender, EventArgs e)
        {

        }
        public class LoanEventArgs : EventArgs
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void noOfPaymentsTextBox_TextChanged(object sender, EventArgs e)
        {


        }

        private void interestTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void deductionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
       string.IsNullOrWhiteSpace(textBox2.Text) ||
       string.IsNullOrWhiteSpace(textBox3.Text) ||
       string.IsNullOrWhiteSpace(textBox4.Text) ||
       string.IsNullOrWhiteSpace(textBox10.Text) ||
       string.IsNullOrWhiteSpace(comboBox1.Text) ||
       string.IsNullOrWhiteSpace(textBox14.Text))
            {
                MessageBox.Show("Please fill up all required fields.");
                return; // Exit the method without proceeding further
            }

            Loan gwapo = new Loan();

            gwapo.ClientId = _id;
            gwapo.Due_Date = Convert.ToDateTime(textBox10.Text.Trim());

            int loanAmount;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Tiwasa og fill-up (Loan Amount)");
            }
            else if (int.TryParse(textBox1.Text.Trim(), out loanAmount))
            {
                gwapo.Loan_AMT = loanAmount;
            }
            else
            {
                // Handle invalid loan amount input
            }

            int interest;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Tiwasa og fill-up (Interest)");
            }
            else if (int.TryParse(textBox2.Text.Trim(), out interest))
            {
                percentage = double.Parse(textBox2.Text.Trim()) / 100;
                double increase = interest * percentage;
                int newInterest = (int)increase;
                gwapo.Interest = Convert.ToInt32(textBox2.Text.Trim());
            }
            else
            {

            }

            gwapo.Term = comboBox1.Text.Trim();
            gwapo.NoOf_Payment = textBox4.Text.Trim();

            int deduction;
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Tiwasa og fill-up (Deduction)");
            }
            else if (Int32.TryParse(textBox3.Text.Trim(), out deduction))
            {
                gwapo.Deduction = deduction;
                loanAmount = Convert.ToInt32(textBox1.Text.Trim());
                int newRcvAmt = loanAmount - deduction;
                gwapo.Receivable_AMT = newRcvAmt;
                textBox9.Text = newRcvAmt.ToString();
            }
            else
            {

            }

            int interested;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Tiwasa og fill-up (Interest)");
            }
            else if (int.TryParse(textBox1.Text.Trim(), out interested))
            {
                double increase1 = interested * percentage;
                gwapo.Interested_AMT = Convert.ToInt32(increase1);
            }
            else
            {

            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Tiwasa og fill-up (No. of Payments)");
            }
            else if (int.TryParse(textBox4.Text.Trim(), out int daysToAdd))
            {

            }
            else
            {

            }

            int payable;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Tiwasa og fill-up (Payable)");
            }
            else if (int.TryParse(textBox1.Text.Trim(), out payable))
            {
                double increase2 = payable * percentage;
                int newInterest2 = (int)(payable + increase2);
                textBox11.Text = newInterest2.ToString();
                gwapo.Total_Payable = newInterest2;
            }
            else
            {

            }

            gwapo.Status = textBox14.Text.Trim();

            _context.Loans.Add(gwapo);

            _context.SaveChanges();
            _bindingSource.DataSource = _context.Loans.Where(t => t.ClientId == _id).ToList();

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox1.Text.Trim();
            textBox6.Text = textBox2.Text + "%".Trim();

            textBox12.Text = comboBox1.Text.Trim();
            textBox13.Text = textBox4.Text.Trim();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox12.Text = comboBox1.Text.Trim();
            textBox6.Text = textBox2.Text + "%".Trim();

            decimal loan_amount = Convert.ToDecimal(textBox1.Text.Trim());
            decimal interest = Convert.ToDecimal(textBox2.Text.Trim());
            decimal interest_result = (interest / 100) * loan_amount;
            decimal total_payable = interest_result + loan_amount;
            textBox11.Text = Convert.ToString(total_payable);

            decimal deduction = Convert.ToDecimal(textBox3.Text.Trim());
            decimal deduction_result = loan_amount - deduction;
            textBox9.Text = Convert.ToString(deduction_result);
            textBox8.Text = Convert.ToString(interest_result);
            textBox12.Text = comboBox1.Text.Trim();
            textBox13.Text = textBox4.Text.Trim();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox2.Text + "%".Trim();

            decimal loan_amount = Convert.ToDecimal(textBox1.Text.Trim());
            decimal interest = Convert.ToDecimal(textBox2.Text.Trim());
            decimal interest_result = (interest / 100) * loan_amount;
            decimal total_payable = interest_result + loan_amount;
            textBox11.Text = Convert.ToString(total_payable);

            textBox8.Text = Convert.ToString(interest_result);
            textBox12.Text = comboBox1.Text.Trim();
            textBox13.Text = textBox4.Text.Trim();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox4.Text))
            {


                string term = comboBox1.Text.Trim();
                int payment = Convert.ToInt32(textBox4.Text.Trim());
                DateTime currentdate = DateTime.Now;

                if (term == "Daily")
                {
                    textBox10.Text = Convert.ToString(currentdate.AddDays(payment).ToString("MM/dd/yyyy"));
                }
                else if (term == "Weekly")
                {
                    textBox10.Text = Convert.ToString(currentdate.AddDays(payment * 7).ToString("MM/dd/yyyy"));
                }
                else if (term == "Monthly")
                {
                    textBox10.Text = Convert.ToString(currentdate.AddDays(payment * 31).ToString("MM/dd/yyyy"));
                }
                else if (term == "Bi-monthly")
                {
                    textBox10.Text = Convert.ToString(currentdate.AddDays((payment * 31) * 2).ToString("MM/dd/yyyy"));
                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox2.Text + "%".Trim();

            decimal loan_amount = Convert.ToDecimal(textBox1.Text.Trim());
            decimal interest = Convert.ToDecimal(textBox2.Text.Trim());
            decimal interest_result = (interest / 100) * loan_amount;
            decimal total_payable = interest_result + loan_amount;
            textBox11.Text = Convert.ToString(total_payable);

            decimal deduction = Convert.ToDecimal(textBox3.Text.Trim());
            decimal deduction_result = loan_amount - deduction;
            textBox9.Text = Convert.ToString(deduction_result);
            textBox8.Text = Convert.ToString(interest_result);
            textBox12.Text = comboBox1.Text.Trim();
            textBox13.Text = textBox4.Text.Trim();
            textBox7.Text = textBox3.Text.Trim();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox2.Text + "%".Trim();

            textBox10.Text = comboBox1.Text.Trim();

            if (!String.IsNullOrEmpty(textBox4.Text))
            {


                string term = comboBox1.Text.Trim();
                int payment = Convert.ToInt32(textBox4.Text.Trim());
                DateTime currentdate = DateTime.Now;

                if (term == "Daily")
                {
                    textBox13.Text = Convert.ToString(currentdate.AddDays(payment).ToString("MM/dd/yyyy"));
                }
                else if (term == "Weekly")
                {
                    textBox13.Text = Convert.ToString(currentdate.AddDays(payment * 7).ToString("MM/dd/yyyy"));
                }
                else if (term == "Monthly")
                {
                    textBox13.Text = Convert.ToString(currentdate.AddDays(payment * 31).ToString("MM/dd/yyyy"));
                }
                else if (term == "Bi-monthly")
                {
                    textBox13.Text = Convert.ToString(currentdate.AddDays((payment * 31) * 2).ToString("MM/dd/yyyy"));
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
    }
 }
    

