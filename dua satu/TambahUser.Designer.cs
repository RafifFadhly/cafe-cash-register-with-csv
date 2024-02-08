namespace kasir
{
    partial class TambahUser
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
            this.dataUser = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username_txt = new System.Windows.Forms.TextBox();
            this.Passeord_txt = new System.Windows.Forms.TextBox();
            this.Status_txt = new System.Windows.Forms.ComboBox();
            this.tambah = new System.Windows.Forms.Button();
            this.hapus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dataUser
            // 
            this.dataUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Username,
            this.Password,
            this.Status});
            this.dataUser.Location = new System.Drawing.Point(248, 40);
            this.dataUser.Name = "dataUser";
            this.dataUser.ReadOnly = true;
            this.dataUser.Size = new System.Drawing.Size(433, 258);
            this.dataUser.TabIndex = 0;
            this.dataUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Username_txt
            // 
            this.Username_txt.Location = new System.Drawing.Point(12, 40);
            this.Username_txt.Name = "Username_txt";
            this.Username_txt.Size = new System.Drawing.Size(230, 20);
            this.Username_txt.TabIndex = 1;
            // 
            // Passeord_txt
            // 
            this.Passeord_txt.Location = new System.Drawing.Point(12, 95);
            this.Passeord_txt.Name = "Passeord_txt";
            this.Passeord_txt.Size = new System.Drawing.Size(230, 20);
            this.Passeord_txt.TabIndex = 2;
            // 
            // Status_txt
            // 
            this.Status_txt.FormattingEnabled = true;
            this.Status_txt.Items.AddRange(new object[] {
            "karyawan",
            "koki",
            "admin"});
            this.Status_txt.Location = new System.Drawing.Point(12, 147);
            this.Status_txt.Name = "Status_txt";
            this.Status_txt.Size = new System.Drawing.Size(230, 21);
            this.Status_txt.TabIndex = 3;
            // 
            // tambah
            // 
            this.tambah.Location = new System.Drawing.Point(12, 219);
            this.tambah.Name = "tambah";
            this.tambah.Size = new System.Drawing.Size(109, 37);
            this.tambah.TabIndex = 4;
            this.tambah.Text = "Tambah";
            this.tambah.UseVisualStyleBackColor = true;
            this.tambah.Click += new System.EventHandler(this.tambah_Click);
            // 
            // hapus
            // 
            this.hapus.Location = new System.Drawing.Point(12, 262);
            this.hapus.Name = "hapus";
            this.hapus.Size = new System.Drawing.Size(224, 37);
            this.hapus.TabIndex = 5;
            this.hapus.Text = "Hapus";
            this.hapus.UseVisualStyleBackColor = true;
            this.hapus.Click += new System.EventHandler(this.hapus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status";
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(127, 219);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(109, 37);
            this.Edit.TabIndex = 9;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(596, 12);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(85, 22);
            this.Close.TabIndex = 10;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // TambahUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 308);
            this.ControlBox = false;
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hapus);
            this.Controls.Add(this.tambah);
            this.Controls.Add(this.Status_txt);
            this.Controls.Add(this.Passeord_txt);
            this.Controls.Add(this.Username_txt);
            this.Controls.Add(this.dataUser);
            this.Name = "TambahUser";
            this.Text = "TambahUser";
            this.Load += new System.EventHandler(this.TambahUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.TextBox Username_txt;
        private System.Windows.Forms.TextBox Passeord_txt;
        private System.Windows.Forms.ComboBox Status_txt;
        private System.Windows.Forms.Button tambah;
        private System.Windows.Forms.Button hapus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Close;
        internal System.Windows.Forms.DataGridView dataUser;
    }
}