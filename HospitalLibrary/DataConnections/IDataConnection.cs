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
    }
}