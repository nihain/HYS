using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Models
{
    public class DoctorModel
    {
        /// <summary>
        /// The unique identifier for the doctor.
        /// </summary>
        public int Id { get; set; }

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
        public string TCid { get; set; }

        /// <summary>
        /// Doctor's branch.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Doctor's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Doctor's password.
        /// </summary>
        public string Password { get; set; }

        public DoctorModel()
        {

        }

        public DoctorModel(string firstName, string lastName, string tcid, string branch, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            TCid = tcid;
            Branch = branch;
            Password = password;
        }
    }
}
