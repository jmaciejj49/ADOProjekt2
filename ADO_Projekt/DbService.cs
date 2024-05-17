using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Windows.Forms;

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

            try
            {
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                int updatedRows = adapter.Update(dataSet, dataTable);
                if (updatedRows == 0)
                {
                    MessageBox.Show("No rows were updated."); // Możesz to zamienić na MessageBox w przypadku aplikacji WinForms
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message); // Analogicznie, użyj MessageBox w WinForms
            }
        }
    }

}
