using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Learnify
{
    public partial class frmMain : Form
    {
        // Constants
        private const decimal COURSE_PRICE = 5000;
        private const int ADDITIONAL_MATERIAL_COST = 100;
        private const int UNDERGRADUATE_DISCOUNT = 40;
        private const int GRADUATE_DISCOUNT = 20;

        // Static student data
        public static string StudentName = "";
        public static string StudentEmail = "";
        public static string StudentPassword = "";
        public static string StudentEduLevel = "";

        public static string DisplayText = "";

        private CheckBox[] additionalMaterials;
        private string currentLevel = "";
        private List<CourseDisplayItem> availableCoursesList = new List<CourseDisplayItem>();

        public frmMain()
        {
            InitializeComponent();
        }

        public void frmMain_Load(object sender, EventArgs e)
        {
            InitializeAdditionalMaterials();

            if (IsUserLoggedIn())
                LoadLoggedInUser();
            else
                LoadGuestUser();
        }

        private void InitializeAdditionalMaterials()
        {
            additionalMaterials = new CheckBox[] { chkQuick, chkSelf };
        }

        private bool IsUserLoggedIn()
        {
            return !string.IsNullOrWhiteSpace(StudentName);
        }

        private void LoadLoggedInUser()
        {
            btnLoginMain.Text = "Logout";
            btnRegisterMain.Enabled = false;
            btnTeacherLogin.Visible = false;
            EnableAllControls();
            rdoBeginner.Checked = true;
            grpUser.Text = "Hello " + StudentName;
            LoadCategoriesFromCourses();
        }

        private void LoadGuestUser()
        {
            DisableAllControls();
            btnLoginMain.Text = "Login";
            btnRegisterMain.Enabled = true;
            btnLoginMain.Enabled = true;
        }

        private void LoadCategoriesFromCourses()
        {
            Category.Items.Clear();
            var categories = CourseData.Courses
                .Where(c => c.IsRegistrationOpen)
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            foreach (var cat in categories)
                Category.Items.Add(cat);
        }

        private void LoadAvailableCoursesForCategory(string category, string level)
        {
            Available.Items.Clear();
            availableCoursesList.Clear();

            var courses = CourseData.Courses
                .Where(c => c.Category == category && c.IsRegistrationOpen && IsMatchingLevel(c.Level, level))
                .ToList();

            foreach (var course in courses)
            {
                string displayText = $"{course.Name} (Level: {course.Level}) - Teacher: {course.TeacherName}";
                Available.Items.Add(displayText);
                availableCoursesList.Add(new CourseDisplayItem { Course = course, DisplayText = displayText });
            }
        }

        private bool IsMatchingLevel(string courseLevel, string selectedLevel)
        {
            if (courseLevel == selectedLevel) return true;
            if (selectedLevel == "Beginner" && courseLevel == "Undergraduate") return true;
            if (selectedLevel == "Intermediate" && courseLevel == "Undergraduate") return true;
            if (selectedLevel == "Advanced" && courseLevel == "Graduate") return true;
            return false;
        }

        private void RefreshCurrentCategory()
        {
            if (Category.SelectedItem != null && !string.IsNullOrEmpty(currentLevel))
                LoadAvailableCoursesForCategory(Category.SelectedItem.ToString(), currentLevel);
        }

        private void btnLoginMain_Click(object sender, EventArgs e)
        {
            if (btnLoginMain.Text == "Logout")
                LogoutUser();
            else
                OpenLoginForm();
        }

        private void LogoutUser()
        {
            StudentName = "";
            StudentEmail = "";
            StudentPassword = "";
            StudentEduLevel = "";

            DisableAllControls();
            btnLoginMain.Text = "Login";
            btnRegisterMain.Enabled = true;
            btnTeacherLogin.Visible = true;
            grpUser.Text = "Unregistered User";

            Category.Items.Clear();
            Available.Items.Clear();
            availableCoursesList.Clear();
        }

        private void OpenLoginForm()
        {
            frmLogin logFormMain = new frmLogin();
            logFormMain.Show();
            this.Hide();
        }

        private void btnRegisterMain_Click(object sender, EventArgs e)
        {
            frmRegister regFormMain = new frmRegister();
            regFormMain.Show();
            this.Hide();
        }

        private void btnTeacherLogin_Click(object sender, EventArgs e)
        {
            frmTeacherLogin teacherLogin = new frmTeacherLogin();
            teacherLogin.ShowDialog();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (!ValidateEnrollmentSelection())
                return;

            var selectedCourses = GetSelectedCourses();
            if (selectedCourses.Count == 0)
                return;

            CalculateAndProcessEnrollment(selectedCourses);
        }

        private bool ValidateEnrollmentSelection()
        {
            if (Available.SelectedItems.Count == 0)
            {
                ShowWarning("Please select at least one course!", "No Selection");
                return false;
            }
            return true;
        }

        private List<Course> GetSelectedCourses()
        {
            var selectedCourses = new List<Course>();
            foreach (var selectedItem in Available.SelectedItems)
            {
                int index = Available.Items.IndexOf(selectedItem);
                if (index >= 0 && index < availableCoursesList.Count)
                    selectedCourses.Add(availableCoursesList[index].Course);
            }
            return selectedCourses;
        }

        private void CalculateAndProcessEnrollment(List<Course> selectedCourses)
        {
            int courseCount = selectedCourses.Count;
            int subtotal = (int)COURSE_PRICE * courseCount;
            int discountPercentage = GetDiscountPercentage();
            int additionalCost = CalculateAdditionalMaterialsCost();

            double finalCost = subtotal * (100 - discountPercentage) / 100.0 + additionalCost;

            string confirmationMessage = $"Total Cost: {finalCost:F2} PKR.\n\nWant to Proceed?";

            if (MessageBox.Show(confirmationMessage, "Checkout", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                GenerateEnrollmentReceipt(selectedCourses, finalCost);
                OpenDisplayForm();
            }
        }

        private int GetDiscountPercentage()
        {
            if (StudentEduLevel == "Undergraduate Student")
                return UNDERGRADUATE_DISCOUNT;
            if (StudentEduLevel == "Graduate Student")
                return GRADUATE_DISCOUNT;
            return 0;
        }

        private int CalculateAdditionalMaterialsCost()
        {
            int cost = 0;
            for (int i = 0; i < additionalMaterials.Length; i++)
            {
                if (additionalMaterials[i].Checked)
                    cost += ADDITIONAL_MATERIAL_COST;
            }
            return cost;
        }

        private void GenerateEnrollmentReceipt(List<Course> selectedCourses, double finalCost)
        {
            DisplayText = "";
            DisplayText += "Dear " + StudentName;
            DisplayText += "\n\nYou are now enrolled in following courses:\n";

            foreach (var course in selectedCourses)
            {
                DisplayText += $"\n• {course.Name} (Level: {course.Level})";
                DisplayText += $"\n  Teacher: {course.TeacherName}";
                DisplayText += $"\n  Credit Hours: {course.CreditHours}\n";
            }

            string additionalMaterialsText = GetSelectedAdditionalMaterials();
            if (!string.IsNullOrEmpty(additionalMaterialsText))
                DisplayText += "\nIncluded Additional Materials:" + additionalMaterialsText;

            DisplayText += $"\n\nTotal Charged: {finalCost:F2} PKR.";
            DisplayText += "\n\nThank you for enrolling with Learnify!";
        }

        private string GetSelectedAdditionalMaterials()
        {
            string materials = "";
            foreach (var chk in additionalMaterials)
            {
                if (chk.Checked)
                    materials += "\n" + chk.Text;
            }
            return materials;
        }

        private void OpenDisplayForm()
        {
            frmDisplay displayForm = new frmDisplay();
            displayForm.Show();
        }

        private void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void DisableAllControls()
        {
            grpLevel.Enabled = false;
            grpCategory.Enabled = false;
            grpAdditional.Enabled = false;
            btnEnroll.Enabled = false;
        }

        public void EnableAllControls()
        {
            grpLevel.Enabled = true;
            grpCategory.Enabled = true;
            grpAdditional.Enabled = true;
            btnEnroll.Enabled = true;
        }

        private void rdoBeginner_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBeginner.Checked)
            {
                currentLevel = rdoBeginner.Text;
                RefreshCurrentCategory();
            }
        }

        private void rdoIntermediate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntermediate.Checked)
            {
                currentLevel = rdoIntermediate.Text;
                RefreshCurrentCategory();
            }
        }

        private void rdoAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAdvanced.Checked)
            {
                currentLevel = rdoAdvanced.Text;
                RefreshCurrentCategory();
            }
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category.SelectedItem != null)
            {
                if (string.IsNullOrEmpty(currentLevel))
                {
                    currentLevel = "Beginner";
                    rdoBeginner.Checked = true;
                }
                LoadAvailableCoursesForCategory(Category.SelectedItem.ToString(), currentLevel);
            }
        }
    }

    public class CourseDisplayItem
    {
        public Course Course { get; set; }
        public string DisplayText { get; set; }
        public override string ToString() => DisplayText;
    }
}