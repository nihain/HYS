using HospitalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.DataConnections
{
    public class SqlConnection : IDataConnection
    {
        // TODO: Properly implement database saves
        /// <summary>
        /// Saves a new doctor profile to database.
        /// </summary>
        /// <param name="model">Doctor information.</param>
        /// <returns>Doctor information, including the unique identifier.</returns>
        public DoctorModel CreateDoctor(DoctorModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
