using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Text;

public class DBService
{
    private string connectionString;

    public DBService()
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
            try
            {
                string selectQuery = $"SELECT * FROM {tableName}";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.DeleteCommand = builder.GetDeleteCommand();

                // Aktualizacja bazy danych
                adapter.Update(dataSet, tableName);
                dataSet.AcceptChanges(); 
                MessageBox.Show("Żądanie zostało wysłane");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 515) 
                {
                    MessageBox.Show("Jeden z wierszy ma puste pole, które jest wymagane. Wypełnij wszystkie wymagane pola przed zapisem.", "Błąd wstawiania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wystąpił błąd bazy danych: {ex.Message}", "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
