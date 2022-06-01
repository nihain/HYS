using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace HYS
{
    public partial class FormLoginRegister : Form
    {
        public FormLoginRegister()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source = MATEBOOK\\SQLEXPRESS; Initial Catalog = HospitalDB; Integrated Security = True");

        // disable animation triggers
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

        // enable animation triggers
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

        void ResetForm()
        {
            panelMenu.Location = new Point(-500, 50);
            ClearText();
        }

        private void labelMainToDocLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerMainToDocLogin.Start();
        }

        private void labelMainToPatientLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerMainToPatientLogin.Start();
        }

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

        private void labelDocLoginToMain_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerDocLoginToMain.Start();
        }

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

        private void labelPatientLoginToMain_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerPatientLoginToMain.Start();
        }

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

        private void labelDocRegisterToLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerDocRegisterToLogin.Start();
        }

        private void labelDocLoginToRegister_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerDocLoginToRegister.Start();
        }

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

        private void labelPatientRegisterToLogin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerPatientRegisterToLogin.Start();
        }

        private void labelPatientLoginToRegister_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerPatientLoginToRegister.Start();
        }

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

        private void labelMainToAdmin_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerMainToAdmin.Start();
        }

        private void labelAdminToMain_Click(object sender, EventArgs e)
        {
            DisableLabels();
            timerAdminToMain.Start();
        }

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

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
            textBoxDoctorRegisterName.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxDoctorRegisterSurname.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxDoctorRegisterBranch.BackColor = Color.FromArgb(255, 25, 28, 33);
            maskedTextBoxDoctorRegisterTC.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxDoctorRegisterPassword.BackColor = Color.FromArgb(255, 25, 28, 33);

            if (textBoxDoctorRegisterName.Text == String.Empty || textBoxDoctorRegisterSurname.Text == String.Empty || textBoxDoctorRegisterBranch.Text == String.Empty || maskedTextBoxDoctorRegisterTC.Text == String.Empty || textBoxDoctorRegisterPassword.Text == String.Empty)
            {
                textBoxDoctorRegisterName.BackColor = Color.Red;
                textBoxDoctorRegisterSurname.BackColor = Color.Red;
                textBoxDoctorRegisterBranch.BackColor = Color.Red;
                maskedTextBoxDoctorRegisterTC.BackColor = Color.Red;
                textBoxDoctorRegisterPassword.BackColor = Color.Red;

                MessageBox.Show("Herhangi bir alan boş bırakılamaz.");
            }
            else
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into TableDoctors (DoctorName, DoctorSurname, DoctorBranch, DoctorTC, DoctorPassword) values (@name, @surname, @branch, @tc, @password)", conn);

                cmd.Parameters.AddWithValue("@name", textBoxDoctorRegisterName.Text);
                cmd.Parameters.AddWithValue("@surname", textBoxDoctorRegisterSurname.Text);
                cmd.Parameters.AddWithValue("@branch", textBoxDoctorRegisterBranch.Text);
                cmd.Parameters.AddWithValue("@tc", maskedTextBoxDoctorRegisterTC.Text);
                cmd.Parameters.AddWithValue("@password", textBoxDoctorRegisterPassword.Text);

                cmd.ExecuteNonQuery();

                conn.Close();

                ClearText();

                MessageBox.Show("Kayıt başarılı.");
            }
        }

        private void buttonPatientRegister_Click(object sender, EventArgs e)
        {
            textBoxPatientRegisterName.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPatientRegisterSurname.BackColor = Color.FromArgb(255, 25, 28, 33);
            maskedTextBoxPatientRegisterTC.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPatientRegisterPassword.BackColor = Color.FromArgb(255, 25, 28, 33);

            bool? isMale;
            if (radioButtonMale.Checked == true)
            {
                isMale = true;
            }
            else if (radioButtonFemale.Checked == true)
            {
                isMale = false;
            }
            else
            {
                isMale = null;
            }

            if (textBoxPatientRegisterName.Text == String.Empty || textBoxPatientRegisterSurname.Text == String.Empty || maskedTextBoxPatientRegisterTC.Text == String.Empty || textBoxPatientRegisterPassword.Text == String.Empty || (radioButtonFemale.Checked == false && radioButtonMale.Checked == false))
            {
                textBoxPatientRegisterName.BackColor = Color.Red;
                textBoxPatientRegisterSurname.BackColor = Color.Red;
                maskedTextBoxPatientRegisterTC.BackColor = Color.Red;
                textBoxPatientRegisterPassword.BackColor = Color.Red;

                MessageBox.Show("Herhangi bir alan boş bırakılamaz.");
            }
            else
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into TablePatients (PatientName, PatientSurname, PatientTC, PatientGender,PatientPassword) values (@name, @surname, @tc, @gender, @password)", conn);

                cmd.Parameters.AddWithValue("@name", textBoxPatientRegisterName.Text);
                cmd.Parameters.AddWithValue("@surname", textBoxPatientRegisterSurname.Text);
                cmd.Parameters.AddWithValue("@tc", maskedTextBoxPatientRegisterTC.Text);
                cmd.Parameters.AddWithValue("@gender", isMale);
                cmd.Parameters.AddWithValue("@password", textBoxPatientRegisterPassword.Text);

                cmd.ExecuteNonQuery();

                conn.Close();

                ClearText();

                MessageBox.Show("Kayıt başarılı.");
            }
        }

        private void buttonPatientLogin_Click(object sender, EventArgs e)
        {
            maskedTextBoxPatientLoginTC.BackColor = Color.FromArgb(255, 25, 28, 33);
            textBoxPatientLoginPassword.BackColor = Color.FromArgb(255, 25, 28, 33);

            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from TablePatients Where PatientTC = @tc and PatientPassword = @password", conn);
            cmd.Parameters.AddWithValue("@tc", maskedTextBoxPatientLoginTC.Text);
            cmd.Parameters.AddWithValue("@password", textBoxPatientLoginPassword.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                FormPatient formPatient = new FormPatient();
                formPatient.patientTC = maskedTextBoxPatientLoginTC.Text;
                formPatient.previousForm = this;
                formPatient.Show();
                Hide();
                ResetForm();
            }
            else
            {
                maskedTextBoxPatientLoginTC.BackColor = Color.Red;
                textBoxPatientLoginPassword.BackColor = Color.Red;

                MessageBox.Show("Yanlış TC kimlik no veya şifre.");
            }

            conn.Close();
        }

        private void buttonDoctorLogin_Click(object sender, EventArgs e)
        {
            FormDoctor formDoctor = new FormDoctor();
            formDoctor.previousForm = this;
            formDoctor.Show();
            Hide();
            ResetForm();
        }
    }
}