using System;
using System.Data;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class FormMain : Form
    {
        private DBService dbService;
        private DataSet dataSet;
        private BindingSource bindingSource;
        private readonly DBHelper dbHelper = new DBHelper();

        public FormMain()
        {
            InitializeComponent();
            dbService = new DBService();
            ConfigureDataGridView();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadMainFormData();
        }
        public void LoadMainFormData()
        {
            dataSet = dbService.LoadData("SELECT * FROM flight_information_simple WHERE ARRIVAL > GETDATE() ORDER BY Arrival ASC", "Flights");
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataSet.Tables["Flights"];
            dataGridViewFlights.DataSource = bindingSource;

            var runwayStatusInfo = dbHelper.GetRunwayStatus();

            string runwayStatus = runwayStatusInfo.isActive ?? false ? "Dostępny" : "Niedostępny";
            string runwayDateTo = runwayStatusInfo.endDate?.ToString("dd.MM") ?? string.Empty;
            string runwayTimeTo = runwayStatusInfo.endDate?.ToString("HH:mm") ?? string.Empty;

            labelRunwayStatus.Text = $"{runwayStatus}";
            labelRunwayTime.Text = $"do: {runwayDateTo}, {runwayTimeTo}";

            var apronStatusInfo = dbHelper.getApronStatus();

            string apronStatus = apronStatusInfo.isEmpty ?? false ? "Dostępny" : "Niedostępny";
            string apronDateTo = apronStatusInfo.endDate?.ToString("dd.MM") ?? string.Empty;
            string apronTimeTo = apronStatusInfo.endDate?.ToString("HH:mm") ?? string.Empty;

            labelApronStatus.Text = $"{apronStatus}";
            labelApronTime.Text = $"do: {apronDateTo}, {apronTimeTo}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormFlights flightsForm = new FormFlights();
            flightsForm.DataUpdated += LoadMainFormData;
            flightsForm.ShowDialog();
            
        }
        private void ConfigureDataGridView()
        {
            dataGridViewFlights.AutoGenerateColumns = false;
            dataGridViewFlights.Columns.Clear();
            dataGridViewFlights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //ComboBox Airplane_ID
            DataGridViewTextBoxColumn airplaneColumn = new DataGridViewTextBoxColumn();
            airplaneColumn.Name = "AircraftDetails";
            airplaneColumn.HeaderText = "Samolot";
            airplaneColumn.DataPropertyName = "AircraftDetails";
            airplaneColumn.ReadOnly = true;
            dataGridViewFlights.Columns.Add(airplaneColumn);

            airplaneColumn.MinimumWidth = 250;

            //Panel Arrival
            DataGridViewTextBoxColumn arrivalColumn = new DataGridViewTextBoxColumn();
            arrivalColumn.Name = "Arrival";
            arrivalColumn.HeaderText = "Przylot";
            arrivalColumn.DataPropertyName = "Arrival";
            arrivalColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            arrivalColumn.ReadOnly = true;
            dataGridViewFlights.Columns.Add(arrivalColumn);

            //Panel Departure
            DataGridViewTextBoxColumn departureColumn = new DataGridViewTextBoxColumn();
            departureColumn.Name = "Departure";
            departureColumn.HeaderText = "Odlot";
            departureColumn.DataPropertyName = "Departure";
            departureColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            departureColumn.ReadOnly = true;
            dataGridViewFlights.Columns.Add(departureColumn);
        }
        private void buttonRefreshDataSet_Click(object sender, EventArgs e)
        {
            LoadMainFormData();
        }

        private void buttonRunwaySchedule_Click(object sender, EventArgs e)
        {
            FormRunwayManagement runwayForm = new FormRunwayManagement();
            runwayForm.ShowDialog();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            FormReports reportsForm = new FormReports();
            reportsForm.ShowDialog();
        }
    }
}
