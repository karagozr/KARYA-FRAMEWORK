namespace HttpRequestApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnHttpRequest = new System.Windows.Forms.Button();
            this.textArea = new DevExpress.XtraEditors.MemoEdit();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtKullaniciKodu = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtGuvenlikKodu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGuvenlikKodu = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.txtTcNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dosyaListeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dosyaListeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHttpRequest
            // 
            this.btnHttpRequest.Location = new System.Drawing.Point(160, 12);
            this.btnHttpRequest.Name = "btnHttpRequest";
            this.btnHttpRequest.Size = new System.Drawing.Size(150, 39);
            this.btnHttpRequest.TabIndex = 0;
            this.btnHttpRequest.Text = "HTTP REQUEST";
            this.btnHttpRequest.UseVisualStyleBackColor = true;
            this.btnHttpRequest.Click += new System.EventHandler(this.btnHttpRequest_Click);
            // 
            // textArea
            // 
            this.textArea.Location = new System.Drawing.Point(12, 407);
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(1176, 514);
            this.textArea.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(105, 141);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(257, 67);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(105, 214);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(257, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtKullaniciKodu
            // 
            this.txtKullaniciKodu.Location = new System.Drawing.Point(105, 63);
            this.txtKullaniciKodu.Name = "txtKullaniciKodu";
            this.txtKullaniciKodu.Size = new System.Drawing.Size(257, 20);
            this.txtKullaniciKodu.TabIndex = 4;
            this.txtKullaniciKodu.Text = "076110100030";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(105, 89);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(257, 20);
            this.txtSifre.TabIndex = 5;
            this.txtSifre.Text = "80280462";
            // 
            // txtGuvenlikKodu
            // 
            this.txtGuvenlikKodu.Location = new System.Drawing.Point(105, 115);
            this.txtGuvenlikKodu.Name = "txtGuvenlikKodu";
            this.txtGuvenlikKodu.Size = new System.Drawing.Size(257, 20);
            this.txtGuvenlikKodu.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kullanıcı Kodu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Şifre :";
            // 
            // lblGuvenlikKodu
            // 
            this.lblGuvenlikKodu.AutoSize = true;
            this.lblGuvenlikKodu.Location = new System.Drawing.Point(16, 118);
            this.lblGuvenlikKodu.Name = "lblGuvenlikKodu";
            this.lblGuvenlikKodu.Size = new System.Drawing.Size(83, 13);
            this.lblGuvenlikKodu.TabIndex = 9;
            this.lblGuvenlikKodu.Text = "Güvenlik Kodu :";
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(760, 106);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(110, 29);
            this.btnSorgula.TabIndex = 10;
            this.btnSorgula.Text = "SORGULA";
            this.btnSorgula.UseVisualStyleBackColor = true;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // txtTcNo
            // 
            this.txtTcNo.Location = new System.Drawing.Point(653, 11);
            this.txtTcNo.Name = "txtTcNo";
            this.txtTcNo.Size = new System.Drawing.Size(217, 20);
            this.txtTcNo.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(604, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "TC NO :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(653, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(217, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(653, 70);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(217, 20);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(601, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tarih -1 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tarih -2 :";
            // 
            // lookUpEdit
            // 
            this.lookUpEdit.Location = new System.Drawing.Point(397, 60);
            this.lookUpEdit.Name = "lookUpEdit";
            this.lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit.Size = new System.Drawing.Size(167, 20);
            this.lookUpEdit.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(397, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 29);
            this.button1.TabIndex = 18;
            this.button1.Text = "GETIR DOSYA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.dosyaListeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(434, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 150);
            this.dataGridView1.TabIndex = 19;
            // 
            // dosyaListeBindingSource
            // 
            this.dosyaListeBindingSource.DataSource = typeof(HttpRequestApp.DosyaListe);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 933);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lookUpEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTcNo);
            this.Controls.Add(this.btnSorgula);
            this.Controls.Add(this.lblGuvenlikKodu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGuvenlikKodu);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciKodu);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textArea);
            this.Controls.Add(this.btnHttpRequest);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.textArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dosyaListeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHttpRequest;
        private DevExpress.XtraEditors.MemoEdit textArea;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtKullaniciKodu;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtGuvenlikKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGuvenlikKodu;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.TextBox txtTcNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dosyaListeBindingSource;
    }
}

