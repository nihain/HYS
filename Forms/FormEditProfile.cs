using System;
using System.Drawing;
using System.Windows.Forms;
using HospitalLibrary;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    public partial class FormEditProfile : Form
    {
        private readonly bool _mode;
        private readonly DoctorModel _doctorModel;
        private readonly PatientModel _patientModel;
        private readonly FormDoctor _previousDForm;
        private readonly FormPatient _previousPForm;

        public FormEditProfile(bool mode, DoctorModel doctorModel, PatientModel patientModel,
            FormDoctor previousDForm, FormPatient previousPForm)
        {
            InitializeComponent();

            _mode = mode;
            _doctorModel = doctorModel;
            _patientModel = patientModel;
            _previousDForm = previousDForm;
            _previousPForm = previousPForm;

            if (_mode)
            {
                radioButtonMale.Hide();
                radioButtonFemale.Hide();

                labelMode.Text = "Branş:";
                labelMode.Location = new Point(labelMode.Location.X + 33, labelMode.Location.Y);

                textBoxName.Text = _doctorModel.Name;
                textBoxSurname.Text = _doctorModel.Surname;
                maskedTextBoxTC.Text = _doctorModel.TcId;
                textBoxBranch.Text = _doctorModel.Branch;
            }
            else
            {
                textBoxBranch.Hide();

                textBoxName.Text = _patientModel.Name;
                textBoxSurname.Text = _patientModel.Surname;
                maskedTextBoxTC.Text = _patientModel.TcId;
                if (_patientModel.Gender == true)
                {
                    radioButtonMale.Checked = true;
                }
                else if (_patientModel.Gender == false)
                {
                    radioButtonFemale.Checked = true;
                }
            }
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
            {
                textBoxPasswordNew.Enabled = true;
                textBoxPasswordOld.Enabled = true;
            }
            else
            {
                textBoxPasswordNew.Enabled = false;
                textBoxPasswordNew.Text = string.Empty;
                textBoxPasswordNew.BackColor = Color.FromArgb(255, 25, 28, 33);
                textBoxPasswordOld.Enabled = false;
                textBoxPasswordOld.Text = string.Empty;
                textBoxPasswordOld.BackColor = Color.FromArgb(255, 25, 28, 33);
            }
        }

        // Yeah, its spaghetti time.
        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {
            textBoxName.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxSurname.BackColor = Color.FromArgb(255, 25, 28, 33);
            maskedTextBoxTC.BackColor = Color.FromArgb(255, 25, 28, 33);
            radioButtonMale.BackColor = Color.FromArgb(255, 25, 28, 33);
            radioButtonFemale.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxBranch.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPasswordNew.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPasswordOld.BackColor = Color.FromArgb(255, 25, 28, 33);

            bool isValid = true;
            if (textBoxName.Text.Length == 0)
            {
                isValid = false;
                textBoxName.BackColor = Color.Red;
            }
            if (textBoxSurname.Text.Length == 0)
            {
                isValid = false;
                textBoxSurname.BackColor = Color.Red;
            }
            if (maskedTextBoxTC.Text.Length != 11)
            {
                isValid = false;
                maskedTextBoxTC.BackColor = Color.Red;
            }
            if (checkBoxPassword.Checked)
            {
                if (textBoxPasswordNew.Text.Length == 0)
                {
                    isValid = false;
                    textBoxPasswordNew.BackColor = Color.Red;
                }

                if (textBoxPasswordOld.Text.Length == 0)
                {
                    isValid = false;
                    textBoxPasswordOld.BackColor = Color.Red;
                }
            }

            if (_mode)
            {
                if (textBoxBranch.Text.Length == 0)
                {
                    isValid = false;
                    textBoxBranch.BackColor = Color.Red;
                }
            }
            else
            {
                bool? isMale;
                if (radioButtonMale.Checked)
                {
                    isMale = true;
                }
                else if (radioButtonFemale.Checked)
                {
                    isMale = false;
                }
                else
                {
                    isMale = null;
                }

                if (isMale == null)
                {
                    isValid = false;
                    radioButtonMale.BackColor = Color.Red;
                    radioButtonFemale.BackColor = Color.Red;
                }
            }

            if (isValid)
            {
                if (checkBoxPassword.Checked)
                {
                    if (_mode)
                    {
                        if (textBoxPasswordOld.Text == _doctorModel.Password)
                        {
                            if (textBoxPasswordNew.Text != _doctorModel.Password)
                            {
                                UpdateDoctorProfile(true);
                                GlobalConfig.Connection.UpdateDoctorProfile(true, _doctorModel);
                                _previousDForm.Model = _doctorModel;
                                _previousDForm.InitializeLabels();
                                MessageBox.Show("Profil güncellendi!");
                                Close();
                            }
                            else
                            {
                                textBoxPasswordNew.BackColor = Color.Red;
                                MessageBox.Show("Eski şifreniz yeni şifre olamaz.");
                            }
                        }
                        else
                        {
                            textBoxPasswordOld.BackColor = Color.Red;
                            MessageBox.Show("Girdiğiniz eski şifre yanlış.");
                        }
                    }
                    else
                    {
                        if (textBoxPasswordOld.Text == _patientModel.Password)
                        {
                            if (textBoxPasswordNew.Text != _patientModel.Password)
                            {
                                UpdatePatientProfile(true);
                                GlobalConfig.Connection.UpdatePatientProfile(true, _patientModel);
                                _previousPForm.Model = _patientModel;
                                _previousPForm.InitializeLabels();
                                MessageBox.Show("Profil güncellendi!");
                                Close();
                            }
                            else
                            {
                                textBoxPasswordNew.BackColor = Color.Red;
                                MessageBox.Show("Eski şifreniz yeni şifre olamaz.");
                            }
                        }
                        else
                        {
                            textBoxPasswordOld.BackColor = Color.Red;
                            MessageBox.Show("Girdiğiniz eski şifre yanlış.");
                        }
                    }
                }
                else
                {
                    if (_mode)
                    {
                        UpdateDoctorProfile(false);
                        GlobalConfig.Connection.UpdateDoctorProfile(false, _doctorModel);
                        _previousDForm.Model = _doctorModel;
                        _previousDForm.InitializeLabels();
                        MessageBox.Show("Profil güncellendi!");
                        Close();
                    }
                    else
                    {
                        UpdatePatientProfile(false);
                        GlobalConfig.Connection.UpdatePatientProfile(false, _patientModel);
                        _previousPForm.Model = _patientModel;
                        _previousPForm.InitializeLabels();
                        MessageBox.Show("Profil güncellendi!");
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Herhangi bir alan boş bırakılamaz.");
            }
        }

        private void UpdateDoctorProfile(bool mode)
        {
            _doctorModel.Name = textBoxName.Text;
            _doctorModel.Surname = textBoxSurname.Text;
            _doctorModel.TcId = maskedTextBoxTC.Text;
            _doctorModel.Branch = textBoxBranch.Text;

            if (mode)
            {
                _doctorModel.Password = textBoxPasswordNew.Text;
            }
        }

        private void UpdatePatientProfile(bool mode)
        {
            _patientModel.Name = textBoxName.Text;
            _patientModel.Surname = textBoxSurname.Text;
            _patientModel.TcId = maskedTextBoxTC.Text;
            bool isMale = radioButtonMale.Checked;
            _patientModel.Gender = isMale;

            if (mode)
            {
                _patientModel.Password = textBoxPasswordNew.Text;
            }
        }
    }
}
