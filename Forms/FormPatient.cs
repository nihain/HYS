using System;
using System.Windows.Forms;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    public partial class FormPatient : Form
    {
        public FormPatient(PatientModel model, FormLoginRegister previousForm)
        {
            InitializeComponent();

            _model = model;
            _previousForm = previousForm;

            InitializeLabels();
        }

        private readonly PatientModel _model;
        private readonly FormLoginRegister _previousForm;

        private void InitializeLabels()
        {
            labelDashPatientName.Text = _model.Name;
            labelPatientName.Text = _model.Name;
            labelPatientSurname.Text = _model.Surname;
            labelPatientTC.Text = _model.TcId;
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _previousForm.Show();
        }

        // I am sorry for this spaghetti. Winforms doesn't allow custom buttons.
        //TODO: Make a transparent pictureBox overlay and just use its eventHandler.
        private void labelMakeAppointment_Click(object sender, EventArgs e)
        {
            MakeAppointment();
        }
        private void pictureBoxMakeAppointment_Click(object sender, EventArgs e)
        {
            MakeAppointment();
        }
        private void panelMakeAppointment_Click(object sender, EventArgs e)
        {
            MakeAppointment();
        }
        private void MakeAppointment()
        {
            FormAppointment af = new FormAppointment(_model.Id);
            af.Show();
        }
    }
}