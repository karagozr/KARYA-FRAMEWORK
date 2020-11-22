namespace FirstFormApp
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.txtBoy = new System.Windows.Forms.TextBox();
            this.txtYas = new System.Windows.Forms.TextBox();
            this.chkVefat = new System.Windows.Forms.CheckBox();
            this.btnBak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(77, 159);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(151, 33);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "İsmi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Boy :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Yaş :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vefat :";
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(77, 40);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(151, 20);
            this.txtIsim.TabIndex = 5;
            // 
            // txtBoy
            // 
            this.txtBoy.Location = new System.Drawing.Point(77, 65);
            this.txtBoy.Name = "txtBoy";
            this.txtBoy.Size = new System.Drawing.Size(151, 20);
            this.txtBoy.TabIndex = 6;
            // 
            // txtYas
            // 
            this.txtYas.Location = new System.Drawing.Point(77, 91);
            this.txtYas.Name = "txtYas";
            this.txtYas.Size = new System.Drawing.Size(151, 20);
            this.txtYas.TabIndex = 7;
            // 
            // chkVefat
            // 
            this.chkVefat.AutoSize = true;
            this.chkVefat.Location = new System.Drawing.Point(77, 129);
            this.chkVefat.Name = "chkVefat";
            this.chkVefat.Size = new System.Drawing.Size(15, 14);
            this.chkVefat.TabIndex = 8;
            this.chkVefat.UseVisualStyleBackColor = true;
            // 
            // btnBak
            // 
            this.btnBak.Location = new System.Drawing.Point(77, 198);
            this.btnBak.Name = "btnBak";
            this.btnBak.Size = new System.Drawing.Size(151, 38);
            this.btnBak.TabIndex = 9;
            this.btnBak.Text = "BAK";
            this.btnBak.UseVisualStyleBackColor = true;
            this.btnBak.Click += new System.EventHandler(this.btnBak_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBak);
            this.Controls.Add(this.chkVefat);
            this.Controls.Add(this.txtYas);
            this.Controls.Add(this.txtBoy);
            this.Controls.Add(this.txtIsim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.TextBox txtBoy;
        private System.Windows.Forms.TextBox txtYas;
        private System.Windows.Forms.CheckBox chkVefat;
        private System.Windows.Forms.Button btnBak;
    }
}

