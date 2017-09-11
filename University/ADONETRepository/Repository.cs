using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADONETRepository
{
    public class Repository
    {
        private SqlConnection _sqlConnection;

        private SqlCommand _sqlCommand;
        //TODO: Can be read only
        string connectionString = ConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;
        //TODO: Naming convention
        public void Insert(string StoredProcedureName, params object[] paObjects)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(StoredProcedureName, _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };


                foreach (var parameter in paObjects)
                {
                    _sqlCommand.Parameters.Add(parameter);
                }

                _sqlCommand.ExecuteNonQuery();
            }
        }
    }
}