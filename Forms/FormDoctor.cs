using System;
using System.Windows.Forms;

namespace HYS.Forms
{
    //TODO: create edit profile button
    //TODO: set constructor
    
    public partial class FormDoctor : Form
    {
        public FormDoctor()
        {
            InitializeComponent();
        }
        
        public Form PreviousForm;

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
