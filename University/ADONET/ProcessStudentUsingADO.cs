using Interfaces;
using Entities;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADONET
{
    public class ProcessStudentUsingADO : IADOStudentData
    {
        private SqlConnection _sqlConnection;

        private SqlCommand _sqlCommand;

        private SqlDataAdapter _sqlDataAdapter;

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        public string GetBestStudent(string University)
        {
            string bestStudent = null;

            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("usp_GetUniversityBestStudent", _sqlConnection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@UniversityName", SqlDbType.NVarChar).Value = University;
                _sqlDataAdapter = new SqlDataAdapter();
                _sqlDataAdapter.SelectCommand = _sqlCommand;
                var datatable = new DataTable();

                _sqlDataAdapter.Fill(datatable);

                bestStudent = datatable.ToString();
            }

            return bestStudent;
        }

        public void InsertStudent(Student student)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("[usp_InsertStudents]", _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = student.StudentName;
                _sqlCommand.Parameters.Add("@UniversityName", SqlDbType.NVarChar).Value = student.University.UniversityName;
                _sqlCommand.Parameters.Add("@SemisterName", SqlDbType.NVarChar).Value = student.Semister.SemisterName;

                _sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("[usp_UpdateStudentDetails]", _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = student.StudentName;
                _sqlCommand.Parameters.Add("@UniversityName", SqlDbType.NVarChar).Value = student.University.UniversityName;
                _sqlCommand.Parameters.Add("@SemisterName", SqlDbType.NVarChar).Value = student.Semister.SemisterName;

                _sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("[usp_DeleteStudent]", _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = student.StudentName;

                _sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateStudentSemister(Student student)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("[usp_UpdateStudentSemister]", _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = student.StudentName;
                _sqlCommand.Parameters.Add("@newSemisterName", SqlDbType.NVarChar).Value = student.Semister.SemisterName;

                _sqlCommand.ExecuteNonQuery();
            }
        }
    }
}