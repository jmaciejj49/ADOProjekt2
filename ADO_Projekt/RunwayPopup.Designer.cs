namespace ADO_Projekt
{
    partial class RunwayPopup
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
            this.panelDeparture = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.datePickerEndsAt = new System.Windows.Forms.DateTimePicker();
            this.timePickerEndsAt = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelArrival = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickerStartsAt = new System.Windows.Forms.DateTimePicker();
            this.timePickerStartsAt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDeparture.SuspendLayout();
            this.panelArrival.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDeparture
            // 
            this.panelDeparture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDeparture.Controls.Add(this.label7);
            this.panelDeparture.Controls.Add(this.datePickerEndsAt);
            this.panelDeparture.Controls.Add(this.timePickerEndsAt);
            this.panelDeparture.Controls.Add(this.label3);
            this.panelDeparture.Controls.Add(this.label4);
            this.panelDeparture.Location = new System.Drawing.Point(6, 75);
            this.panelDeparture.Margin = new System.Windows.Forms.Padding(2);
            this.panelDeparture.Name = "panelDeparture";
            this.panelDeparture.Size = new System.Drawing.Size(355, 65);
            this.panelDeparture.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 32);
            this.label7.TabIndex = 15;
            this.label7.Text = "Do:";
            // 
            // datePickerEndsAt
            // 
            this.datePickerEndsAt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerEndsAt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerEndsAt.Location = new System.Drawing.Point(57, 32);
            this.datePickerEndsAt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datePickerEndsAt.Name = "datePickerEndsAt";
            this.datePickerEndsAt.Size = new System.Drawing.Size(125, 36);
            this.datePickerEndsAt.TabIndex = 1;
            // 
            // timePickerEndsAt
            // 
            this.timePickerEndsAt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timePickerEndsAt.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerEndsAt.Location = new System.Drawing.Point(261, 32);
            this.timePickerEndsAt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.timePickerEndsAt.Name = "timePickerEndsAt";
            this.timePickerEndsAt.ShowUpDown = true;
            this.timePickerEndsAt.Size = new System.Drawing.Size(83, 36);
            this.timePickerEndsAt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(192, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Godzina:";
            // 
            // panelArrival
            // 
            this.panelArrival.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelArrival.Controls.Add(this.label6);
            this.panelArrival.Controls.Add(this.datePickerStartsAt);
            this.panelArrival.Controls.Add(this.timePickerStartsAt);
            this.panelArrival.Controls.Add(this.label1);
            this.panelArrival.Controls.Add(this.label2);
            this.panelArrival.Location = new System.Drawing.Point(6, 6);
            this.panelArrival.Margin = new System.Windows.Forms.Padding(2);
            this.panelArrival.Name = "panelArrival";
            this.panelArrival.Size = new System.Drawing.Size(355, 65);
            this.panelArrival.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 32);
            this.label6.TabIndex = 14;
            this.label6.Text = "Od:";
            // 
            // datePickerStartsAt
            // 
            this.datePickerStartsAt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerStartsAt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerStartsAt.Location = new System.Drawing.Point(59, 33);
            this.datePickerStartsAt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datePickerStartsAt.Name = "datePickerStartsAt";
            this.datePickerStartsAt.Size = new System.Drawing.Size(125, 36);
            this.datePickerStartsAt.TabIndex = 1;
            // 
            // timePickerStartsAt
            // 
            this.timePickerStartsAt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timePickerStartsAt.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerStartsAt.Location = new System.Drawing.Point(262, 33);
            this.timePickerStartsAt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.timePickerStartsAt.Name = "timePickerStartsAt";
            this.timePickerStartsAt.ShowUpDown = true;
            this.timePickerStartsAt.Size = new System.Drawing.Size(83, 36);
            this.timePickerStartsAt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(193, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Godzina:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSubmit.ForeColor = System.Drawing.Color.Black;
            this.buttonSubmit.Location = new System.Drawing.Point(177, 179);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(184, 36);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Zatwierdź";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.Black;
            this.buttonClose.Location = new System.Drawing.Point(2, 179);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(171, 36);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Anuluj";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxActive.Location = new System.Drawing.Point(88, 5);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(256, 35);
            this.checkBoxActive.TabIndex = 16;
            this.checkBoxActive.Text = "Pas startowy aktywny";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.checkBoxActive);
            this.panel1.Location = new System.Drawing.Point(6, 144);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 33);
            this.panel1.TabIndex = 21;
            // 
            // RunwayPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 327);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDeparture);
            this.Controls.Add(this.panelArrival);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RunwayPopup";
            this.Text = "RunwayPanel";
            this.Load += new System.EventHandler(this.RunwayPopup_Load);
            this.panelDeparture.ResumeLayout(false);
            this.panelDeparture.PerformLayout();
            this.panelArrival.ResumeLayout(false);
            this.panelArrival.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDeparture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker datePickerEndsAt;
        private System.Windows.Forms.DateTimePicker timePickerEndsAt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelArrival;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickerStartsAt;
        private System.Windows.Forms.DateTimePicker timePickerStartsAt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Panel panel1;
    }
}