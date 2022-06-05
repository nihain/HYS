﻿using System;
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
        public PatientModel PatientModel;
        public FormDoctor PreviousDForm;
        public FormPatient PreviousPForm;

        public FormEditProfile(bool mode, DoctorModel doctorModel, PatientModel patientModel,
            FormDoctor previousDForm, FormPatient previousPForm)
        {
            InitializeComponent();

            _mode = mode;
            _doctorModel = doctorModel;
            PatientModel = patientModel;
            PreviousDForm = previousDForm;
            PreviousPForm = previousPForm;

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

                textBoxName.Text = PatientModel.Name;
                textBoxSurname.Text = PatientModel.Surname;
                maskedTextBoxTC.Text = PatientModel.TcId;
                if (PatientModel.Gender == true)
                {
                    radioButtonMale.Checked = true;
                }
                else if (PatientModel.Gender == false)
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

            bool? isMale;
            
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
                                PreviousDForm.Model = _doctorModel;
                                PreviousDForm.InitializeLabels();
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
                        if (textBoxPasswordOld.Text == PatientModel.Password)
                        {
                            if (textBoxPasswordNew.Text != PatientModel.Password)
                            {
                                UpdatePatientProfile(true);
                                GlobalConfig.Connection.UpdatePatientProfile(true, PatientModel);
                                PreviousPForm.Model = PatientModel;
                                PreviousPForm.InitializeLabels();
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
                        PreviousDForm.Model = _doctorModel;
                        PreviousDForm.InitializeLabels();
                        MessageBox.Show("Profil güncellendi!");
                        Close();
                    }
                    else
                    {
                        UpdatePatientProfile(false);
                        GlobalConfig.Connection.UpdatePatientProfile(false, PatientModel);
                        PreviousPForm.Model = PatientModel;
                        PreviousPForm.InitializeLabels();
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
            PatientModel.Name = textBoxName.Text;
            PatientModel.Surname = textBoxSurname.Text;
            PatientModel.TcId = maskedTextBoxTC.Text;
            bool isMale = radioButtonMale.Checked;
            PatientModel.Gender = isMale;

            if (mode)
            {
                PatientModel.Password = textBoxPasswordNew.Text;
            }
        }
    }
}