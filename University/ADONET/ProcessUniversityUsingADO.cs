using System;
using System.Collections.Generic;
using Interfaces;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace ADONET
{
    public class ProcessUniversityUsingADO : IUniversityService
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        public List<University> GetAll()
        {
            throw new NotImplementedException();
        }

        public University GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(University university)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("[usp_InsertUniversity]", _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.Add("@UniversityName", SqlDbType.NVarChar).Value = university.UniversityName;

                _sqlCommand.ExecuteNonQuery();
            }
        }

        public void Update(University university)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("[usp_UpdateUniversity]", _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.Add("@UniversityName", SqlDbType.NVarChar).Value = university.UniversityName;

                _sqlCommand.ExecuteNonQuery();
            }
        }

        public void Delete(University model)
        {
            using (_sqlConnection = new SqlConnection(connectionString))
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand("[usp_DeleteUniversity]", _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.Add("@UniversityName", SqlDbType.NVarChar).Value = model.UniversityName;

                _sqlCommand.ExecuteNonQuery();
            }
        }
    }
}