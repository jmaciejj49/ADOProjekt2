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
using System.Configuration;

namespace ADO_Projekt
{
    public partial class FormFlights : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private DBService dbService = new DBService();
        private string query = "SELECT * FROM flights";
        private string table = "flights";
        private DataGridViewCell clickedCell;
        private DataSet flightsDataSet;

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
            flightsDataSet = dbService.LoadData(query, table);
            bindingSource.DataSource = flightsDataSet.Tables[table];

            dataGridViewFlightPlanning.DataSource = bindingSource;
            bindingNavigatorFlightPlanning.BindingSource = bindingSource;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewFlightPlanning.AutoGenerateColumns = false;
            dataGridViewFlightPlanning.Columns.Clear(); 
            dataGridViewFlightPlanning.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
        }

        private void dataGridViewFlightPlanning_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridViewFlightPlanning.Columns["Departure"].Index || e.ColumnIndex == dataGridViewFlightPlanning.Columns["Arrival"].Index))
            {
                clickedCell = dataGridViewFlightPlanning.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var rowIDValue = dataGridViewFlightPlanning.Rows[e.RowIndex].Cells["Airplane"].Value;
                if (rowIDValue == null || DBNull.Value.Equals(rowIDValue))
                {
                    MessageBox.Show("Przed wyznaczeniem terminu należy wybrać samolot!");
                    return;
                }
                int airplaneID = Convert.ToInt32(dataGridViewFlightPlanning.Rows[e.RowIndex].Cells["Airplane"].Value);
                FlightsPopup datepanel;

                if (clickedCell.Value != null && clickedCell.Value != DBNull.Value)
                {
                    DateTime cellDate = Convert.ToDateTime(clickedCell.Value);
                    datepanel = new FlightsPopup(airplaneID, cellDate);
                }
                else
                {
                    datepanel = new FlightsPopup(airplaneID);
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
                DataGridViewRow row = dataGridViewFlightPlanning.Rows[clickedCell.RowIndex];

                // Determine which column was clicked and update appropriately
                if (clickedCell.OwningColumn.Name == "Arrival")
                {
                    row.Cells["Arrival"].Value = e.Arrival;
                    row.Cells["Departure"].Value = e.Departure; // Optionally set departure if needed
                }
                else if (clickedCell.OwningColumn.Name == "Departure")
                {
                    row.Cells["Departure"].Value = e.Departure;
                    row.Cells["Arrival"].Value = e.Arrival; // Optionally set arrival if needed
                }
            }
        }
        private void bindingNavigatorSaveButton_Click(object sender, EventArgs e)
        {
            dataGridViewFlightPlanning.EndEdit();
            bindingSource.EndEdit();

            //if (helper.DataSetHasEmptyFields(flightsDataSet))
            //{
            //    MessageBox.Show("W jednym z wierszy brakuje danych. Wszystkie pola są wymagane!");
            //    return;
            //}

            dbService.UpdateData(flightsDataSet, "flights");

        }
    }
}
