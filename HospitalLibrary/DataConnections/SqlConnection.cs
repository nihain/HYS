using System.Data;
using Dapper;
using HospitalLibrary.Models;

namespace HospitalLibrary.DataConnections
{
    public class SqlConnection : IDataConnection
    {
        /// <summary>
        /// Saves a new doctor profile to database.
        /// </summary>
        /// <param name="model">Doctor information.</param>
        /// <returns>Doctor information, including the unique identifier.</returns>
        public DoctorModel CreateDoctorProfile(DoctorModel model)
        {
            // Basically SqlConnection.Open() and SqlConnection.Close() in one block.
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hospital")))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@Surname", model.Surname);
                p.Add("@TcId", model.TcId);
                p.Add("@Branch", model.Branch);
                p.Add("@Password", model.Password);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                connection.Execute("dbo.spDoctors_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        /// <summary>
        /// Saves a new patient profile to database.
        /// </summary>
        /// <param name="model">Patient information.</param>
        /// <returns>Patient information, including the unique identifier.</returns>
        public PatientModel CreatePatientProfile(PatientModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hospital")))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@Surname", model.Surname);
                p.Add("@TcId", model.TcId);
                p.Add("@Gender", model.Gender);
                p.Add("@Password", model.Password);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                connection.Execute("dbo.spPatients_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }
    }
}