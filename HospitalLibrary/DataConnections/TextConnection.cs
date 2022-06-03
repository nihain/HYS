using HospitalLibrary.Models;

namespace HospitalLibrary.DataConnections
{
    public class TextConnection : IDataConnection
    {
        /// <summary>
        /// Saves a new doctor profile to text file.
        /// </summary>
        /// <param name="model">Doctor information.</param>
        /// <returns>Doctor information, including the unique identifier.</returns>
        public DoctorModel CreateDoctorProfile(DoctorModel model)
        {
            //TODO: Implement text file saves
            
            model.Id = 1;

            return model;
        }
    }
}