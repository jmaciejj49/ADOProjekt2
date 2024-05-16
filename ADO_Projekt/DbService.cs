using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class DbService
{
    private string connectionString;

    public DbService()
    {
        connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
    }

    public DataSet LoadData(string query, string dataTable)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, dataTable);
            return dataSet;
        }
    }

    public void UpdateData(DataSet dataSet, string query, string dataTable)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet, dataTable);
        }
    }
}
