using System;
using System.Windows.Forms;
using HospitalLibrary;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    public partial class FormDoctor : Form
    {
        private readonly FormLoginRegister _previousForm;
        public DoctorModel Model;
        
        public FormDoctor(DoctorModel model, FormLoginRegister previousForm)
        {
            InitializeComponent();

            _previousForm = previousForm;
            Model = model;

            dataGridView1.DataSource = GlobalConfig.Connection.AllAppointments_GetByDoctor(Model.Id);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
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
            dataGridView1.ClearSelection();
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            FormEditProfile ef = new FormEditProfile(
                true,
                Model,
                null,
                this,
                null);
            ef.Show();
        }

        private void buttonGridAll_Click(object sender, EventArgs e)
        {
            labelAppointmentsFilter.Text = "Tüm Randevular";
            dataGridView1.DataSource = GlobalConfig.Connection.AllAppointments_GetByDoctor(Model.Id);
            dataGridView1.ClearSelection();
        }

        private void buttonGridPast_Click(object sender, EventArgs e)
        {
            labelAppointmentsFilter.Text = "Geçmiş Randevular";
            dataGridView1.DataSource = GlobalConfig.Connection.PastAppointments_GetByDoctor(Model.Id);
            dataGridView1.ClearSelection();
        }

        private void buttonGridUpcoming_Click(object sender, EventArgs e)
        {
            labelAppointmentsFilter.Text = "Gelecek Randevular";
            dataGridView1.DataSource = GlobalConfig.Connection.UpcomingAppointments_GetByDoctor(Model.Id);
            dataGridView1.ClearSelection();
        }
    }
}
