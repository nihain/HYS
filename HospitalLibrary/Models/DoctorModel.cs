namespace HospitalLibrary.Models
{
    public class DoctorModel
    {
        /// <summary>
        /// The unique identifier of the doctor.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Doctor's name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Doctor's surname.
        /// </summary>
        public string Surname { get; set; }
        
        /// <summary>
        /// Doctor's ID number.
        /// </summary>
        public string TcId { get; set; }
        
        /// <summary>
        /// Doctor's branch.
        /// </summary>
        public string Branch { get; set; }
        
        /// <summary>
        /// Doctor's password.
        /// </summary>
        public string Password { get; set; }

        public DoctorModel()
        {
            
        }

        public DoctorModel(string name, string surname, string tcId, string branch, string password)
        {
            Name = name;
            Surname = surname;
            TcId = tcId;
            Branch = branch;
            Password = password;
        }
    }
}