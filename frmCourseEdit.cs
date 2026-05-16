using System;
using System.Linq;
using System.Windows.Forms;

namespace Learnify
{
    public partial class frmCourseEdit : Form
    {
        private Course editingCourse;
        private string teacherName;

        public frmCourseEdit(Course course, string teacherName)
        {
            InitializeComponent();
            this.teacherName = teacherName;
            editingCourse = course;
            InitializeComboBoxes();
            LoadCourseData();
        }

        private void InitializeComboBoxes()
        {
            cmbLevel.Items.AddRange(new[] { "Undergraduate", "Graduate", "Non-Student" });
            cmbCategory.Items.AddRange(new[] { "Programming", "Data Science", "Networking", "Web Development", "Database" });
        }

        private void LoadCourseData()
        {
            if (editingCourse != null)
            {
                this.Text = "Edit Course";
                txtCourseName.Text = editingCourse.Name;
                cmbLevel.Text = editingCourse.Level;
                cmbCategory.Text = editingCourse.Category;
                numCreditHours.Value = editingCourse.CreditHours;
                chkRegOpen.Checked = editingCourse.IsRegistrationOpen;
                txtTeacherName.Text = editingCourse.TeacherName;
            }
            else
            {
                this.Text = "Add New Course";
                numCreditHours.Value = 3;
                chkRegOpen.Checked = true;
                txtTeacherName.Text = teacherName;
            }
            txtTeacherName.ReadOnly = true;
        }

        private bool ValidateCourseInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                ShowError("Please enter course name.");
                return false;
            }
            if (cmbLevel.SelectedItem == null)
            {
                ShowError("Please select a level.");
                return false;
            }
            if (cmbCategory.SelectedItem == null)
            {
                ShowError("Please select a category.");
                return false;
            }
            if (numCreditHours.Value <= 0)
            {
                ShowError("Credit hours must be greater than 0.");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateCourseInputs())
                return;

            SaveCourse();
        }

        private void SaveCourse()
        {
            if (editingCourse == null)
            {
                CreateNewCourse();
            }

            UpdateCourseData();
            CourseData.SaveToFile();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CreateNewCourse()
        {
            int newId = CourseData.Courses.Count > 0 ? CourseData.Courses.Max(c => c.Id) + 1 : 1;
            editingCourse = new Course { Id = newId, Price = 5000 };
            CourseData.Courses.Add(editingCourse);
        }

        private void UpdateCourseData()
        {
            editingCourse.Name = txtCourseName.Text.Trim();
            editingCourse.Level = cmbLevel.Text;
            editingCourse.Category = cmbCategory.Text;
            editingCourse.CreditHours = (int)numCreditHours.Value;
            editingCourse.IsRegistrationOpen = chkRegOpen.Checked;
            editingCourse.TeacherName = teacherName;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}