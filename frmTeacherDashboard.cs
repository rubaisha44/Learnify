using System;
using System.Windows.Forms;

namespace Learnify
{
    public partial class frmTeacherDashboard : Form
    {
        private Teacher currentTeacher;

        public frmTeacherDashboard(Teacher teacher)
        {
            InitializeComponent();
            currentTeacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
            this.Text = $"Teacher Dashboard - Welcome {teacher.Name}";
            LoadCourses();
        }

        private void LoadCourses()
        {
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = CourseData.Courses;
            ConfigureDataGridView();
            UpdateToggleButtonText();
        }

        private void ConfigureDataGridView()
        {
            if (dgvCourses.Columns.Contains("Id"))
                dgvCourses.Columns["Id"].HeaderText = "ID";
            if (dgvCourses.Columns.Contains("Name"))
                dgvCourses.Columns["Name"].HeaderText = "Course Name";
            if (dgvCourses.Columns.Contains("TeacherName"))
                dgvCourses.Columns["TeacherName"].HeaderText = "Teacher";
            if (dgvCourses.Columns.Contains("CreditHours"))
                dgvCourses.Columns["CreditHours"].HeaderText = "Credit Hours";
            if (dgvCourses.Columns.Contains("IsRegistrationOpen"))
                dgvCourses.Columns["IsRegistrationOpen"].HeaderText = "Registration Open";
            if (dgvCourses.Columns.Contains("Price"))
                dgvCourses.Columns["Price"].HeaderText = "Price (PKR)";

            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCourseEdit editForm = new frmCourseEdit(null, currentTeacher.Name);
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadCourses();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateCourseSelection())
                return;

            Course selected = GetSelectedCourse();
            if (CanEditCourse(selected))
            {
                OpenEditForm(selected);
            }
            else
            {
                ShowAccessDeniedMessage();
            }
        }

        private bool ValidateCourseSelection()
        {
            if (dgvCourses.CurrentRow == null)
            {
                ShowMessage("Please select a course to edit.", "No Selection");
                return false;
            }
            return true;
        }

        private Course GetSelectedCourse()
        {
            return (Course)dgvCourses.CurrentRow.DataBoundItem;
        }

        private bool CanEditCourse(Course course)
        {
            return course.TeacherName == currentTeacher.Name || string.IsNullOrEmpty(course.TeacherName);
        }

        private void OpenEditForm(Course course)
        {
            frmCourseEdit editForm = new frmCourseEdit(course, currentTeacher.Name);
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadCourses();
        }

        private void ShowAccessDeniedMessage()
        {
            ShowMessage("You can only edit courses you created.", "Access Denied");
        }

        private void UpdateToggleButtonText()
        {
            if (dgvCourses.CurrentRow != null)
            {
                Course selected = GetSelectedCourse();
                btnToggleReg.Text = selected.IsRegistrationOpen ? "CLOSE Registration" : "OPEN Registration";
            }
            else
            {
                btnToggleReg.Text = "Select a Course";
            }
        }

        private void btnToggleReg_Click(object sender, EventArgs e)
        {
            if (!ValidateCourseSelection())
                return;

            Course selected = GetSelectedCourse();
            selected.IsRegistrationOpen = !selected.IsRegistrationOpen;
            CourseData.SaveToFile();
            LoadCourses();

            ShowMessage($"Registration for '{selected.Name}' is now {(selected.IsRegistrationOpen ? "OPENED" : "CLOSED")}", "Success");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            UpdateToggleButtonText();
        }

        private void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}