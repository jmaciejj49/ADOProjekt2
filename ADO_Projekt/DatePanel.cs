using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class DatePanel : Form
    {
        public event EventHandler<DateSelectedEventArgs> DateSelected;
        private string apiKey = "bab8ee939e4f449c89d190415241605";
        private string location = "Choroszcz";
        private bool weatherIsOk;
        private string operation;

        public DatePanel(string operation, DateTime dateToDisplay = default(DateTime))
        {
            InitializeComponent();
            this.operation = operation;

            if (dateToDisplay == default(DateTime))
            {
                dateToDisplay = DateTime.Now.AddDays(1);
            }

            dateTimePickerDate.Value = dateToDisplay.Date;
            dateTimePickerDate.MinDate = dateToDisplay.Date;
            dateTimePickerDate.MaxDate = dateToDisplay.Date.AddDays(14);
            dateTimePickerTime.Value = DateTimePickerTime(dateToDisplay.TimeOfDay);
        }

        private DateTime DateTimePickerTime(TimeSpan timeOfDay)
        {
            DateTime currentTime = DateTime.Now;
            return new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, timeOfDay.Hours, timeOfDay.Minutes, timeOfDay.Seconds);
        }

        private void DatePanel_Load(object sender, EventArgs e)
        {
            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.CustomFormat = "HH:mm";
            labelOperation.Text = operation;
            buttonSubmit.Visible = false;
        }

        private async void buttonForecast_Click_1(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePickerDate.Value.Date;
            TimeSpan selectedTime = dateTimePickerTime.Value.TimeOfDay;
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
                                labelWeatherStatus.Text = $"{operation} możliwy";
                                buttonSubmit.Visible = true;
                            }
                            else
                            {
                                labelWeatherStatus.Text = $"{operation} niemożliwy";
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
            DateTime selectedDate = dateTimePickerDate.Value.Date;
            TimeSpan selectedTime = dateTimePickerTime.Value.TimeOfDay;
            DateTime selectedDateTime = selectedDate + selectedTime;

            DateSelected?.Invoke(this, new DateSelectedEventArgs { SelectedDateTime = selectedDateTime });

            this.Close();
        }

        private void labelWeatherOK_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTime_ValueChanged(object sender, EventArgs e)
        {
            resetWeather();
        }

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            resetWeather();
        }
        
        private void resetWeather()
        {
            weatherIsOk = false;
            buttonSubmit.Visible = false;
            labelWeatherStatus.Text = string.Empty;
            labelWeather.Text = string.Empty;
        }
    }

    public class DateSelectedEventArgs : EventArgs
    {
        public DateTime SelectedDateTime { get; set; }
    }
}
