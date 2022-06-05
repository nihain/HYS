using System;
using System.Collections.Generic;
using System.Data;
using HospitalLibrary.Models;

namespace HospitalLibrary.DataConnections
{
    public interface IDataConnection
    {
        void CreateDoctorProfile(DoctorModel model);

        void CreatePatientProfile(PatientModel model);

        bool DoctorLoginCheck(DoctorModel model);

        bool PatientLoginCheck(PatientModel model);

        void DoctorLogin(DoctorModel model);

        void PatientLogin(PatientModel model);

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
        
        DataTable AllAppointments_GetByDoctor(int doctorId);
        
        DataTable PastAppointments_GetByDoctor(int doctorId);
        
        DataTable UpcomingAppointments_GetByDoctor(int doctorId);

        List<int> HospitalDataCount();
        
        DataTable AllAppointments();
        
        DataTable AllDoctors();
        
        DataTable AllPatients();

        void AdminDeleteAppointment(int id);
        
        void AdminDeleteDoctor(int id);
        
        void AdminDeletePatient(int id);
    }
}