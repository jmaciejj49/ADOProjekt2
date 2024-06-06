using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class FlightsPopup : Form
    {
        public event EventHandler<DateSelectedEventArgs> DateSelected;
        private string apiKey = "57e179d3b5cd4769aa2155701243105";
        private string location = "Choroszcz";
        private bool weatherIsOk;
        private int airplaneID;
        DBHelper dbHelper = new DBHelper();
        DataHelper dataHelper = new DataHelper();

        public FlightsPopup(int airplaneID, DateTime dateToDisplay = default(DateTime))
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
                HttpResponseMessage response = await client.GetAsync(apiUrl);
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
                                labelStatus.Text = "Przylot możliwy";
                            }
                            else
                            {
                                labelStatus.Text = "Przylot niemożliwy";
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
            DateTime arrival = datePickerArrival.Value.Date + timePickerArrival.Value.TimeOfDay;
            DateTime departure = datePickerDeparture.Value.Date + timePickerDeparture.Value.TimeOfDay;
            DateSelectedEventArgs arguments = new DateSelectedEventArgs { Arrival = arrival, Departure = departure };

            if (!dataHelper.ValidateFlightData(arrival,departure,airplaneID))
            {
                return;
            }
            if (!dbHelper.GetRunwayStatus(arrival, departure))
            {
                MessageBox.Show("W wybranym terminie pas startowy jest niedostępny");
                return;
            }
            if (dbHelper.IsAirplaneAlreadyScheduled(arrival, departure, airplaneID))
            {
                MessageBox.Show("Samolot ma już zaplanowany przylot w wybranym okresie. Minimalny bufor czasu wynosi 2h!");
                return;
            }
            if(dbHelper.IsApronAlreadyScheduled(arrival, departure))
            {
                MessageBox.Show("W wybranym okresie płyta postojowa jest już zajęta przez inny samolot. Wybierz inny termin.");
                return;
            }
            DateSelected?.Invoke(this, arguments);
            this.Close();
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
            DateTime newDate = datePickerArrival.Value.Date;
            datePickerDeparture.MaxDate = datePickerArrival.MaxDate;
            datePickerDeparture.MinDate = newDate;
            datePickerDeparture.MaxDate = (newDate.AddDays(1) <= datePickerArrival.MaxDate) ? newDate.AddDays(1) : datePickerArrival.MaxDate;
            datePickerDeparture.Value = newDate.AddHours(1);

            ResetWeather();
        }
        
        private void ResetWeather()
        {
            weatherIsOk = false;
            buttonSubmit.Enabled = false;
            labelStatus.Text = string.Empty;
            labelWeather.Text = string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class DateSelectedEventArgs : EventArgs
    {
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }
}
