using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HYS
{
    public partial class FormDoctor : Form
    {
        public FormDoctor()
        {
            InitializeComponent();
        }

        public string doctorTC;
        public Form previousForm;

        private void FormDoctor_Load(object sender, EventArgs e)
        {

        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm.Show();
        }
    }
}
