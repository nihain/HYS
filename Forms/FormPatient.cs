using System;
using System.Windows.Forms;
using HospitalLibrary;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    public partial class FormPatient : Form
    {
        private int _filter;
        public PatientModel Model;
        private readonly FormLoginRegister _previousForm;
        
        public FormPatient(FormLoginRegister previousForm, PatientModel patientModel)
        {
            InitializeComponent();

            _previousForm = previousForm;
            Model = patientModel;
            
            dataGridView1.DataSource = GlobalConfig.Connection.AllAppointments_GetByPatient(Model.Id);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            InitializeLabels();
        }

        public void InitializeLabels()
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
            _previousForm.Show();
        }

        // I am sorry for this spaghetti. Winforms doesn't allow custom buttons.
        //TODO: Make a transparent pictureBox overlay and just use its event handler.
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
            FormAppointment af = new FormAppointment(Model.Id, this);
            af.Show();
        }

        private void buttonGridAll_Click(object sender, EventArgs e)
        {
            labelAppointmentsFilter.Text = "Tüm Randevular";
            dataGridView1.DataSource = GlobalConfig.Connection.AllAppointments_GetByPatient(Model.Id);
            dataGridView1.ClearSelection();
            _filter = 0;
        }

        private void buttonGridPast_Click(object sender, EventArgs e)
        {
            labelAppointmentsFilter.Text = "Geçmiş Randevular";
            dataGridView1.DataSource = GlobalConfig.Connection.PastAppointments_GetByPatient(Model.Id);
            dataGridView1.ClearSelection();
            _filter = 1;
        }

        private void buttonGridUpcoming_Click(object sender, EventArgs e)
        {
            labelAppointmentsFilter.Text = "Gelecek Randevular";
            dataGridView1.DataSource = GlobalConfig.Connection.UpcomingAppointments_GetByPatient(Model.Id);
            dataGridView1.ClearSelection();
            _filter = 2;
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        // Spaghetti Winforms doesn't allow custom buttons yadda yadda yadda...
        private void labelDeleteAppointment_Click(object sender, EventArgs e)
        {
            DeleteAppointment();
        }
        private void pictureBoxDeleteAppointment_Click(object sender, EventArgs e)
        {
            DeleteAppointment();
        }
        private void panelDeleteAppointment_Click(object sender, EventArgs e)
        {
            DeleteAppointment();
        }
        void DeleteAppointment()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen aşağıdan bir randevu seçin!");
                return;
            }

            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                GlobalConfig.Connection.DeleteAppointment(Model.Id, Convert.ToDateTime(r.Cells[3].Value));
            }

            ReloadGrid();
            MessageBox.Show("Randevu(lar) başarıyla silindi!");
        }

        public void ReloadGrid()
        {
            switch (_filter)
            {
                case 0:
                    dataGridView1.DataSource = GlobalConfig.Connection.AllAppointments_GetByPatient(Model.Id);
                    dataGridView1.ClearSelection();
                    break;
                case 1:
                    dataGridView1.DataSource = GlobalConfig.Connection.PastAppointments_GetByPatient(Model.Id);
                    dataGridView1.ClearSelection();
                    break;
                case 2:
                    dataGridView1.DataSource = GlobalConfig.Connection.UpcomingAppointments_GetByPatient(Model.Id);
                    dataGridView1.ClearSelection();
                    break;
            }
        }

        // SPAGHETTI
        private void labelEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile();
        }
        private void pictureBoxEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile();
        }
        private void panelEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile();
        }
        void EditProfile()
        {
            FormEditProfile ef = new FormEditProfile(false, null, Model, null, this);
            ef.Show();
        }
    }
}