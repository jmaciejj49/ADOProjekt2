using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Projekt
{
    public class DBHelper
    {
        private readonly DBService dbService = new DBService();
        public int GetMinimumGroundTime(int airplaneID)
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

        public (bool? isActive, DateTime? endDate) GetRunwayStatus()
        {
            string query = @"
                SELECT TOP 1 Active, TimeTo
                FROM runway_schedule
                WHERE TimeFrom <= GETDATE() AND TimeTo >= GETDATE()
                ORDER BY TimeTo DESC;";

            DataSet dataSet = dbService.LoadData(query, "RunwayStatus");

            if (dataSet.Tables["RunwayStatus"].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables["RunwayStatus"].Rows[0];
                bool? isActive = row["Active"] as bool?;
                DateTime? endDate = row["TimeTo"] as DateTime?;

                return (isActive, endDate);
            }

            return (null, null);
        }
        public bool GetRunwayStatus(DateTime arrival, DateTime departure)
        {
            string query = @"
            SELECT COUNT(*)
            FROM runway_schedule
            WHERE NOT (TimeTo < @Arrival OR TimeFrom > @Departure)
            AND Active = 1;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Arrival", arrival);
                    command.Parameters.AddWithValue("@Departure", departure);
                    connection.Open();
                    int activeCount = (int)command.ExecuteScalar();
                    return activeCount > 0; 
                }
            }
        }

        public bool RunwayStatusDateTaken(DateTime startsAt, DateTime endsAt, int scheduleEntityID)
        {
            string query = @"
                SELECT COUNT(*)
                FROM runway_schedule
                WHERE NOT (TimeTo <= @StartsAt OR TimeFrom >= @EndsAt)
                AND ID <> @ScheduleEntityID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartsAt", startsAt);
                    command.Parameters.AddWithValue("@EndsAt", endsAt);
                    command.Parameters.AddWithValue("@ScheduleEntityID", scheduleEntityID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        public bool RunwayStatusDateTaken(DateTime startsAt, DateTime endsAt)
        {
            string query = @"
                SELECT COUNT(*)
                FROM runway_schedule
                WHERE NOT (TimeTo <= @StartsAt OR TimeFrom >= @EndsAt);";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartsAt", startsAt);
                    command.Parameters.AddWithValue("@EndsAt", endsAt);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
        }
        public bool FlightScheduleDateTaken(DateTime startsAt, DateTime endsAt)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM flights 
                WHERE (Arrival BETWEEN @StartsAt AND @EndsAt) 
                OR (Departure BETWEEN @StartsAt AND @EndsAt)
                AND Status_ID = 1;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartsAt", startsAt);
                    command.Parameters.AddWithValue("@EndsAt", endsAt);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0; 
                }
            }
        }

        public bool IsAirplaneAlreadyScheduled(DateTime arrival, DateTime departure, int airplaneID)
        {
            string query = @"
            SELECT COUNT(*)
            FROM flights
            WHERE Airplane_ID = @AirplaneID
            AND (
                (Arrival BETWEEN DATEADD(HOUR, -2, @Arrival) AND DATEADD(HOUR, 2, @Departure))
                OR
                (Departure BETWEEN DATEADD(HOUR, -2, @Arrival) AND DATEADD(HOUR, 2, @Departure))
            );";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AirplaneID", airplaneID);
                    command.Parameters.AddWithValue("@Arrival", arrival);
                    command.Parameters.AddWithValue("@Departure", departure);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool IsApronAlreadyScheduled(DateTime arrival, DateTime departure)
        {
            string query = @"
                SELECT COUNT(*)
                FROM flights
                WHERE (Arrival BETWEEN @BufferedArrivalStart AND @BufferedDepartureEnd
                OR Departure BETWEEN @BufferedArrivalStart AND @BufferedDepartureEnd)
                AND Status_ID = 1;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BufferedArrivalStart", arrival.AddMinutes(-5));
                    command.Parameters.AddWithValue("@BufferedDepartureEnd", departure.AddMinutes(5));
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public (bool? isEmpty, DateTime? endDate) getApronStatus()
        {
            string query = @"
                SELECT TOP 1 Arrival, Departure
                FROM flights
                WHERE Arrival <= GETDATE() AND Departure >= GETDATE()
                ORDER BY Departure ASC;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime endDate = reader.GetDateTime(reader.GetOrdinal("Departure"));
                            return (false, endDate);
                        }
                    }
                }
                query = @"
                    SELECT MIN(Arrival)
                    FROM flights
                    WHERE Arrival > GETDATE();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        DateTime nextArrival = (DateTime)result;
                        return (true, nextArrival);
                    }
                    else
                    {
                        return (true, null);
                    }
                }
            }
        }



    }
}
