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

        public FormMain()
        {
            InitializeComponent();
            dbService = new DBService();
            LoadData();
        }

        private void LoadData()
        {
            dataSet = dbService.LoadData("SELECT * FROM flight_information", "Flights");
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataSet.Tables["Flights"];
            dataGridViewFlights.DataSource = bindingSource;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Tutaj logika do zapisywania zmian
            //dbService.UpdateData(dataSet);
            //MessageBox.Show("Zmiany zostały zapisane.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormFlights flightsForm = new FormFlights();
            flightsForm.ShowDialog();
            
        }

        private void buttonRefreshDataSet_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonRunwaySchedule_Click(object sender, EventArgs e)
        {
            FormRunwayManagement runwayForm = new FormRunwayManagement();
            runwayForm.ShowDialog();
        }
    }
}
