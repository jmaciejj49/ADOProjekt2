using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ADO_Projekt.RunwayPopup;

namespace ADO_Projekt
{
    public partial class FormRunwayManagement : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private DBService dbService = new DBService();
        private DataSet runwayDataSet;

        private DataGridViewCell clickedCell;
        private readonly DBHelper dbHelper = new DBHelper();

        public FormRunwayManagement()
        {
            InitializeComponent();
            LoadRunwayData();
            ConfigureDataGridView();
            SetStatusLabel();
            dataGridViewRunway.CellFormatting += dataGridViewRunway_CellFormatting;
            AddCustomDeleteButton();
            DisableDefaultDelete();
        }
        private void SetStatusLabel()
        {
            var statusInfo = dbHelper.GetRunwayStatus();

            string status = statusInfo.isActive ?? false ? "Dostępny" : "Niedostępny";
            string dateTo = statusInfo.endDate?.ToString("dd.MM") ?? string.Empty;
            string timeTo = statusInfo.endDate?.ToString("HH:mm") ?? string.Empty;

            labelStatus.Text = $"{status}, do: {dateTo}, {timeTo}";
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
            idColumn.ReadOnly = true;
            dataGridViewRunway.Columns.Add(idColumn);

            // Kolumna 'Od'
            DataGridViewTextBoxColumn fromColumn = new DataGridViewTextBoxColumn();
            fromColumn.DataPropertyName = "TimeFrom";
            fromColumn.Name = "Od";
            fromColumn.HeaderText = "Od";
            fromColumn.ReadOnly = true;
            dataGridViewRunway.Columns.Add(fromColumn);

            // Kolumna 'Do'
            DataGridViewTextBoxColumn toColumn = new DataGridViewTextBoxColumn();
            toColumn.DataPropertyName = "TimeTo";
            toColumn.Name = "Do";
            toColumn.HeaderText = "Do";
            toColumn.ReadOnly = true;  
            dataGridViewRunway.Columns.Add(toColumn);

            // Kolumna 'Status'
            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "Active";
            statusColumn.Name = "Status"; 
            statusColumn.HeaderText = "Status";
            statusColumn.ReadOnly = true;
            dataGridViewRunway.Columns.Add(statusColumn);
        }


        private void dataGridViewRunway_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickedCell = dataGridViewRunway.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataGridViewRow row = dataGridViewRunway.Rows[e.RowIndex];
            RunwayPanelArguments arguments = new RunwayPanelArguments();

            if (clickedCell.Value != null && clickedCell.Value != DBNull.Value)
            {
                arguments.StartsAt = Convert.ToDateTime(dataGridViewRunway.Rows[e.RowIndex].Cells["Od"].Value);
                arguments.EndsAt = Convert.ToDateTime(dataGridViewRunway.Rows[e.RowIndex].Cells["Do"].Value);
                arguments.IsActive = Convert.ToBoolean(dataGridViewRunway.Rows[e.RowIndex].Cells["Status"].Value);
                arguments.EntityID = Convert.ToInt32(row.Cells["ID"].Value);
            }
            else
            {
                arguments = null;
            }

            RunwayPopup runwayPopup = new RunwayPopup(arguments);

            runwayPopup.RunwayDateSelected += RunwayDateSelected;
            runwayPopup.Show();
        }
        private void RunwayDateSelected(object sender, RunwayPanelArguments e)
        {
            if (clickedCell != null)
            {
                DataGridViewRow row = dataGridViewRunway.Rows[clickedCell.RowIndex];
                row.Cells["Od"].Value = e.StartsAt;
                row.Cells["Do"].Value = e.EndsAt;
                row.Cells["Status"].Value = e.IsActive;

                SetStatusLabel();
            }
        }

        private void bindingNavigatorSaveButton_Click(object sender, EventArgs e)
        {
            dataGridViewRunway.EndEdit();
            bindingSource.EndEdit();
            dbService.UpdateData(runwayDataSet, "runway_schedule");
        }

        private void dataGridViewRunway_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewRunway.Columns[e.ColumnIndex].Name == "Status" && e.Value != null && e.Value is bool)
            {
                bool status = (bool)e.Value;
                e.CellStyle.ForeColor = status ? Color.Green : Color.Red;
                e.Value = status ? "Dostępny" : "Niedostępny";
            }
        }

        private void CustomDeleteButtonClick(object sender, EventArgs e)
        {
            if (dataGridViewRunway.CurrentRow == null || dataGridViewRunway.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Nie wybrano żadnego wiersza do usunięcia lub wiersz jest nowym wierszem.");
                return;
            }

            DataRowView currentRowView = dataGridViewRunway.CurrentRow.DataBoundItem as DataRowView;

            if (currentRowView != null && currentRowView.Row.RowState == DataRowState.Detached)
            {
                dataGridViewRunway.Rows.RemoveAt(dataGridViewRunway.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Nie można usunąć zapisanych lub załadowanych danych.");
            }
        }
        private void DisableDefaultDelete()
        {
            bindingNavigatorDeleteItem.Enabled = false;
        }
        private void AddCustomDeleteButton()
        {
            ToolStripButton deleteButton = new ToolStripButton();
            deleteButton.Text = "Usuń";
            deleteButton.Click += new EventHandler(CustomDeleteButtonClick);
            bindingNavigatorRunway.Items.Add(deleteButton);
        }

    }
}
