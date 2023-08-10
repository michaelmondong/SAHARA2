namespace SAHARA2
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.btnLogout = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpKontrol = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObat = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeluhan = new System.Windows.Forms.TextBox();
            this.txtAsrama = new System.Windows.Forms.TextBox();
            this.txtKelas = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewDataSakit = new System.Windows.Forms.ListView();
            this.nomor = new System.Windows.Forms.ColumnHeader();
            this.nama = new System.Windows.Forms.ColumnHeader();
            this.kelas = new System.Windows.Forms.ColumnHeader();
            this.asrama = new System.Windows.Forms.ColumnHeader();
            this.keluhan = new System.Windows.Forms.ColumnHeader();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.rbEdit = new System.Windows.Forms.RadioButton();
            this.rbPrint = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLogout.Location = new System.Drawing.Point(637, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(126, 43);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "L O G O U T";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpKontrol);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtObat);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKeluhan);
            this.groupBox1.Controls.Add(this.txtAsrama);
            this.groupBox1.Controls.Add(this.txtKelas);
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Location = new System.Drawing.Point(34, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 444);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.Location = new System.Drawing.Point(123, 379);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 45);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "D E L E T E";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrint.Location = new System.Drawing.Point(469, 379);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 45);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "P R I N T";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(29, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Kontrol";
            // 
            // dtpKontrol
            // 
            this.dtpKontrol.Location = new System.Drawing.Point(123, 324);
            this.dtpKontrol.Name = "dtpKontrol";
            this.dtpKontrol.Size = new System.Drawing.Size(250, 27);
            this.dtpKontrol.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(29, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Obat";
            // 
            // txtObat
            // 
            this.txtObat.Location = new System.Drawing.Point(123, 275);
            this.txtObat.Name = "txtObat";
            this.txtObat.Size = new System.Drawing.Size(559, 27);
            this.txtObat.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.Location = new System.Drawing.Point(299, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 45);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "S A V E";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Castellar", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(234, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(337, 57);
            this.label7.TabIndex = 6;
            this.label7.Text = "S A H A R A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Copperplate Gothic Bold", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(209, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(379, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Sanapati Health Report Application";
            // 
            // listViewDataSakit
            // 
            this.listViewDataSakit.AllowColumnReorder = true;
            this.listViewDataSakit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nomor,
            this.nama,
            this.kelas,
            this.asrama,
            this.keluhan});
            this.listViewDataSakit.FullRowSelect = true;
            this.listViewDataSakit.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDataSakit.HideSelection = true;
            this.listViewDataSakit.Location = new System.Drawing.Point(34, 104);
            this.listViewDataSakit.MultiSelect = false;
            this.listViewDataSakit.Name = "listViewDataSakit";
            this.listViewDataSakit.Size = new System.Drawing.Size(729, 225);
            this.listViewDataSakit.TabIndex = 8;
            this.listViewDataSakit.UseCompatibleStateImageBehavior = false;
            this.listViewDataSakit.View = System.Windows.Forms.View.Details;
            this.listViewDataSakit.SelectedIndexChanged += new System.EventHandler(this.listViewDataSakit_SelectedIndexChanged);
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
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(106, 366);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(63, 24);
            this.rbNone.TabIndex = 16;
            this.rbNone.Text = "none";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(251, 366);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(115, 24);
            this.rbDelete.TabIndex = 17;
            this.rbDelete.Text = "delete mode";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.CheckedChanged += new System.EventHandler(this.rbDelete_CheckedChanged);
            // 
            // rbEdit
            // 
            this.rbEdit.AutoSize = true;
            this.rbEdit.Location = new System.Drawing.Point(429, 366);
            this.rbEdit.Name = "rbEdit";
            this.rbEdit.Size = new System.Drawing.Size(99, 24);
            this.rbEdit.TabIndex = 18;
            this.rbEdit.Text = "edit mode";
            this.rbEdit.UseVisualStyleBackColor = true;
            this.rbEdit.CheckedChanged += new System.EventHandler(this.rbEdit_CheckedChanged);
            // 
            // rbPrint
            // 
            this.rbPrint.AutoSize = true;
            this.rbPrint.Location = new System.Drawing.Point(599, 366);
            this.rbPrint.Name = "rbPrint";
            this.rbPrint.Size = new System.Drawing.Size(104, 24);
            this.rbPrint.TabIndex = 19;
            this.rbPrint.Text = "print mode";
            this.rbPrint.UseVisualStyleBackColor = true;
            this.rbPrint.CheckedChanged += new System.EventHandler(this.rbPrint_CheckedChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 892);
            this.Controls.Add(this.rbPrint);
            this.Controls.Add(this.rbEdit);
            this.Controls.Add(this.rbDelete);
            this.Controls.Add(this.rbNone);
            this.Controls.Add(this.listViewDataSakit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S A H A R A";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLogout;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnPrint;
        private Label label6;
        private DateTimePicker dtpKontrol;
        private Label label5;
        private TextBox txtObat;
        private Button btnSave;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtKeluhan;
        private TextBox txtAsrama;
        private TextBox txtKelas;
        private TextBox txtNama;
        private Label label7;
        private Label label8;
        private ColumnHeader kelas;
        private ColumnHeader asrama;
        private ColumnHeader keluhan;
        private ColumnHeader obat;
        private ColumnHeader kontrol;
        internal ListView listViewDataSakit;
        private ColumnHeader nama;
        private ColumnHeader nomor;
        private RadioButton rbNone;
        private RadioButton rbDelete;
        private RadioButton rbEdit;
        private RadioButton rbPrint;
    }
}