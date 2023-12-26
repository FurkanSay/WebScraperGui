namespace WebScraperGui
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
            this.checkedListBox_ecommerce = new System.Windows.Forms.CheckedListBox();
            this.textBox_productbrand = new System.Windows.Forms.TextBox();
            this.textBox_productmodel = new System.Windows.Forms.TextBox();
            this.textBox_productname = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.label_sec = new System.Windows.Forms.Label();
            this.progressBar_process = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_productcount = new System.Windows.Forms.Label();
            this.label_productamount = new System.Windows.Forms.Label();
            this.label_terim = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.textBox_profilepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBox_ecommerce
            // 
            this.checkedListBox_ecommerce.FormattingEnabled = true;
            this.checkedListBox_ecommerce.Location = new System.Drawing.Point(12, 25);
            this.checkedListBox_ecommerce.Name = "checkedListBox_ecommerce";
            this.checkedListBox_ecommerce.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox_ecommerce.TabIndex = 0;
            this.checkedListBox_ecommerce.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_ecommerce_SelectedIndexChanged);
            // 
            // textBox_productbrand
            // 
            this.textBox_productbrand.Location = new System.Drawing.Point(145, 112);
            this.textBox_productbrand.Name = "textBox_productbrand";
            this.textBox_productbrand.Size = new System.Drawing.Size(146, 20);
            this.textBox_productbrand.TabIndex = 1;
            // 
            // textBox_productmodel
            // 
            this.textBox_productmodel.Location = new System.Drawing.Point(146, 155);
            this.textBox_productmodel.Name = "textBox_productmodel";
            this.textBox_productmodel.Size = new System.Drawing.Size(145, 20);
            this.textBox_productmodel.TabIndex = 2;
            // 
            // textBox_productname
            // 
            this.textBox_productname.Location = new System.Drawing.Point(145, 70);
            this.textBox_productname.Name = "textBox_productname";
            this.textBox_productname.Size = new System.Drawing.Size(146, 20);
            this.textBox_productname.TabIndex = 3;
            this.textBox_productname.Text = "telefon";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 125);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(117, 50);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Başla Scraper";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label_sec
            // 
            this.label_sec.AutoSize = true;
            this.label_sec.Location = new System.Drawing.Point(12, 9);
            this.label_sec.Name = "label_sec";
            this.label_sec.Size = new System.Drawing.Size(41, 13);
            this.label_sec.TabIndex = 6;
            this.label_sec.Text = "Seçiniz";
            // 
            // progressBar_process
            // 
            this.progressBar_process.Location = new System.Drawing.Point(145, 25);
            this.progressBar_process.Name = "progressBar_process";
            this.progressBar_process.Size = new System.Drawing.Size(361, 23);
            this.progressBar_process.TabIndex = 7;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(142, 9);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(21, 13);
            this.label_progress.TabIndex = 8;
            this.label_progress.Text = "%0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Aranacak Ürün";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Marka";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Model";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ürün Sayısı: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ürün Tutarı: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Terimler: ";
            // 
            // label_productcount
            // 
            this.label_productcount.AutoSize = true;
            this.label_productcount.Location = new System.Drawing.Point(375, 73);
            this.label_productcount.Name = "label_productcount";
            this.label_productcount.Size = new System.Drawing.Size(13, 13);
            this.label_productcount.TabIndex = 15;
            this.label_productcount.Text = "0";
            // 
            // label_productamount
            // 
            this.label_productamount.AutoSize = true;
            this.label_productamount.Location = new System.Drawing.Point(375, 119);
            this.label_productamount.Name = "label_productamount";
            this.label_productamount.Size = new System.Drawing.Size(13, 13);
            this.label_productamount.TabIndex = 16;
            this.label_productamount.Text = "0";
            // 
            // label_terim
            // 
            this.label_terim.AutoSize = true;
            this.label_terim.Location = new System.Drawing.Point(375, 158);
            this.label_terim.Name = "label_terim";
            this.label_terim.Size = new System.Drawing.Size(0, 13);
            this.label_terim.TabIndex = 17;
            // 
            // textBox_profilepath
            // 
            this.textBox_profilepath.Location = new System.Drawing.Point(15, 196);
            this.textBox_profilepath.Name = "textBox_profilepath";
            this.textBox_profilepath.Size = new System.Drawing.Size(484, 20);
            this.textBox_profilepath.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Chrome Profil Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 228);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_profilepath);
            this.Controls.Add(this.label_terim);
            this.Controls.Add(this.label_productamount);
            this.Controls.Add(this.label_productcount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.progressBar_process);
            this.Controls.Add(this.label_sec);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.textBox_productname);
            this.Controls.Add(this.textBox_productmodel);
            this.Controls.Add(this.textBox_productbrand);
            this.Controls.Add(this.checkedListBox_ecommerce);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_ecommerce;
        private System.Windows.Forms.TextBox textBox_productbrand;
        private System.Windows.Forms.TextBox textBox_productmodel;
        private System.Windows.Forms.TextBox textBox_productname;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_sec;
        private System.Windows.Forms.ProgressBar progressBar_process;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_productcount;
        private System.Windows.Forms.Label label_productamount;
        private System.Windows.Forms.Label label_terim;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TextBox textBox_profilepath;
        private System.Windows.Forms.Label label1;
    }
}

