namespace ClientSocket
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.Location = new System.Drawing.Point(705, 139);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(83, 23);
            this.btnDosyaSec.TabIndex = 0;
            this.btnDosyaSec.Text = "Dosya Seç";
            this.btnDosyaSec.UseVisualStyleBackColor = true;
            this.btnDosyaSec.Visible = false;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(705, 168);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 214);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Yazdır";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(160, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dosya Yolu :";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(25, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(485, 303);
            this.listBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(588, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Getir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(713, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Sil";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDosyaSec);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDosyaSec;
        private System.Windows.Forms.Button btnSend;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

