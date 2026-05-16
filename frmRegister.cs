using System;
using System.Linq;
using System.Windows.Forms;

namespace Learnify
{
    public partial class frmRegister : Form
    {
        // Constants for validation
        private const int MIN_PASSWORD_LENGTH = 8;

        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            txtNameReg.Focus();
            InitializeEducationLevels();
        }

        private void InitializeEducationLevels()
        {
            cmbEduReg.Items.Clear();
            cmbEduReg.Items.Add("Undergraduate Student");
            cmbEduReg.Items.Add("Graduate Student");
            cmbEduReg.Items.Add("Non Student");
            cmbEduReg.Items.Add("Teacher");
            cmbEduReg.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateRegistrationInputs())
                return;

            string selectedRole = cmbEduReg.SelectedItem.ToString();

            if (selectedRole == "Teacher")
                RegisterTeacher();
            else
                RegisterStudent(selectedRole);
        }

        private bool ValidateRegistrationInputs()
        {
            string errorMessage = GetValidationErrors();

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show("Registration Errors:\n" + errorMessage, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private string GetValidationErrors()
        {
            string errors = "";

            if (string.IsNullOrWhiteSpace(txtNameReg.Text))
                errors += "\r\n• Name cannot be empty!";

            if (string.IsNullOrWhiteSpace(txtEmailReg.Text))
                errors += "\r\n• Email cannot be empty!";
            else if (!IsValidEmail(txtEmailReg.Text))
                errors += "\r\n• Invalid Email!";

            if (string.IsNullOrWhiteSpace(txtPassReg.Text))
                errors += "\r\n• Password cannot be empty!";
            else if (txtPassReg.Text.Length < MIN_PASSWORD_LENGTH)
                errors += $"\r\n• Password must have at least {MIN_PASSWORD_LENGTH} characters!";

            if (string.IsNullOrWhiteSpace(txtConfReg.Text))
                errors += "\r\n• Confirm Password cannot be empty!";
            else if (txtPassReg.Text != txtConfReg.Text)
                errors += "\r\n• Password does not match!";

            if (cmbEduReg.SelectedItem == null)
                errors += "\r\n• Please select a role!";

            return errors;
        }

        private bool IsValidEmail(string email)
        {
            int atCount = 0;
            int dotCount = 0;

            foreach (char c in email)
            {
                if (c == '@') atCount++;
                if (c == '.') dotCount++;
            }

            return (dotCount > 0 && atCount == 1);
        }

        private bool IsEmailExistsForTeacher(string email)
        {
            foreach (var teacher in CourseData.Teachers)
            {
                if (teacher.Email == email)
                    return true;
            }
            return false;
        }

        private bool IsEmailExistsForStudent(string email)
        {
            foreach (var student in CourseData.Students)
            {
                if (student.Email == email)
                    return true;
            }
            return false;
        }

        private void RegisterTeacher()
        {
            if (IsEmailExistsForTeacher(txtEmailReg.Text))
            {
                ShowMessage("Teacher with this email already exists!", "Error");
                return;
            }

            Teacher newTeacher = new Teacher
            {
                Email = txtEmailReg.Text,
                Password = txtPassReg.Text,
                Name = txtNameReg.Text
            };

            CourseData.Teachers.Add(newTeacher);
            CourseData.SaveToFile();

            ShowMessage("Teacher account created successfully!\nPlease login.", "Success");
            OpenLoginForm();
        }

        private void RegisterStudent(string role)
        {
            if (IsEmailExistsForStudent(txtEmailReg.Text))
            {
                ShowMessage("Student with this email already exists!\nPlease use a different email.", "Error");
                return;
            }

            Student newStudent = new Student
            {
                Name = txtNameReg.Text,
                Email = txtEmailReg.Text,
                Password = txtPassReg.Text,
                EducationLevel = role
            };

            CourseData.Students.Add(newStudent);
            CourseData.SaveToFile();

            SetStudentSession(newStudent);
            ShowMessage("Student registered successfully!", "Success");
            OpenMainForm();
        }

        private void SetStudentSession(Student student)
        {
            frmMain.StudentName = student.Name;
            frmMain.StudentEmail = student.Email;
            frmMain.StudentPassword = student.Password;
            frmMain.StudentEduLevel = student.EducationLevel;
        }

        private void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenLoginForm()
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void OpenMainForm()
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        private void btnCancelReg_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkLoginReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLoginForm();
        }
    }
}