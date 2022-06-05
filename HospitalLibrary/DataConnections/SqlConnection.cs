using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public void CreateDoctorProfile(DoctorModel model)
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
            }
        }

        /// <summary>
        /// Saves a new patient profile to database.
        /// </summary>
        /// <param name="model">Patient information.</param>
        /// <returns>Patient information, including the unique identifier.</returns>
        public void CreatePatientProfile(PatientModel model)
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

        public void DoctorLogin(DoctorModel model)
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
        }

        public void PatientLogin(PatientModel model)
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

        public DataTable AllAppointments_GetByPatient(int patientId)
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spAllAppointments_GetByPatient",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@PatientID", patientId));
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable PastAppointments_GetByPatient(int patientId)
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spPastAppointments_GetByPatient",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@PatientID", patientId));
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable UpcomingAppointments_GetByPatient(int patientId)
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spUpcomingAppointments_GetByPatient",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@PatientID", patientId));
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public void DeleteAppointment(int patientId, DateTime date)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@PatientID", patientId);
                p.Add("@Date", date);

                connection.Execute("dbo.spAppointments_Delete", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateDoctorProfile(bool mode, DoctorModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", model.Id);
                p.Add("@Name", model.Name);
                p.Add("@Surname", model.Surname);
                p.Add("@TcId", model.TcId);
                p.Add("@Branch", model.Branch);
                if (mode)
                {
                    p.Add("@Password", model.Password);
                }

                connection.Execute("dbo.spDoctors_Update", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePatientProfile(bool mode, PatientModel model)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", model.Id);
                p.Add("@Name", model.Name);
                p.Add("@Surname", model.Surname);
                p.Add("@TcId", model.TcId);
                p.Add("@Gender", model.Gender);
                if (mode)
                {
                    p.Add("@Password", model.Password);
                }

                connection.Execute("dbo.spPatients_Update", p, commandType: CommandType.StoredProcedure);
            }
        }

        public DataTable AllAppointments_GetByDoctor(int doctorId)
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spAllAppointments_GetByDoctor",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@DoctorID", doctorId));
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable PastAppointments_GetByDoctor(int doctorId)
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spPastAppointments_GetByDoctor",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@DoctorID", doctorId));
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable UpcomingAppointments_GetByDoctor(int doctorId)
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spUpcomingAppointments_GetByDoctor",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@DoctorID", doctorId));
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public List<int> HospitalDataCount()
        {
            List<int> output;

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                output = connection.Query<int>("dbo.spHospital_GetCount").ToList();
            }

            return output;
        }

        public DataTable AllAppointments()
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spAllAppointments",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable AllDoctors()
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spAllDoctors",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable AllPatients()
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                SqlCommand command = new SqlCommand("spAllPatients",
                    (System.Data.SqlClient.SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                
                var da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public void AdminDeleteAppointment(int id)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", id);

                connection.Execute("dbo.spAdminDelete_Appointment", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void AdminDeleteDoctor(int id)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", id);

                connection.Execute("dbo.spAdminDelete_Doctor", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void AdminDeletePatient(int id)
        {
            using (IDbConnection connection =
                   new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", id);

                connection.Execute("dbo.spAdminDelete_Patient", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}