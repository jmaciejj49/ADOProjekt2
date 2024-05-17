using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO_Projekt
{
    public partial class FormFlights : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private DbService dbService = new DbService();
        private string query = "SELECT ID, Airplane_ID, Departure, Arrival, Status_ID FROM Flights;";
        private string table = "Flights";
        private DataGridViewCell clickedCell;

        public FormFlights()
        {
            InitializeComponent();
            ConfigureDataGridView(); 
        }

        private void FormFlights_Load(object sender, EventArgs e)
        {
            LoadFlights();
        }

        private void LoadFlights()
        {
            DataSet flightsDataSet = dbService.LoadData(query, table);
            bindingSource.DataSource = flightsDataSet;
            bindingSource.DataMember = table;

            dataGridViewFlightPlanning.DataSource = bindingSource;
            bindingNavigatorFlightPlanning.BindingSource = bindingSource;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewFlightPlanning.AutoGenerateColumns = false;
            dataGridViewFlightPlanning.Columns.Clear(); 
            dataGridViewFlightPlanning.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //Panel Arrival
            DataGridViewTextBoxColumn arrivalColumn = new DataGridViewTextBoxColumn();
            arrivalColumn.Name = "Arrival";
            arrivalColumn.HeaderText = "Przylot";
            arrivalColumn.DataPropertyName = "Arrival";
            arrivalColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            arrivalColumn.ReadOnly = true;
            dataGridViewFlightPlanning.Columns.Add(arrivalColumn);

            //Panel Departure
            DataGridViewTextBoxColumn departureColumn = new DataGridViewTextBoxColumn();
            departureColumn.Name = "Departure";
            departureColumn.HeaderText = "Odlot";
            departureColumn.DataPropertyName = "Departure";
            departureColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            departureColumn.ReadOnly = true;
            dataGridViewFlightPlanning.Columns.Add(departureColumn);

            //ComboBox Airplane_ID
            DataGridViewComboBoxColumn airplaneColumn = new DataGridViewComboBoxColumn();
            airplaneColumn.Name = "Airplane";
            airplaneColumn.HeaderText = "Airplane";
            airplaneColumn.DataPropertyName = "Airplane_ID";
            airplaneColumn.DataSource = dbService.LoadData("SELECT AircraftID, CONCAT(Manufacturer, ' ', ModelName) AS AircraftDetails FROM aircraft_information", "AircraftDetails").Tables["AircraftDetails"];
            airplaneColumn.DisplayMember = "AircraftDetails";
            airplaneColumn.ValueMember = "AircraftID";
            airplaneColumn.MinimumWidth = 250;
            dataGridViewFlightPlanning.Columns.Add(airplaneColumn);

            //ComboBox Status_ID
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.DataPropertyName = "Status_ID";
            statusColumn.DataSource = dbService.LoadData("SELECT ID, Status_Name FROM flight_status", "Status").Tables["Status"];
            statusColumn.DisplayMember = "Status_Name";
            statusColumn.ValueMember = "ID";
            dataGridViewFlightPlanning.Columns.Add(statusColumn);
        }

        private void dataGridViewFlightPlanning_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridViewFlightPlanning.Columns["Departure"].Index || e.ColumnIndex == dataGridViewFlightPlanning.Columns["Arrival"].Index))
            {
                clickedCell = dataGridViewFlightPlanning.Rows[e.RowIndex].Cells[e.ColumnIndex];

                string columnName = dataGridViewFlightPlanning.Columns[e.ColumnIndex].HeaderText;
                DatePanel datepanel;

                if (clickedCell.Value != null && clickedCell.Value != DBNull.Value)
                {
                    DateTime cellDate = Convert.ToDateTime(clickedCell.Value);
                    datepanel = new DatePanel(columnName, cellDate);
                }
                else
                {
                    datepanel = new DatePanel(columnName);
                }

                datepanel.DateSelected += Datepanel_DateSelected;

                datepanel.StartPosition = FormStartPosition.Manual;
                datepanel.Location = new Point(
                    this.Location.X + this.Width / 2 - datepanel.Width / 2,
                    this.Location.Y + this.Height / 2 - datepanel.Height / 2);

                datepanel.Show();
            }
        }


        private void Datepanel_DateSelected(object sender, DateSelectedEventArgs e)
        {
            if (clickedCell != null)
            {
                clickedCell.Value = e.SelectedDateTime;
            }
        }

        private void bindingNavigatorSave_Click(object sender, EventArgs e)
        {
            bindingSource.EndEdit(); // Zatwierdź wszystkie bieżące edycje
            DataSet flightsDataSet = (DataSet)bindingSource.DataSource;
            if (flightsDataSet.HasChanges())
            {
                try
                {
                    dbService.UpdateData(flightsDataSet, query, table);
                    MessageBox.Show("Zmiany zostały zapisane.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas zapisywania zmian: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Brak zmian do zapisania.");
            }
        }

    }
}
