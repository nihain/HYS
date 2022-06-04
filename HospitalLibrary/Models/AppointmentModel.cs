using System;

namespace HospitalLibrary.Models
{
    public class AppointmentModel
    {
        /// <summary>
        /// The unique identifier of the appointment.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Patient's ID.
        /// </summary>
        public int PatientId { get; set; }
        
        /// <summary>
        /// Doctor's ID.
        /// </summary>
        public int DoctorId { get; set; }
        
        /// <summary>
        /// Appointment's date.
        /// </summary>
        public DateTime Date { get; set; }

        public AppointmentModel()
        {
            
        }

        public AppointmentModel(int patientId, int doctorId, DateTime date)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            Date = date;
        }
    }
}