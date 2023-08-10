namespace SAHARA2
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeluhan = new System.Windows.Forms.TextBox();
            this.txtAsrama = new System.Windows.Forms.TextBox();
            this.txtKelas = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewDataSakit = new System.Windows.Forms.ListView();
            this.nomor = new System.Windows.Forms.ColumnHeader();
            this.nama = new System.Windows.Forms.ColumnHeader();
            this.kelas = new System.Windows.Forms.ColumnHeader();
            this.asrama = new System.Windows.Forms.ColumnHeader();
            this.keluhan = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKeluhan);
            this.groupBox1.Controls.Add(this.txtAsrama);
            this.groupBox1.Controls.Add(this.txtKelas);
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Location = new System.Drawing.Point(34, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 347);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSubmit.Location = new System.Drawing.Point(296, 283);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(129, 45);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "S U B M I T";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(29, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Keluhan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(29, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Asrama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(29, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kelas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama";
            // 
            // txtKeluhan
            // 
            this.txtKeluhan.Location = new System.Drawing.Point(123, 195);
            this.txtKeluhan.Multiline = true;
            this.txtKeluhan.Name = "txtKeluhan";
            this.txtKeluhan.Size = new System.Drawing.Size(559, 56);
            this.txtKeluhan.TabIndex = 3;
            // 
            // txtAsrama
            // 
            this.txtAsrama.Location = new System.Drawing.Point(123, 141);
            this.txtAsrama.Name = "txtAsrama";
            this.txtAsrama.Size = new System.Drawing.Size(559, 27);
            this.txtAsrama.TabIndex = 2;
            // 
            // txtKelas
            // 
            this.txtKelas.Location = new System.Drawing.Point(123, 89);
            this.txtKelas.Name = "txtKelas";
            this.txtKelas.Size = new System.Drawing.Size(559, 27);
            this.txtKelas.TabIndex = 1;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(123, 37);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(559, 27);
            this.txtNama.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLogout.Location = new System.Drawing.Point(637, 23);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(126, 43);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "L O G O U T";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Castellar", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(229, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(337, 57);
            this.label7.TabIndex = 8;
            this.label7.Text = "S A H A R A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Copperplate Gothic Bold", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(203, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(379, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sanapati Health Report Application";
            // 
            // listViewDataSakit
            // 
            this.listViewDataSakit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nomor,
            this.nama,
            this.kelas,
            this.asrama,
            this.keluhan});
            this.listViewDataSakit.FullRowSelect = true;
            this.listViewDataSakit.HideSelection = true;
            this.listViewDataSakit.Location = new System.Drawing.Point(34, 112);
            this.listViewDataSakit.MultiSelect = false;
            this.listViewDataSakit.Name = "listViewDataSakit";
            this.listViewDataSakit.Size = new System.Drawing.Size(729, 225);
            this.listViewDataSakit.TabIndex = 10;
            this.listViewDataSakit.UseCompatibleStateImageBehavior = false;
            this.listViewDataSakit.View = System.Windows.Forms.View.Details;
            // 
            // nomor
            // 
            this.nomor.Text = "No.";
            // 
            // nama
            // 
            this.nama.Text = "Nama";
            // 
            // kelas
            // 
            this.kelas.Text = "Kelas";
            // 
            // asrama
            // 
            this.asrama.Text = "Asrama";
            // 
            // keluhan
            // 
            this.keluhan.Text = "Keluhan";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 726);
            this.Controls.Add(this.listViewDataSakit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S A H A R A";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox groupBox1;
        private Button btnSubmit;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtKeluhan;
        private TextBox txtAsrama;
        private TextBox txtKelas;
        private TextBox txtNama;
        private Button btnLogout;
        private Label label7;
        private Label label8;
        internal ListView listViewDataSakit;
        private ColumnHeader nomor;
        private ColumnHeader nama;
        private ColumnHeader kelas;
        private ColumnHeader asrama;
        private ColumnHeader keluhan;
    }
}