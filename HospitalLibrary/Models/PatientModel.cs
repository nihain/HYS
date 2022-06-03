namespace HospitalLibrary.Models
{
    public class PatientModel
    {
        /// <summary>
        /// The unique identifier of the patient.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Patient's name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Patient's surname.
        /// </summary>
        public string Surname { get; set; }
        
        /// <summary>
        /// Patient's ID number.
        /// </summary>
        public string TcId { get; set; }
        
        /// <summary>
        /// Patient's gender.
        /// </summary>
        public bool? Gender { get; set; }
        
        /// <summary>
        /// Patient's password.
        /// </summary>
        public string Password { get; set; }

        public PatientModel()
        {
            
        }

        public PatientModel(string name, string surname, string tcId, bool? gender, string password)
        {
            Name = name;
            Surname = surname;
            TcId = tcId;
            Gender = gender;
            Password = password;
        }
    }
}