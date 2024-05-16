namespace ADO_Projekt
{
    partial class FormMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelRunway = new System.Windows.Forms.Panel();
            this.labelRunwayTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRunwayStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRunwaySchedule = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewFlights = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelRunway.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRunway
            // 
            this.panelRunway.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelRunway.Controls.Add(this.labelRunwayTime);
            this.panelRunway.Controls.Add(this.label2);
            this.panelRunway.Controls.Add(this.labelRunwayStatus);
            this.panelRunway.Controls.Add(this.label3);
            this.panelRunway.Location = new System.Drawing.Point(12, 49);
            this.panelRunway.Name = "panelRunway";
            this.panelRunway.Size = new System.Drawing.Size(426, 57);
            this.panelRunway.TabIndex = 0;
            // 
            // labelRunwayTime
            // 
            this.labelRunwayTime.AutoSize = true;
            this.labelRunwayTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRunwayTime.ForeColor = System.Drawing.Color.Black;
            this.labelRunwayTime.Location = new System.Drawing.Point(266, 15);
            this.labelRunwayTime.Name = "labelRunwayTime";
            this.labelRunwayTime.Size = new System.Drawing.Size(146, 25);
            this.labelRunwayTime.TabIndex = 5;
            this.labelRunwayTime.Text = "24.05.2024 15:39";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aktualny status:";
            // 
            // labelRunwayStatus
            // 
            this.labelRunwayStatus.AutoSize = true;
            this.labelRunwayStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRunwayStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelRunwayStatus.Location = new System.Drawing.Point(151, 15);
            this.labelRunwayStatus.Name = "labelRunwayStatus";
            this.labelRunwayStatus.Size = new System.Drawing.Size(65, 25);
            this.labelRunwayStatus.TabIndex = 3;
            this.labelRunwayStatus.Text = "Wolny";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(222, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "do:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Płyta postojowa";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 37);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonRunwaySchedule
            // 
            this.buttonRunwaySchedule.BackColor = System.Drawing.Color.Silver;
            this.buttonRunwaySchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRunwaySchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRunwaySchedule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRunwaySchedule.Location = new System.Drawing.Point(464, 12);
            this.buttonRunwaySchedule.Name = "buttonRunwaySchedule";
            this.buttonRunwaySchedule.Size = new System.Drawing.Size(269, 94);
            this.buttonRunwaySchedule.TabIndex = 3;
            this.buttonRunwaySchedule.Text = "Zarządzanie pasem startowym";
            this.buttonRunwaySchedule.UseVisualStyleBackColor = false;
            // 
            // buttonReports
            // 
            this.buttonReports.BackColor = System.Drawing.Color.Silver;
            this.buttonReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonReports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReports.Location = new System.Drawing.Point(959, 12);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(192, 94);
            this.buttonReports.TabIndex = 4;
            this.buttonReports.Text = "Raporty";
            this.buttonReports.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(739, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 94);
            this.button3.TabIndex = 5;
            this.button3.Text = "Zarządzanie lotami";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewFlights
            // 
            this.dataGridViewFlights.AllowUserToAddRows = false;
            this.dataGridViewFlights.AllowUserToDeleteRows = false;
            this.dataGridViewFlights.AllowUserToResizeColumns = false;
            this.dataGridViewFlights.AllowUserToResizeRows = false;
            this.dataGridViewFlights.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFlights.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFlights.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFlights.Enabled = false;
            this.dataGridViewFlights.Location = new System.Drawing.Point(12, 168);
            this.dataGridViewFlights.Name = "dataGridViewFlights";
            this.dataGridViewFlights.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewFlights.RowHeadersVisible = false;
            this.dataGridViewFlights.RowHeadersWidth = 51;
            this.dataGridViewFlights.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFlights.RowTemplate.Height = 24;
            this.dataGridViewFlights.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFlights.Size = new System.Drawing.Size(1139, 372);
            this.dataGridViewFlights.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1139, 37);
            this.panel2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Najbliższe loty";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewFlights);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonReports);
            this.Controls.Add(this.buttonRunwaySchedule);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRunway);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Choroszcz International Airport | Main Menu";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelRunway.ResumeLayout(false);
            this.panelRunway.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRunway;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRunwayStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRunwayTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRunwaySchedule;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridViewFlights;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
    }
}

