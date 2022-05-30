using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTracker
{
    public class DoctorModel
    {
        /// <summary>
        /// Doctor's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Doctor's surname.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Doctor's ID number.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Doctor's branch.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Doctor's email address.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Doctor's password.
        /// </summary>
        public string Password { get; set; }
    }
}
