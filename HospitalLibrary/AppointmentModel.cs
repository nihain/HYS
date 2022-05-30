using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTracker
{
    public class AppointmentModel
    {
        /// <summary>
        /// Patient's ID number.
        /// </summary>
        public string PatientID { get; set; }

        /// <summary>
        /// Doctor's ID number.
        /// </summary>
        public string DoctorID { get; set; }

        /// <summary>
        /// The date and time of the appointment.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
