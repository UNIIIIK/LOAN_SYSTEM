
namespace OHAHA
{
    partial class frmCategoryUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date_val = new System.Windows.Forms.DateTimePicker();
            this.res_val = new System.Windows.Forms.TextBox();
            this.lname_val = new System.Windows.Forms.TextBox();
            this.fname_val = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 39);
            this.button1.TabIndex = 52;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "Birthday:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 50;
            this.label3.Text = "Residency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 48;
            this.label1.Text = "First Name:";
            // 
            // date_val
            // 
            this.date_val.Location = new System.Drawing.Point(135, 242);
            this.date_val.Name = "date_val";
            this.date_val.Size = new System.Drawing.Size(200, 20);
            this.date_val.TabIndex = 47;
            // 
            // res_val
            // 
            this.res_val.Location = new System.Drawing.Point(135, 174);
            this.res_val.Name = "res_val";
            this.res_val.Size = new System.Drawing.Size(147, 20);
            this.res_val.TabIndex = 46;
            // 
            // lname_val
            // 
            this.lname_val.Location = new System.Drawing.Point(135, 119);
            this.lname_val.Name = "lname_val";
            this.lname_val.Size = new System.Drawing.Size(147, 20);
            this.lname_val.TabIndex = 45;
            // 
            // fname_val
            // 
            this.fname_val.Location = new System.Drawing.Point(134, 57);
            this.fname_val.Name = "fname_val";
            this.fname_val.Size = new System.Drawing.Size(147, 20);
            this.fname_val.TabIndex = 44;
            // 
            // frmCategoryUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 407);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_val);
            this.Controls.Add(this.res_val);
            this.Controls.Add(this.lname_val);
            this.Controls.Add(this.fname_val);
            this.Name = "frmCategoryUpdate";
            this.Text = "frmCategoryUpdate";
            this.Load += new System.EventHandler(this.frmCategoryUpdate_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date_val;
        private System.Windows.Forms.TextBox res_val;
        private System.Windows.Forms.TextBox lname_val;
        private System.Windows.Forms.TextBox fname_val;
    }
}