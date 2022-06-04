using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using HospitalLibrary.Models;

namespace HospitalLibrary.DataConnections
{
    public class SqlConnection : IDataConnection
    {
        private const string Db = "Hospital";
        
        /// <summary>
        /// Saves a new doctor profile to database.
        /// </summary>
        /// <param name="model">Doctor information.</param>
        /// <returns>Doctor information, including the unique identifier.</returns>
        public DoctorModel CreateDoctorProfile(DoctorModel model)
        {
            // Basically SqlConnection.Open() and SqlConnection.Close() in one block.
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@Surname", model.Surname);
                p.Add("@TcId", model.TcId);
                p.Add("@Branch", model.Branch);
                p.Add("@Password", model.Password);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                // You have to set the property CommandType for the Command to StoredProcedure if your procedure
                // uses parameters. Otherwise it won't detect them.
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
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
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

        public bool DoctorLoginCheck(DoctorModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@TcId", model.TcId);
                p.Add("@Password", model.Password);

                var reader =
                    connection.ExecuteReader("dbo.spDoctors_Login", p, commandType: CommandType.StoredProcedure);

                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool PatientLoginCheck(PatientModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@TcId", model.TcId);
                p.Add("@Password", model.Password);

                var reader =
                    connection.ExecuteReader("dbo.spPatients_Login", p, commandType: CommandType.StoredProcedure);

                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DoctorModel DoctorLogin(DoctorModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@TcId", model.TcId);
                p.Add("@Password", model.Password);

                var reader =
                    connection.ExecuteReader("dbo.spDoctors_Login", p, commandType: CommandType.StoredProcedure);

                while (reader.Read())
                {
                    model.Id = Convert.ToInt32(reader[0]);
                    model.Name = reader[1].ToString();
                    model.Surname = reader[2].ToString();
                    model.Branch = reader[4].ToString();
                    model.CreateDate = Convert.ToDateTime(reader[6]);
                }
            }

            return model;
        }

        public PatientModel PatientLogin(PatientModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@TcId", model.TcId);
                p.Add("@Password", model.Password);

                var reader =
                    connection.ExecuteReader("dbo.spPatients_Login", p, commandType: CommandType.StoredProcedure);

                while (reader.Read())
                {
                    model.Id = Convert.ToInt32(reader[0]);
                    model.Name = reader[1].ToString();
                    model.Surname = reader[2].ToString();
                    model.Gender = Convert.ToBoolean(reader[4]);
                    model.CreateDate = Convert.ToDateTime(reader[6]);
                }
            }

            return model;
        }

        public List<string> GetDoctorBranches()
        {
            List<string> output;

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                output = connection.Query<string>("dbo.spDoctors_GetBranches").ToList();
            }

            return output;
        }

        public List<DoctorModel> GetDoctorByBranch(string branch)
        {
            List<DoctorModel> output;

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@Branch", branch);
                
                output = connection.Query<DoctorModel>("dbo.spDoctors_GetByBranch", p,
                    commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public void CreateAppointment(AppointmentModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@PatientID", model.PatientId);
                p.Add("@DoctorID", model.DoctorId);
                p.Add("@Date", model.Date);

                connection.Execute("dbo.spAppointments_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public bool CheckAppointmentOverlap(AppointmentModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@PatientID", model.PatientId);
                p.Add("@DoctorID", model.DoctorId);
                p.Add("@Date", model.Date);

                var reader =
                    connection.ExecuteReader("dbo.spAppointments_GetOverlap", p,
                        commandType: CommandType.StoredProcedure);

                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}