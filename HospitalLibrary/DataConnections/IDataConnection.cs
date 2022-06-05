using System;
using System.Collections.Generic;
using System.Data;
using HospitalLibrary.Models;

namespace HospitalLibrary.DataConnections
{
    public interface IDataConnection
    {
        DoctorModel CreateDoctorProfile(DoctorModel model);

        PatientModel CreatePatientProfile(PatientModel model);

        bool DoctorLoginCheck(DoctorModel model);

        bool PatientLoginCheck(PatientModel model);

        DoctorModel DoctorLogin(DoctorModel model);

        PatientModel PatientLogin(PatientModel model);

        List<string> GetDoctorBranches();

        List<DoctorModel> GetDoctorByBranch(string branch);

        void CreateAppointment(AppointmentModel model);

        bool CheckAppointmentOverlap(AppointmentModel model);

        DataTable AllAppointments_GetByPatient(int patientId);
        
        DataTable PastAppointments_GetByPatient(int patientId);
        
        DataTable UpcomingAppointments_GetByPatient(int patientId);

        void DeleteAppointment(int patientId, DateTime date);

        void UpdateDoctorProfile(bool mode, DoctorModel model);

        void UpdatePatientProfile(bool mode, PatientModel model);
    }
}