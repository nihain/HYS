namespace HYS.Forms
{
    partial class FormAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppointment));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maskedTextBoxTime = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonMakeAppointment = new System.Windows.Forms.Button();
            this.maskedTextBoxDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDoctors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxClinics = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.label14);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(484, 50);
            this.panelHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Randevu Al";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(365, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("IBM Plex Mono Medm", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(411, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 31);
            this.label14.TabIndex = 2;
            this.label14.Text = "HYS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.maskedTextBoxTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.buttonMakeAppointment);
            this.panel1.Controls.Add(this.maskedTextBoxDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxDoctors);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxClinics);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 361);
            this.panel1.TabIndex = 2;
            // 
            // maskedTextBoxTime
            // 
            this.maskedTextBoxTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maskedTextBoxTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.maskedTextBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskedTextBoxTime.ForeColor = System.Drawing.Color.White;
            this.maskedTextBoxTime.Location = new System.Drawing.Point(192, 160);
            this.maskedTextBoxTime.Mask = "00:00";
            this.maskedTextBoxTime.Name = "maskedTextBoxTime";
            this.maskedTextBoxTime.Size = new System.Drawing.Size(67, 28);
            this.maskedTextBoxTime.TabIndex = 4;
            this.maskedTextBoxTime.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IBM Plex Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(119, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Saat:";
            // 
            // buttonMakeAppointment
            // 
            this.buttonMakeAppointment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMakeAppointment.BackColor = System.Drawing.Color.SlateGray;
            this.buttonMakeAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeAppointment.Location = new System.Drawing.Point(160, 225);
            this.buttonMakeAppointment.Name = "buttonMakeAppointment";
            this.buttonMakeAppointment.Size = new System.Drawing.Size(180, 70);
            this.buttonMakeAppointment.TabIndex = 5;
            this.buttonMakeAppointment.Text = "Randevu Al";
            this.buttonMakeAppointment.UseVisualStyleBackColor = false;
            this.buttonMakeAppointment.Click += new System.EventHandler(this.buttonMakeAppointment_Click);
            // 
            // maskedTextBoxDate
            // 
            this.maskedTextBoxDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maskedTextBoxDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.maskedTextBoxDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskedTextBoxDate.ForeColor = System.Drawing.Color.White;
            this.maskedTextBoxDate.Location = new System.Drawing.Point(192, 126);
            this.maskedTextBoxDate.Mask = "00/00/0000";
            this.maskedTextBoxDate.Name = "maskedTextBoxDate";
            this.maskedTextBoxDate.Size = new System.Drawing.Size(131, 28);
            this.maskedTextBoxDate.TabIndex = 3;
            this.maskedTextBoxDate.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IBM Plex Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(108, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tarih:";
            // 
            // comboBoxDoctors
            // 
            this.comboBoxDoctors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxDoctors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.comboBoxDoctors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDoctors.Font = new System.Drawing.Font("IBM Plex Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDoctors.ForeColor = System.Drawing.Color.White;
            this.comboBoxDoctors.FormattingEnabled = true;
            this.comboBoxDoctors.Location = new System.Drawing.Point(192, 91);
            this.comboBoxDoctors.Name = "comboBoxDoctors";
            this.comboBoxDoctors.Size = new System.Drawing.Size(210, 29);
            this.comboBoxDoctors.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IBM Plex Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(97, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Doktor:";
            // 
            // comboBoxClinics
            // 
            this.comboBoxClinics.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxClinics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.comboBoxClinics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxClinics.Font = new System.Drawing.Font("IBM Plex Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClinics.ForeColor = System.Drawing.Color.White;
            this.comboBoxClinics.FormattingEnabled = true;
            this.comboBoxClinics.Location = new System.Drawing.Point(192, 50);
            this.comboBoxClinics.Name = "comboBoxClinics";
            this.comboBoxClinics.Size = new System.Drawing.Size(210, 29);
            this.comboBoxClinics.TabIndex = 1;
            this.comboBoxClinics.SelectedIndexChanged += new System.EventHandler(this.comboBoxClinics_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IBM Plex Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(97, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Klinik:";
            // 
            // FormAppointment
            // 
            this.AcceptButton = this.buttonMakeAppointment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("IBM Plex Mono", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "FormAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randevu Menüsü";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDoctors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxClinics;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDate;
        private System.Windows.Forms.Button buttonMakeAppointment;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTime;
        private System.Windows.Forms.Label label5;
    }
}