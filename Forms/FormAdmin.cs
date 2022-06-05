using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using HospitalLibrary;

namespace HYS.Forms
{
    public partial class FormAdmin : Form
    {
        private readonly FormLoginRegister _previousForm;
        private int _filter;

        public FormAdmin(FormLoginRegister previousForm)
        {
            InitializeComponent();

            _previousForm = previousForm;
            
            dataGridView1.DataSource = GlobalConfig.Connection.AllAppointments();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _filter = 0;
            
            InitializeLabels();
        }

        private void InitializeLabels()
        {
            List<int> tmp = GlobalConfig.Connection.HospitalDataCount();
            labelDoctorCount.Text = tmp[0].ToString();
            labelPatientCount.Text = tmp[1].ToString();
            labelAppointmentCount.Text = tmp[2].ToString();
        }

        private void LoadAppointments()
        {
            labelFilter.Text = "Randevular";
            dataGridView1.DataSource = GlobalConfig.Connection.AllAppointments();
            dataGridView1.ClearSelection();
            _filter = 0;
        }

        private void LoadDoctors()
        {
            labelFilter.Text = "Doktorlar";
            dataGridView1.DataSource = GlobalConfig.Connection.AllDoctors();
            dataGridView1.ClearSelection();
            _filter = 1;
        }

        private void LoadPatients()
        {
            labelFilter.Text = "Hastalar";
            dataGridView1.DataSource = GlobalConfig.Connection.AllPatients();
            dataGridView1.ClearSelection();
            _filter = 2;
        }

        private void Delete()
        {
            try
            {
                switch (_filter)
                {
                    case 0:
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            GlobalConfig.Connection.AdminDeleteAppointment(Convert.ToInt32(row.Cells[0].Value));
                        }
                        LoadAppointments();
                        break;
                    case 1:
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            GlobalConfig.Connection.AdminDeleteDoctor(Convert.ToInt32(row.Cells[0].Value));
                        }
                        LoadDoctors();
                        break;
                    case 2:
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            GlobalConfig.Connection.AdminDeletePatient(Convert.ToInt32(row.Cells[0].Value));
                        }
                        LoadPatients();
                        break;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Randevusu olan bir hastayı/doktoru silmeye çalıştınız. " +
                                "Lütfen önce randevuyu silip tekrar deneyiniz.");
            }
            
            InitializeLabels();
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            _previousForm.Show();
        }

        private void buttonGridAppointments_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void buttonGridDoctors_Click(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        private void buttonGridPatients_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen aşağıdan bir şey seçtiğinizden emin olun!");
                return;
            }
            Delete();
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            Delete();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
