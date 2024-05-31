using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Projekt
{
    public class Helper
    {
        public bool DataSetHasEmptyFields(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                        continue;

                    foreach (DataColumn column in table.Columns)
                    {
                        var value = row[column];
                        if (value == DBNull.Value || String.IsNullOrWhiteSpace(value.ToString()))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
