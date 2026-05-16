using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learnify
{
    public partial class frmDisplay : Form
    {
        public frmDisplay()
        {
            InitializeComponent();
        }

        private void frmDisplay_Load(object sender, EventArgs e)
        {
            txtDisplay.Text = frmMain.DisplayText;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
