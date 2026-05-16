using System;
using System.Linq;
using System.Windows.Forms;

namespace Learnify
{
    public partial class frmTeacherLogin : Form
    {
        public frmTeacherLogin()
        {
            InitializeComponent();
        }
        private void frmTeacherLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = txt_Email.Text.Trim();
            string password = txt_Password.Text;

            if (!ValidateInputs(email, password))
                return;

            var teacher = CourseData.Teachers.FirstOrDefault(t => t.Email == email && t.Password == password);

            if (teacher != null)
            {
                OpenTeacherDashboard(teacher);
            }
            else
            {
                ShowErrorMessage("Invalid Email or Password!");
            }
        }

        private bool ValidateInputs(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ShowErrorMessage("Email cannot be empty!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ShowErrorMessage("Password cannot be empty!");
                return false;
            }
            return true;
        }

        private void OpenTeacherDashboard(Teacher teacher)
        {
            frmTeacherDashboard dashboard = new frmTeacherDashboard(teacher);
            dashboard.ShowDialog();
            this.Close();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}