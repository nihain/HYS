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
        public int Date { get; set; }
    }
}