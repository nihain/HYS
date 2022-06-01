using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class HospitalModel
    {
        /// <summary>
        /// Represents the list of doctors registered to the hospital.
        /// </summary>
        public List<DoctorModel> Doctors { get; set; } = new List<DoctorModel>();

        /// <summary>
        /// Represents the list of patients registered to the hospital.
        /// </summary>
        public List<PatientModel> Patients { get; set; } = new List<PatientModel>();

        /// <summary>
        /// Represents the list of all appointments.
        /// </summary>
        public List<AppointmentModel> Appointments { get; set; } = new List<AppointmentModel>();
    }
}
