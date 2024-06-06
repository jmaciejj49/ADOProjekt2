using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class FormReports : Form
    {
        private DBService dbService;
        public FormReports()
        {
            InitializeComponent();
            dbService = new DBService();
            InitializeComboBoxYears();
            comboBoxYear.SelectedIndexChanged += comboBoxAirlineShareYear_SelectedIndexChanged;
            dataGridViewRunwayUsage.CellFormatting += dataGridViewRunwayUsage_CellFormatting;
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            LoadAirlineShareData(DateTime.Now.Year);
            LoadRunwayUsageData(DateTime.Now.Year);
        }
        private void InitializeComboBoxYears()
        {
            int currentYear = DateTime.Now.Year;
            comboBoxYear.Items.Add(currentYear);
            comboBoxYear.Items.Add(currentYear - 1);
            comboBoxYear.SelectedIndex = 0;
        }
        private void LoadAirlineShareData(int year)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Year", year)
            };
            var dataSet = dbService.LoadProcedureData("airlines_flight_share", parameters, "AirlineShare");
            dataGridViewAirlineFlightShare.DataSource = dataSet.Tables["AirlineShare"];
            dataGridViewAirlineFlightShare.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridViewAirlineFlightShare.Columns["MonthName"] != null)
                dataGridViewAirlineFlightShare.Columns["MonthName"].HeaderText = "Miesiąc";
            if (dataGridViewAirlineFlightShare.Columns["AirlineName"] != null)
                dataGridViewAirlineFlightShare.Columns["AirlineName"].HeaderText = "Linia lotnicza";
            if (dataGridViewAirlineFlightShare.Columns["NumberOfFlights"] != null)
                dataGridViewAirlineFlightShare.Columns["NumberOfFlights"].HeaderText = "Ilość lotów";
            if (dataGridViewAirlineFlightShare.Columns["Share"] != null)
                dataGridViewAirlineFlightShare.Columns["Share"].HeaderText = "Udział w %";
        }
        private void LoadRunwayUsageData(int year)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Year", year)
            };
            var dataSet = dbService.LoadProcedureData("runway_usage", parameters, "RunwayUsage");
            dataGridViewRunwayUsage.DataSource = dataSet.Tables["RunwayUsage"];
            dataGridViewRunwayUsage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridViewRunwayUsage.Columns["MonthName"] != null)
                dataGridViewRunwayUsage.Columns["MonthName"].HeaderText = "Miesiąc";
            if (dataGridViewRunwayUsage.Columns["Usage"] != null)
                dataGridViewRunwayUsage.Columns["Usage"].HeaderText = "Zużycie w %";
            if (dataGridViewRunwayUsage.Columns["UsedTime"] != null)
                dataGridViewRunwayUsage.Columns["UsedTime"].HeaderText = "Suma czasu";
        }
        private void comboBoxAirlineShareYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxYear.SelectedItem != null)
            {
                int selectedYear = (int)comboBoxYear.SelectedItem;
                LoadAirlineShareData(selectedYear);
                LoadRunwayUsageData(selectedYear);
            }
        }
        private void dataGridViewRunwayUsage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewRunwayUsage.Columns[e.ColumnIndex].Name == "Usage" && e.Value != null)
            {
                if (double.TryParse(e.Value.ToString(), out double value) && value == 0.00)
                {
                    e.Value = "N/A";
                    e.FormattingApplied = true;
                }
            }
            else if (dataGridViewRunwayUsage.Columns[e.ColumnIndex].Name == "UsedTime" && e.Value != null)
            {
                string timeValue = e.Value.ToString();
                if (timeValue == "0:00")
                {
                    e.Value = "0";
                    e.FormattingApplied = true;
                }
                else
                {
                    TimeSpan timeSpan;
                    if (TimeSpan.TryParse(timeValue, out timeSpan))
                    {
                        e.Value = $"{timeSpan.Hours}h {timeSpan.Minutes}min";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

    }
}
