using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HospitalLibrary;
using HospitalLibrary.Models;

namespace HYS.Forms
{
    public partial class FormLoginRegister : Form
    {
        public FormLoginRegister()
        {
            InitializeComponent();
        }
        
        //TODO: Change radiobutton color
        
        /// <summary>
        /// Disable animation triggers.
        /// </summary>
        void DisableLabels()
        {
            labelMainToDocLogin.Enabled = false;
            labelMainToPatientLogin.Enabled = false;
            labelDocLoginToMain.Enabled = false;
            labelDocLoginToRegister.Enabled = false;
            labelPatientLoginToMain.Enabled = false;
            labelPatientLoginToRegister.Enabled = false;
            labelDocRegisterToLogin.Enabled = false;
            labelPatientRegisterToLogin.Enabled = false;
            labelMainToAdmin.Enabled = false;
            labelAdminToMain.Enabled = false;
        }

        /// <summary>
        /// Enable animation triggers.
        /// </summary>
        void EnableLabels()
        {
            labelMainToDocLogin.Enabled = true;
            labelMainToPatientLogin.Enabled = true;
            labelDocLoginToMain.Enabled = true;
            labelDocLoginToRegister.Enabled = true;
            labelPatientLoginToMain.Enabled = true;
            labelPatientLoginToRegister.Enabled = true;
            labelDocRegisterToLogin.Enabled = true;
            labelPatientRegisterToLogin.Enabled = true;
            labelMainToAdmin.Enabled = true;
            labelAdminToMain.Enabled = true;
        }

        /// <summary>
        /// Clear all textBoxes, maskedTextBoxes and uncheck radioButtons.
        /// </summary>
        void ClearText()
        {
            foreach (TextBox text in this.panelMenu.Controls.OfType<TextBox>())
            {
                text.Text = String.Empty;
                text.BackColor = Color.FromArgb(255, 25, 28, 33);
            }

            foreach (RadioButton radio in this.panelMenu.Controls.OfType<RadioButton>())
            {
                radio.Checked = false;
            }

            foreach (MaskedTextBox maskedText in this.panelMenu.Controls.OfType<MaskedTextBox>())
            {
                maskedText.Text = string.Empty;
                maskedText.BackColor = Color.FromArgb(255, 25, 28, 33);
            }
        }

        /// <summary>
        /// Reset the menu to initial position.
        /// </summary>
        void ResetForm()
        {
            panelMenu.Location = new Point(-500, 50);
            ClearText();
        }

        // Animation trigger.
        private void labelMainToDocLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerMainToDocLogin.Start();
        }

        // Animation trigger.
        private void labelMainToPatientLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerMainToPatientLogin.Start();
        }

        // Animation.
        private void timerMainToDocLogin_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.X < 0)
            {
                panelMenu.Location = new Point(panelMenu.Location.X + 10, panelMenu.Location.Y);
            }
            else
            {
                timerMainToDocLogin.Stop();
                this.Text = "Doktor Giriş";
                EnableLabels();
                ClearText();
            }
        }

        // Animation
        private void timerDocLoginToMain_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.X > -500)
            {
                panelMenu.Location = new Point(panelMenu.Location.X - 10, panelMenu.Location.Y);
            }
            else
            {
                timerDocLoginToMain.Stop();
                this.Text = "Hastane Yönetim Sistemi";
                EnableLabels();
                ClearText();
            }
        }

        // Animation trigger.
        private void labelDocLoginToMain_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerDocLoginToMain.Start();
        }

        // Animation.
        private void timerMainToPatientLogin_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.X > -1000)
            {
                panelMenu.Location = new Point(panelMenu.Location.X - 10, panelMenu.Location.Y);
            }
            else
            {
                timerMainToPatientLogin.Stop();
                this.Text = "Hasta Giriş";
                EnableLabels();
                ClearText();
            }
        }

        // Animation trigger.
        private void labelPatientLoginToMain_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerPatientLoginToMain.Start();
        }

        // Animation.
        private void timerPatientLoginToMain_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.X < -500)
            {
                panelMenu.Location = new Point(panelMenu.Location.X + 10, panelMenu.Location.Y);
            }
            else
            {
                timerPatientLoginToMain.Stop();
                this.Text = "Hastane Yönetim Sistemi";
                EnableLabels();
                ClearText();
            }
        }

        // Animation trigger.
        private void labelDocRegisterToLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerDocRegisterToLogin.Start();
        }

        // Animation trigger.
        private void labelDocLoginToRegister_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerDocLoginToRegister.Start();
        }

        // Animation.
        private void timerDocLoginToRegister_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.Y > -400)
            {
                panelMenu.Location = new Point(panelMenu.Location.X, panelMenu.Location.Y - 10);
            }
            else
            {
                timerDocLoginToRegister.Stop();
                this.Text = "Doktor Kayıt";
                EnableLabels();
                ClearText();
            }
        }

        // Animation.
        private void timerDocRegisterToLogin_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.Y < 50)
            {
                panelMenu.Location = new Point(panelMenu.Location.X, panelMenu.Location.Y + 10);
            }
            else
            {
                timerDocRegisterToLogin.Stop();
                this.Text = "Doktor Giriş";
                EnableLabels();
                ClearText();
            }
        }

        // Animation trigger.
        private void labelPatientRegisterToLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerPatientRegisterToLogin.Start();
        }

        // Animation trigger.
        private void labelPatientLoginToRegister_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerPatientLoginToRegister.Start();
        }

        // Animation.
        private void timerPatientLoginToRegister_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.Y > -400)
            {
                panelMenu.Location = new Point(panelMenu.Location.X, panelMenu.Location.Y - 10);
            }
            else
            {
                timerPatientLoginToRegister.Stop();
                this.Text = "Hasta Kayıt";
                EnableLabels();
                ClearText();
            }
        }

        // Animation
        private void timerPatientRegisterToLogin_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.Y < 50)
            {
                panelMenu.Location = new Point(panelMenu.Location.X, panelMenu.Location.Y + 10);
            }
            else
            {
                timerPatientRegisterToLogin.Stop();
                this.Text = "Hasta Giriş";
                EnableLabels();
                ClearText();
            }
        }

        // Animation trigger.
        private void labelMainToAdmin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerMainToAdmin.Start();
        }

        // Animation trigger.
        private void labelAdminToMain_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerAdminToMain.Start();
        }

        // Animation.
        private void timerMainToAdmin_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.Y > -400)
            {
                panelMenu.Location = new Point(panelMenu.Location.X, panelMenu.Location.Y - 10);
            }
            else
            {
                timerMainToAdmin.Stop();
                this.Text = "Yönetici Giriş";
                EnableLabels();
                ClearText();
            }
        }

        // Animation.
        private void timerAdminToMain_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Location.Y < 50)
            {
                panelMenu.Location = new Point(panelMenu.Location.X, panelMenu.Location.Y + 10);
            }
            else
            {
                timerAdminToMain.Stop();
                this.Text = "Hastane Yönetim Sistemi";
                EnableLabels();
                ClearText();
            }
        }

        // Custom exit button.
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Custom minimize button.
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonAdminLogin_Click(object sender, EventArgs e)
        {
            if (textBoxAdminUsername.Text == "admin" && textBoxAdminPassword.Text == "admin")
            {
                ClearText();
            }
        }

        private void buttonDoctorRegister_Click(object sender, EventArgs e)
        {
            // Reset input field colors.
            textBoxDoctorRegisterName.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxDoctorRegisterSurname.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxDoctorRegisterBranch.BackColor = Color.FromArgb(255, 25, 28, 33);
            maskedTextBoxDoctorRegisterTC.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxDoctorRegisterPassword.BackColor = Color.FromArgb(255, 25, 28, 33);

            // Check the validity of the input.
            bool isValid = true;
            if (textBoxDoctorRegisterName.Text.Length == 0)
            {
                isValid = false;
                textBoxDoctorRegisterName.BackColor = Color.Red;
            }
            if (textBoxDoctorRegisterSurname.Text.Length == 0)
            {
                isValid = false;
                textBoxDoctorRegisterSurname.BackColor = Color.Red;
            }
            if (maskedTextBoxDoctorRegisterTC.Text.Length != 11)
            {
                isValid = false;
                maskedTextBoxDoctorRegisterTC.BackColor = Color.Red;
            }
            if (textBoxDoctorRegisterBranch.Text.Length == 0)
            {
                isValid = false;
                textBoxDoctorRegisterBranch.BackColor = Color.Red;
            }
            if (textBoxDoctorRegisterPassword.Text.Length == 0)
            {
                isValid = false;
                textBoxDoctorRegisterPassword.BackColor = Color.Red;
            }

            if (isValid)
            {
                DoctorModel model = new DoctorModel(
                    textBoxDoctorRegisterName.Text,
                    textBoxDoctorRegisterSurname.Text,
                    maskedTextBoxDoctorRegisterTC.Text,
                    textBoxDoctorRegisterBranch.Text,
                    textBoxDoctorRegisterPassword.Text);

                GlobalConfig.Connection.CreateDoctorProfile(model);

                ClearText();
                MessageBox.Show("Kayıt başarılı!");
            }
            else
            {
                MessageBox.Show("Herhangi bir alan boş bırakılamaz.");
            }
        }

        private void buttonPatientRegister_Click(object sender, EventArgs e)
        {
            // Reset input field colors.
            textBoxPatientRegisterName.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPatientRegisterSurname.BackColor = Color.FromArgb(255, 25, 28, 33);
            maskedTextBoxPatientRegisterTC.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPatientRegisterPassword.BackColor = Color.FromArgb(255, 25, 28, 33);
            radioButtonMale.BackColor = Color.FromArgb(255, 25, 28, 33);
            radioButtonFemale.BackColor = Color.FromArgb(255, 25, 28, 33);

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

            // Check the validity of the input.
            bool isValid = true;
            if (textBoxPatientRegisterName.Text.Length == 0)
            {
                isValid = false;
                textBoxPatientRegisterName.BackColor = Color.Red;
            }
            if (textBoxPatientRegisterSurname.Text.Length == 0)
            {
                isValid = false;
                textBoxPatientRegisterSurname.BackColor = Color.Red;
            }
            if (maskedTextBoxPatientRegisterTC.Text.Length != 11)
            {
                isValid = false;
                maskedTextBoxPatientRegisterTC.BackColor = Color.Red;
            }
            if (isMale == null)
            {
                isValid = false;
                radioButtonMale.BackColor = Color.Red;
                radioButtonFemale.BackColor= Color.Red;
            }
            if (textBoxPatientRegisterPassword.Text.Length == 0)
            {
                isValid = false;
                textBoxPatientRegisterPassword.BackColor = Color.Red;
            }

            if (isValid)
            {
                PatientModel model = new PatientModel(
                    textBoxPatientRegisterName.Text,
                    textBoxPatientRegisterSurname.Text,
                    maskedTextBoxPatientRegisterTC.Text,
                    isMale,
                    textBoxPatientRegisterPassword.Text);

                GlobalConfig.Connection.CreatePatientProfile(model);

                ClearText();
                MessageBox.Show("Kayıt başarılı!");
            }
            else
            {
                MessageBox.Show("Herhangi bir alan boş bırakılamaz.");
            }
        }

        private void buttonPatientLogin_Click(object sender, EventArgs e)
        {
            maskedTextBoxPatientLoginTC.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPatientLoginPassword.BackColor = Color.FromArgb(255, 25, 28, 33);
            
            //TODO: Add login functionality
        }

        private void buttonDoctorLogin_Click(object sender, EventArgs e)
        {
            FormDoctor formDoctor = new FormDoctor();
            formDoctor.PreviousForm = this;
            formDoctor.Show();
            Hide();
            ResetForm();
        }
    }
}