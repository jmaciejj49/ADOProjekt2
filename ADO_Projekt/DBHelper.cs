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
    }
}
