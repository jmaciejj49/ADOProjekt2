using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if ((departure - arrival).TotalMinutes < minimumGroundTime) //Minimalny czas postosju samolotu
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

        public bool ValidateRunwayData(DateTime startsAt, DateTime endsAt, bool isActive)
        {
            if (startsAt > endsAt)
            {
                MessageBox.Show("Blomnt");
                return false;
            }
            //sprawdzic czy w tym okresie nie ma zaplanowanego lotu
                //1. stworzyc widok albo query ktore pobiera date poczatkowo i koncowa.
                //2. patrzy czy w tym zakresie dat jest lot ktory jest zaplanowany

            return true;
        }
    }
}
