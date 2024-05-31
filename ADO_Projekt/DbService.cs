using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Text;

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

    public void UpdateData(DataSet dataSet, string tableName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string selectQuery = $"SELECT * FROM {tableName}";

            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable table = dataSet.Tables[tableName];

            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();

            adapter.Update(dataSet, tableName);
            MessageBox.Show("Żądanie zostało wysłane");
            dataSet.AcceptChanges();
        }
    }


}
