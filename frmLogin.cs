using System;
using System.Linq;
using System.Windows.Forms;

namespace Learnify
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmailLog.Text.Trim();
            string password = txtPassLog.Text;

            // Validation checks
            if (!ValidateInputs(email, password))
                return;

            // Try teacher login first
            if (TryTeacherLogin(email, password))
                return;

            // Try student login
            if (TryStudentLogin(email, password))
                return;

            // No match found
            ShowErrorMessage("Wrong Email or Password!");
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

        private bool TryTeacherLogin(string email, string password)
        {
            var teacher = CourseData.Teachers.FirstOrDefault(t => t.Email == email && t.Password == password);
            if (teacher != null)
            {
                OpenTeacherDashboard(teacher);
                return true;
            }
            return false;
        }

        private bool TryStudentLogin(string email, string password)
        {
            var student = CourseData.Students.FirstOrDefault(s => s.Email == email && s.Password == password);
            if (student != null)
            {
                SetStudentSession(student);
                OpenMainForm();
                return true;
            }
            return false;
        }

        private void SetStudentSession(Student student)
        {
            frmMain.StudentName = student.Name;
            frmMain.StudentEmail = student.Email;
            frmMain.StudentPassword = student.Password;
            frmMain.StudentEduLevel = student.EducationLevel;
        }

        private void OpenTeacherDashboard(Teacher teacher)
        {
            frmTeacherDashboard dashboard = new frmTeacherDashboard(teacher);
            dashboard.Show();
            this.Hide();
        }

        private void OpenMainForm()
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelLog_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkRegLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister formRegLog = new frmRegister();
            formRegLog.Show();
            this.Close();
        }
    }
}