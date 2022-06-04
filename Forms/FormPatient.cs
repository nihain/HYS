using System;
using System.Windows.Forms;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    public partial class FormPatient : Form
    {
        public FormPatient()
        {
            InitializeComponent();
        }

        public PatientModel Model;
        public FormLoginRegister PreviousForm;

        private void FormPatient_Load(object sender, EventArgs e)
        {
            labelDashPatientName.Text = Model.Name;
            labelPatientName.Text = Model.Name;
            labelPatientSurname.Text = Model.Surname;
            labelPatientTC.Text = Model.TcId;
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreviousForm.Show();
        }
    }
}