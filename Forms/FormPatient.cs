using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HYS.Forms
{
    public partial class FormPatient : Form
    {
        public FormPatient()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source = MATEBOOK\\SQLEXPRESS; Initial Catalog = HospitalDB; Integrated Security = True");

        public string patientTC;
        public Form previousForm;

        private void FormPatient_Load(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select PatientName, PatientSurname from TablePatients where PatientTC = @tc", conn);
            cmd.Parameters.AddWithValue("@tc", patientTC);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                labelDashPatientName.Text = reader[0] + ".";
                labelPatientName.Text = reader[0].ToString();
                labelPatientSurname.Text = reader[1].ToString();
                labelPatientTC.Text = patientTC;
            }

            conn.Close();
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm.Show();
        }
    }
}