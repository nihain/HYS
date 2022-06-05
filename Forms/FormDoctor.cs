using System;
using System.Windows.Forms;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    //TODO: create edit profile button
    //TODO: set constructor
    
    public partial class FormDoctor : Form
    {
        private readonly FormLoginRegister _previousForm;
        public DoctorModel Model;
        
        public FormDoctor(DoctorModel model, FormLoginRegister previousForm)
        {
            InitializeComponent();

            _previousForm = previousForm;
            Model = model;
            
            InitializeLabels();
        }

        public void InitializeLabels()
        {
            labelDashDoctorName.Text = Model.Name;
            labelDoctorName.Text = Model.Name;
            labelDoctorSurname.Text = Model.Surname;
            labelDoctorTC.Text = Model.TcId;
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            _previousForm.Show();
        }

        private void FormDoctor_Load(object sender, EventArgs e)
        {

        }
    }
}
