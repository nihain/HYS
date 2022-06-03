using System;
using System.Windows.Forms;

namespace HYS.Forms
{
    public partial class FormDoctor : Form
    {
        public FormDoctor()
        {
            InitializeComponent();
        }
        
        public Form PreviousForm;

        private void FormDoctor_Load(object sender, EventArgs e)
        {

        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreviousForm.Show();
        }
    }
}
