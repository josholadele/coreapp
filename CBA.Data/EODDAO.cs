using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class EODDAO:BaseDAO<EOD>
    {
        public void UpdateEOD(EOD eod)
        {
            Database database = new Database();
           SqlConnection connection = database.connection;
            
            string query = "UPDATE dbo.[EOD] SET BusinessIsOpen=@BusinessIsOpen, FinancialDate=@FinancialDate where ID=1;";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("BusinessIsOpen",eod.BusinessIsOpen);
            myCommand.Parameters.AddWithValue("FinancialDate", eod.FinancialDate);
            myCommand.ExecuteNonQuery();
            connection.Close();
            //database.connection.Close();
        }
    }
}
