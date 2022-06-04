using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HospitalLibrary;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    public partial class FormAppointment : Form
    {
        private List<string> _branches;
        private List<DoctorModel> _doctors;
        private readonly List<string> _defaultPrompt = new List<string>();
        private readonly int _patientId;

        public FormAppointment(int patientId)
        {
            InitializeComponent();

            _patientId = patientId;
            
            InitializeLists();
        }

        private void InitializeLists()
        {
            comboBoxClinics.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDoctors.Enabled = false;

            _defaultPrompt.Add("Klinik Seçilmedi");
            comboBoxDoctors.DataSource = _defaultPrompt;

            _branches = GlobalConfig.Connection.GetDoctorBranches();
            _branches.Insert(0, "Klinik Seçiniz");
            comboBoxClinics.DataSource = _branches;
        }

        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {
            comboBoxClinics.BackColor = Color.FromArgb(255, 25, 28, 33);
            comboBoxDoctors.BackColor = Color.FromArgb(255, 25, 28, 33);
            maskedTextBoxDate.BackColor = Color.FromArgb(255, 25, 28, 33);
            maskedTextBoxTime.BackColor = Color.FromArgb(255, 25, 28, 33);

            bool isValid = true;
            if (comboBoxClinics.SelectedIndex == 0)
            {
                isValid = false;
                comboBoxClinics.BackColor = Color.Red;
            }
            if (comboBoxDoctors.Enabled == false)
            {
                isValid = false;
                comboBoxDoctors.BackColor = Color.Red;
            }
            if (!DateTime.TryParse(maskedTextBoxDate.Text, out var date))
            {
                isValid = false;
                maskedTextBoxDate.BackColor = Color.Red;
            }
            if (!DateTime.TryParse(maskedTextBoxTime.Text, out var time))
            {
                isValid = false;
                maskedTextBoxTime.BackColor = Color.Red;
            }

            if (isValid)
            {
                DateTime combined = date.Date.Add(time.TimeOfDay);

                AppointmentModel model = new AppointmentModel(
                    _patientId,
                    _doctors[comboBoxDoctors.SelectedIndex].Id,
                    combined);

                if (GlobalConfig.Connection.CheckAppointmentOverlap(model))
                {
                    comboBoxClinics.BackColor = Color.Red;
                    comboBoxDoctors.BackColor = Color.Red;
                    maskedTextBoxDate.BackColor = Color.Red;
                    maskedTextBoxTime.BackColor = Color.Red;
                    
                    MessageBox.Show("Randevu almak istediğiniz doktorun belirttiğiniz saatte randevusu var ya da " +
                                    "sizin zaten o saatte bir randevunuz bulunuyor. Lütfen başka bir doktordan/saatten " +
                                    "randevu almaya çalışın ya da kendi randevularınızı kontrol edin.");
                }
                else
                {
                    GlobalConfig.Connection.CreateAppointment(model);
                    MessageBox.Show("Randevu oluşturuldu!");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Hatalı bilgi girilemez.");
            }
        }

        private void comboBoxClinics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClinics.SelectedIndex != 0)
            {
                _doctors = GlobalConfig.Connection.GetDoctorByBranch(comboBoxClinics.Text);
                comboBoxDoctors.DataSource = _doctors;
                comboBoxDoctors.DisplayMember = "FullName";

                comboBoxDoctors.DataSource = _doctors;
                comboBoxDoctors.Enabled = true;
            }
            else
            {
                comboBoxDoctors.Enabled = false;
                comboBoxDoctors.DataSource = _defaultPrompt;
            }
        }
    }
}
