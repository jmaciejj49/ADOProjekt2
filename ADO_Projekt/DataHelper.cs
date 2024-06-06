using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ADO_Projekt.RunwayPopup;

namespace ADO_Projekt
{
    public class DataHelper
    {
        DBHelper dbHelper = new DBHelper();
        public bool ValidateFlightData(DateTime arrival, DateTime departure, int airplaneID) //Metoda sprawdzająca poprawność wybranych dat/godzin odlotu i przylotu
        {
            if (arrival >= departure)
            {
                MessageBox.Show("Przylot musi być wcześniejszy niż odlot.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int minimumGroundTime = dbHelper.GetMinimumGroundTime(airplaneID);
            if ((departure - arrival).TotalMinutes < minimumGroundTime) //Minimalny czas postoju samolotu
            {
                MessageBox.Show($"Minimalny czas postuju dla tego samolotu wynosi: {minimumGroundTime} minut.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((departure - arrival).TotalMinutes > minimumGroundTime * 3) //Maksymalny czas postoju samolotu
            {
                MessageBox.Show($"Maksymalny czas postoju dla tego samoloty wynosi: {minimumGroundTime * 3} minut");
                return false;
            }
            return true;
        }

        public bool ValidateRunwayData(RunwayPanelArguments arguments)
        {
            if (arguments.StartsAt > arguments.EndsAt)
            {
                MessageBox.Show("Nieprawidłowy okres czasu");
                return false;
            }
            if((arguments.EndsAt - arguments.StartsAt).TotalMinutes < 60)
            {
                MessageBox.Show("Minimalny czas statusu dla pasa startowego wynosi 1h");
                return false;
            }

            return true;
        }
    }
}
