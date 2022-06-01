using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTracker
{
    public class PatientModel
    {
        /// <summary>
        /// Patient's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Patient's surname.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Patient's gender.
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// Patient's ID number.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Patient's email address
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Patient's password.
        /// </summary>
        public string Password { get; set; }
    }
}
