namespace MaximaxCare
{
    partial class Patient
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sfButton7 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton6 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton5 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton4 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.sfButton3 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton2 = new Syncfusion.WinForms.Controls.SfButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(569, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pt_Ref_No";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(634, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.sfButton7);
            this.panel3.Controls.Add(this.sfButton6);
            this.panel3.Controls.Add(this.sfButton5);
            this.panel3.Controls.Add(this.sfButton4);
            this.panel3.Controls.Add(this.sfButton1);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(20, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(957, 30);
            this.panel3.TabIndex = 10;
            // 
            // sfButton7
            // 
            this.sfButton7.AccessibleName = "Button";
            this.sfButton7.BackColor = System.Drawing.Color.Gold;
            this.sfButton7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton7.Location = new System.Drawing.Point(207, 3);
            this.sfButton7.Name = "sfButton7";
            this.sfButton7.Size = new System.Drawing.Size(96, 20);
            this.sfButton7.Style.BackColor = System.Drawing.Color.Gold;
            this.sfButton7.TabIndex = 20;
            this.sfButton7.Text = "AddTest";
            this.sfButton7.UseVisualStyleBackColor = false;
            this.sfButton7.Click += new System.EventHandler(this.sfButton7_Click);
            // 
            // sfButton6
            // 
            this.sfButton6.AccessibleName = "Button";
            this.sfButton6.BackColor = System.Drawing.Color.Gold;
            this.sfButton6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton6.Location = new System.Drawing.Point(3, 3);
            this.sfButton6.Name = "sfButton6";
            this.sfButton6.Size = new System.Drawing.Size(96, 20);
            this.sfButton6.Style.BackColor = System.Drawing.Color.Gold;
            this.sfButton6.TabIndex = 19;
            this.sfButton6.Text = "Patient Types";
            this.sfButton6.UseVisualStyleBackColor = false;
            this.sfButton6.Click += new System.EventHandler(this.sfButton6_Click);
            // 
            // sfButton5
            // 
            this.sfButton5.AccessibleName = "Button";
            this.sfButton5.BackColor = System.Drawing.Color.Gold;
            this.sfButton5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton5.Location = new System.Drawing.Point(309, 3);
            this.sfButton5.Name = "sfButton5";
            this.sfButton5.Size = new System.Drawing.Size(96, 20);
            this.sfButton5.Style.BackColor = System.Drawing.Color.Gold;
            this.sfButton5.TabIndex = 18;
            this.sfButton5.Text = "Reports";
            this.sfButton5.UseVisualStyleBackColor = false;
            this.sfButton5.Click += new System.EventHandler(this.sfButton5_Click);
            // 
            // sfButton4
            // 
            this.sfButton4.AccessibleName = "Button";
            this.sfButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(125)))), ((int)(((byte)(80)))));
            this.sfButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton4.Location = new System.Drawing.Point(411, 3);
            this.sfButton4.Name = "sfButton4";
            this.sfButton4.Size = new System.Drawing.Size(96, 20);
            this.sfButton4.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(125)))), ((int)(((byte)(80)))));
            this.sfButton4.TabIndex = 17;
            this.sfButton4.Text = "Backup";
            this.sfButton4.UseVisualStyleBackColor = false;
            this.sfButton4.Click += new System.EventHandler(this.sfButton4_Click);
            // 
            // sfButton1
            // 
            this.sfButton1.AccessibleName = "Button";
            this.sfButton1.BackColor = System.Drawing.Color.Gold;
            this.sfButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton1.Location = new System.Drawing.Point(105, 3);
            this.sfButton1.Name = "sfButton1";
            this.sfButton1.Size = new System.Drawing.Size(96, 20);
            this.sfButton1.Style.BackColor = System.Drawing.Color.Gold;
            this.sfButton1.TabIndex = 16;
            this.sfButton1.Text = "AddPatients";
            this.sfButton1.UseVisualStyleBackColor = false;
            this.sfButton1.Click += new System.EventHandler(this.sfButton1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(513, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(148, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // sfButton3
            // 
            this.sfButton3.AccessibleName = "Button";
            this.sfButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(125)))), ((int)(((byte)(80)))));
            this.sfButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton3.Location = new System.Drawing.Point(851, 11);
            this.sfButton3.Name = "sfButton3";
            this.sfButton3.Size = new System.Drawing.Size(96, 20);
            this.sfButton3.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(125)))), ((int)(((byte)(80)))));
            this.sfButton3.TabIndex = 13;
            this.sfButton3.Text = "Refresh";
            this.sfButton3.UseVisualStyleBackColor = false;
            this.sfButton3.Click += new System.EventHandler(this.sfButton3_Click);
            // 
            // sfButton2
            // 
            this.sfButton2.AccessibleName = "Button";
            this.sfButton2.BackColor = System.Drawing.Color.Gold;
            this.sfButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton2.Location = new System.Drawing.Point(752, 12);
            this.sfButton2.Name = "sfButton2";
            this.sfButton2.Size = new System.Drawing.Size(96, 20);
            this.sfButton2.Style.BackColor = System.Drawing.Color.Gold;
            this.sfButton2.TabIndex = 14;
            this.sfButton2.Text = "Show All Patients";
            this.sfButton2.UseVisualStyleBackColor = false;
            this.sfButton2.Click += new System.EventHandler(this.sfButton2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.Location = new System.Drawing.Point(20, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(957, 546);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 656);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sfButton3);
            this.Controls.Add(this.sfButton2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Patient";
            this.Text = "Patient";
            this.Load += new System.EventHandler(this.Patient_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Syncfusion.WinForms.Controls.SfButton sfButton3;
        private Syncfusion.WinForms.Controls.SfButton sfButton2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
        private Syncfusion.WinForms.Controls.SfButton sfButton5;
        private Syncfusion.WinForms.Controls.SfButton sfButton4;
        private Syncfusion.WinForms.Controls.SfButton sfButton6;
        private Syncfusion.WinForms.Controls.SfButton sfButton7;
    }
}