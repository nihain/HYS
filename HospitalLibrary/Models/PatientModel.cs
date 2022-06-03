using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Models
{
    public class PatientModel
    {
        /// <summary>
        /// The unique identifier for the patient.
        /// </summary>
        public int Id { get; set; }

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
        public string TCid { get; set; }

        /// <summary>
        /// Patient's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Patient's password.
        /// </summary>
        public string Password { get; set; }
    }
}
