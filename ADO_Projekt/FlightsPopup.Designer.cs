namespace ADO_Projekt
{
    partial class FlightsPopup
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.datePickerArrival = new System.Windows.Forms.DateTimePicker();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timePickerArrival = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonForecast = new System.Windows.Forms.Button();
            this.labelWeather = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWeatherStatus = new System.Windows.Forms.Label();
            this.labelWeatherOK = new System.Windows.Forms.Label();
            this.panelArrival = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panelDeparture = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.datePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.timePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelArrival.SuspendLayout();
            this.panelDeparture.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.Black;
            this.buttonClose.Location = new System.Drawing.Point(7, 276);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(171, 36);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Anuluj";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // datePickerArrival
            // 
            this.datePickerArrival.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerArrival.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerArrival.Location = new System.Drawing.Point(59, 33);
            this.datePickerArrival.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datePickerArrival.Name = "datePickerArrival";
            this.datePickerArrival.Size = new System.Drawing.Size(125, 27);
            this.datePickerArrival.TabIndex = 1;
            this.datePickerArrival.ValueChanged += new System.EventHandler(this.dateTimePickerDate_ValueChanged);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSubmit.ForeColor = System.Drawing.Color.Black;
            this.buttonSubmit.Location = new System.Drawing.Point(178, 276);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(184, 36);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Zatwierdź";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
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
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Godzina:";
            // 
            // timePickerArrival
            // 
            this.timePickerArrival.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timePickerArrival.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerArrival.Location = new System.Drawing.Point(262, 33);
            this.timePickerArrival.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.timePickerArrival.Name = "timePickerArrival";
            this.timePickerArrival.ShowUpDown = true;
            this.timePickerArrival.Size = new System.Drawing.Size(83, 27);
            this.timePickerArrival.TabIndex = 2;
            this.timePickerArrival.ValueChanged += new System.EventHandler(this.dateTimePickerTime_ValueChanged);
            // 
            // buttonForecast
            // 
            this.buttonForecast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonForecast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForecast.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonForecast.ForeColor = System.Drawing.Color.Black;
            this.buttonForecast.Location = new System.Drawing.Point(7, 72);
            this.buttonForecast.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonForecast.Name = "buttonForecast";
            this.buttonForecast.Size = new System.Drawing.Size(355, 36);
            this.buttonForecast.TabIndex = 7;
            this.buttonForecast.Text = "Sprawdź pogodę";
            this.buttonForecast.UseVisualStyleBackColor = false;
            this.buttonForecast.Click += new System.EventHandler(this.buttonForecast_Click_1);
            // 
            // labelWeather
            // 
            this.labelWeather.AutoSize = true;
            this.labelWeather.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWeather.Location = new System.Drawing.Point(7, 14);
            this.labelWeather.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeather.Name = "labelWeather";
            this.labelWeather.Size = new System.Drawing.Size(0, 20);
            this.labelWeather.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.labelWeatherStatus);
            this.panel1.Controls.Add(this.labelWeatherOK);
            this.panel1.Controls.Add(this.labelWeather);
            this.panel1.Location = new System.Drawing.Point(7, 108);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 103);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelWeatherStatus
            // 
            this.labelWeatherStatus.AutoSize = true;
            this.labelWeatherStatus.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWeatherStatus.Location = new System.Drawing.Point(60, 66);
            this.labelWeatherStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeatherStatus.Name = "labelWeatherStatus";
            this.labelWeatherStatus.Size = new System.Drawing.Size(0, 20);
            this.labelWeatherStatus.TabIndex = 10;
            // 
            // labelWeatherOK
            // 
            this.labelWeatherOK.AutoSize = true;
            this.labelWeatherOK.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWeatherOK.Location = new System.Drawing.Point(7, 66);
            this.labelWeatherOK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeatherOK.Name = "labelWeatherOK";
            this.labelWeatherOK.Size = new System.Drawing.Size(54, 20);
            this.labelWeatherOK.TabIndex = 9;
            this.labelWeatherOK.Text = "Status:";
            this.labelWeatherOK.Click += new System.EventHandler(this.labelWeatherOK_Click);
            // 
            // panelArrival
            // 
            this.panelArrival.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelArrival.Controls.Add(this.label6);
            this.panelArrival.Controls.Add(this.datePickerArrival);
            this.panelArrival.Controls.Add(this.timePickerArrival);
            this.panelArrival.Controls.Add(this.label1);
            this.panelArrival.Controls.Add(this.label2);
            this.panelArrival.Location = new System.Drawing.Point(7, 7);
            this.panelArrival.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelArrival.Name = "panelArrival";
            this.panelArrival.Size = new System.Drawing.Size(355, 65);
            this.panelArrival.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "Przylot";
            // 
            // panelDeparture
            // 
            this.panelDeparture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDeparture.Controls.Add(this.label7);
            this.panelDeparture.Controls.Add(this.datePickerDeparture);
            this.panelDeparture.Controls.Add(this.timePickerDeparture);
            this.panelDeparture.Controls.Add(this.label3);
            this.panelDeparture.Controls.Add(this.label4);
            this.panelDeparture.Location = new System.Drawing.Point(7, 211);
            this.panelDeparture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDeparture.Name = "panelDeparture";
            this.panelDeparture.Size = new System.Drawing.Size(355, 65);
            this.panelDeparture.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "Odlot";
            // 
            // datePickerDeparture
            // 
            this.datePickerDeparture.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerDeparture.Location = new System.Drawing.Point(57, 32);
            this.datePickerDeparture.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datePickerDeparture.Name = "datePickerDeparture";
            this.datePickerDeparture.Size = new System.Drawing.Size(125, 27);
            this.datePickerDeparture.TabIndex = 1;
            // 
            // timePickerDeparture
            // 
            this.timePickerDeparture.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timePickerDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerDeparture.Location = new System.Drawing.Point(261, 32);
            this.timePickerDeparture.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.timePickerDeparture.Name = "timePickerDeparture";
            this.timePickerDeparture.ShowUpDown = true;
            this.timePickerDeparture.Size = new System.Drawing.Size(83, 27);
            this.timePickerDeparture.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
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
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Godzina:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatus.Location = new System.Drawing.Point(60, 66);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 20);
            this.labelStatus.TabIndex = 11;
            // 
            // DatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 320);
            this.Controls.Add(this.panelDeparture);
            this.Controls.Add(this.panelArrival);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonForecast);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "DatePanel";
            this.Text = "DatePanel";
            this.Load += new System.EventHandler(this.DatePanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelArrival.ResumeLayout(false);
            this.panelArrival.PerformLayout();
            this.panelDeparture.ResumeLayout(false);
            this.panelDeparture.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DateTimePicker datePickerArrival;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker timePickerArrival;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonForecast;
        private System.Windows.Forms.Label labelWeather;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWeatherOK;
        private System.Windows.Forms.Label labelWeatherStatus;
        private System.Windows.Forms.Panel panelArrival;
        private System.Windows.Forms.Panel panelDeparture;
        private System.Windows.Forms.DateTimePicker datePickerDeparture;
        private System.Windows.Forms.DateTimePicker timePickerDeparture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelStatus;
    }
}