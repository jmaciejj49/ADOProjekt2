using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class FormRunwayManagement : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private DBService dbService = new DBService();
        private DataSet runwayDataSet;

        public FormRunwayManagement()
        {
            InitializeComponent();
            LoadRunwayData();
            ConfigureDataGridView();
        }

        private void LoadRunwayData()
        {
            string query = "SELECT * FROM runway_schedule";
            runwayDataSet = dbService.LoadData(query, "runway_schedule");
            bindingSource.DataSource = runwayDataSet.Tables["runway_schedule"];

            dataGridViewRunway.DataSource = bindingSource;
            bindingNavigatorRunway.BindingSource = bindingSource;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewRunway.AutoGenerateColumns = false;
            dataGridViewRunway.Columns.Clear();
            dataGridViewRunway.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ukryta kolumna ID
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "ID";
            idColumn.Name = "ID";
            idColumn.Visible = false;
            idColumn.ReadOnly = true;  // Kolumna jest tylko do odczytu
            dataGridViewRunway.Columns.Add(idColumn);

            // Kolumna 'Od'
            DataGridViewTextBoxColumn fromColumn = new DataGridViewTextBoxColumn();
            fromColumn.DataPropertyName = "TimeFrom";
            fromColumn.Name = "Od";  // Ustawienie nazwy kolumny
            fromColumn.HeaderText = "Od";
            fromColumn.ReadOnly = true;  // Kolumna jest tylko do odczytu
            dataGridViewRunway.Columns.Add(fromColumn);

            // Kolumna 'Do'
            DataGridViewTextBoxColumn toColumn = new DataGridViewTextBoxColumn();
            toColumn.DataPropertyName = "TimeTo";
            toColumn.Name = "Do";  // Ustawienie nazwy kolumny
            toColumn.HeaderText = "Do";
            toColumn.ReadOnly = true;  // Kolumna jest tylko do odczytu
            dataGridViewRunway.Columns.Add(toColumn);

            // Kolumna 'Status'
            DataGridViewCheckBoxColumn statusColumn = new DataGridViewCheckBoxColumn();
            statusColumn.DataPropertyName = "Active";
            statusColumn.Name = "Status";  // Ustawienie nazwy kolumny
            statusColumn.HeaderText = "Status";
            statusColumn.ReadOnly = true;  // Checkboxy będą tylko do odczytu
            dataGridViewRunway.Columns.Add(statusColumn);
        }


        private void dataGridViewRunway_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridViewRunway.Columns["Od"].Index || e.ColumnIndex == dataGridViewRunway.Columns["Do"].Index))
            {
                DataGridViewCell clickedCell = dataGridViewRunway.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DateTime initialDate;

                // Check if the clicked cell has a value; if not, use the current time
                if (clickedCell.Value != null && clickedCell.Value != DBNull.Value)
                {
                    initialDate = Convert.ToDateTime(clickedCell.Value);
                }
                else
                {
                    initialDate = DateTime.Now;
                }

                RunwayPopup runwayPopup = new RunwayPopup(initialDate);
                runwayPopup.StartPosition = FormStartPosition.CenterParent;

                if (runwayPopup.ShowDialog() == DialogResult.OK)
                {
                    // Update the appropriate cell based on which column was clicked
                    if (e.ColumnIndex == dataGridViewRunway.Columns["Od"].Index)
                    {
                        dataGridViewRunway.Rows[e.RowIndex].Cells["Od"].Value = runwayPopup.StartsAt;
                    }
                    else
                    {
                        dataGridViewRunway.Rows[e.RowIndex].Cells["Do"].Value = runwayPopup.EndsAt;
                    }
                }
            }
        }

    }
}
