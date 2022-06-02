using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    //TODO: Properly implement text file saves
    /// <summary>
    /// Saves a new doctor profile to text file.
    /// </summary>
    /// <param name="model">The doctor information.</param>
    /// <returns>The doctor information, including the unique identifier.</returns>
    public class TextConnector : IDataConnection
    {
        public DoctorModel CreateDoctor(DoctorModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
