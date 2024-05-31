using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class DatePanel : Form
    {
        public event EventHandler<DateSelectedEventArgs> DateSelected;
        private string apiKey = "57e179d3b5cd4769aa2155701243105";
        private string location = "Choroszcz";
        private bool weatherIsOk;
        private int airplaneID;

        public DatePanel(int airplaneID, DateTime dateToDisplay = default(DateTime))
        {
            InitializeComponent();
            this.airplaneID = airplaneID;

            if (dateToDisplay == default(DateTime))
            {
                dateToDisplay = DateTime.Now.AddDays(1);
            }

            datePickerArrival.Value = dateToDisplay.Date;
            datePickerArrival.MinDate = dateToDisplay.Date;
            datePickerArrival.MaxDate = dateToDisplay.Date.AddDays(14);
            timePickerArrival.Value = DateTimePickerTime(dateToDisplay.TimeOfDay);

            datePickerDeparture.Value = datePickerArrival.Value.Date.AddHours(1);
            datePickerDeparture.MaxDate = datePickerArrival.Value.Date.AddDays(1);
            datePickerDeparture.MinDate = datePickerArrival.Value.Date;
            timePickerDeparture.Value = timePickerArrival.Value.AddMinutes(30);
        }

        private DateTime DateTimePickerTime(TimeSpan timeOfDay)
        {
            DateTime currentTime = DateTime.Now;
            return new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, timeOfDay.Hours, timeOfDay.Minutes, timeOfDay.Seconds);
        }

        private void DatePanel_Load(object sender, EventArgs e)
        {
            timePickerArrival.Format = DateTimePickerFormat.Custom;
            timePickerDeparture.Format = DateTimePickerFormat.Custom;

            timePickerArrival.CustomFormat = "HH:mm";
            timePickerDeparture.CustomFormat = "HH:mm";
            
            buttonSubmit.Enabled = false;
        }

        private async void buttonForecast_Click_1(object sender, EventArgs e)
        {
            DateTime selectedDate = datePickerArrival.Value.Date;
            TimeSpan selectedTime = timePickerArrival.Value.TimeOfDay;
            DateTime selectedDateTime = selectedDate + selectedTime;

            string forecast = await GetWeatherForecastAsync(selectedDateTime);
            labelWeather.Text = forecast;
        }

        private async Task<string> GetWeatherForecastAsync(DateTime dateTime)
        {
            string apiUrl = $"http://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location}&dt={dateTime.ToString("yyyy-MM-dd")}&lang=pl";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);//dodac obsluge bledu
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json);

                    JArray forecastArray = (JArray)data["forecast"]["forecastday"];
                    if (forecastArray.Count == 0)
                    {
                        return "Brak informacji o pogodzie dla\nwybranego dnia i godziny";
                    }

                    foreach (var item in forecastArray[0]["hour"])
                    {
                        DateTime forecastDateTime = DateTime.Parse(item["time"].ToString(), CultureInfo.InvariantCulture);
                        if (forecastDateTime.Date == dateTime.Date && forecastDateTime.Hour == dateTime.Hour)
                        {
                            double temp = item["temp_c"].ToObject<double>();
                            string weatherDescription = item["condition"]["text"].ToString().Trim();

                            weatherIsOk = weatherDescription == "Słonecznie" || weatherDescription == "Bezchmurnie" || weatherDescription == "Częściowe zachmurzenie";
                            if (weatherIsOk)
                            {
                                buttonSubmit.Enabled = true;
                            }

                            return $"Temperatura: {temp}°C\nPogoda: {weatherDescription}";
                        }
                    }
                    return "Brak prognozy dla wybranego czasu.";
                }
                else
                {
                    return "Błąd podczas pobierania danych pogodowych.";
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            DateTime arrival = datePickerArrival.Value.Date + timePickerArrival.Value.TimeOfDay;
            DateTime departure = datePickerDeparture.Value.Date + timePickerDeparture.Value.TimeOfDay;

            DateSelected?.Invoke(this, new DateSelectedEventArgs { Arrival = arrival, Departure = departure });

            this.Close();


            this.Close();
        }
        private bool ValidateData()
        {

            DateTime arrival = datePickerArrival.Value.Date + timePickerArrival.Value.TimeOfDay;
            DateTime departure = datePickerDeparture.Value.Date + timePickerDeparture.Value.TimeOfDay;

            //airplaneID musi byc przekazywane w formflights do DatePanel jako parametr 

            if (arrival >= departure)
            {
                MessageBox.Show("Przylot musi być wcześniejszy niż odlot.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int minimumGroundTime = GetMinimumGroundTime(airplaneID);
            if ((departure - arrival).TotalMinutes < minimumGroundTime)
            {
                MessageBox.Show($"Minimalny czas postuju dla tego samolotu wynosi: {minimumGroundTime} minut.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((departure - arrival).TotalMinutes > minimumGroundTime * 3)
            {
                MessageBox.Show($"Maksymalny czas postoju dla tego samoloty wynosi: {minimumGroundTime * 3} minut");
                return false;
            }
            return true;
        }
        private int GetMinimumGroundTime(int airplaneID)
        {
            string query = @"
                SELECT gt.Minimum_GroundTime 
                FROM airplane_models am
                INNER JOIN ground_times gt ON am.GroundTime_ID = gt.ID
                INNER JOIN airplanes a ON am.ID = a.Airplane_Model_ID
                WHERE a.ID = @AirplaneID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AirplaneID", airplaneID);
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        private void labelWeatherOK_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTime_ValueChanged(object sender, EventArgs e)
        {
            ResetWeather();
        }

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            ResetWeather();
        }
        
        private void ResetWeather()
        {
            weatherIsOk = false;
            buttonSubmit.Enabled = false;
            labelWeatherStatus.Text = string.Empty;
            labelWeather.Text = string.Empty;
        }
    }

    public class DateSelectedEventArgs : EventArgs
    {
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }
}
