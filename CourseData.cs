using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Learnify
{
    public static class CourseData
    {
        // Constants - replacing magic values
        private const string COURSES_FILE = "courses.json";
        private const string TEACHERS_FILE = "teachers.json";
        private const string STUDENTS_FILE = "students.json";
        private const decimal DEFAULT_COURSE_PRICE = 5000;

        public static List<Course> Courses = new List<Course>();
        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Student> Students = new List<Student>();

        static CourseData()
        {
            LoadFromFile();

            if (Courses.Count == 0)
            {
                AddSampleCourses();
            }

            if (Teachers.Count == 0)
            {
                AddSampleTeacher();
            }
        }

        private static void AddSampleCourses()
        {
            Courses.Add(new Course { Id = 1, Name = "C# Programming", Category = "Programming", Level = "Undergraduate", CreditHours = 3, IsRegistrationOpen = true, Price = DEFAULT_COURSE_PRICE, TeacherName = "Prof. Johnson" });
            Courses.Add(new Course { Id = 2, Name = "Python Basics", Category = "Programming", Level = "Undergraduate", CreditHours = 2, IsRegistrationOpen = true, Price = DEFAULT_COURSE_PRICE, TeacherName = "Prof. Smith" });
            Courses.Add(new Course { Id = 3, Name = "Data Science Fundamentals", Category = "Data Science", Level = "Graduate", CreditHours = 4, IsRegistrationOpen = false, Price = DEFAULT_COURSE_PRICE, TeacherName = "Dr. Williams" });
            Courses.Add(new Course { Id = 4, Name = "Web Development with ASP.NET", Category = "Web Development", Level = "Graduate", CreditHours = 3, IsRegistrationOpen = true, Price = DEFAULT_COURSE_PRICE, TeacherName = "Prof. Johnson" });
            Courses.Add(new Course { Id = 5, Name = "Network Security Basics", Category = "Networking", Level = "Non-Student", CreditHours = 3, IsRegistrationOpen = true, Price = DEFAULT_COURSE_PRICE, TeacherName = "Dr. Brown" });
            SaveToFile();
        }

        private static void AddSampleTeacher()
        {
            Teachers.Add(new Teacher { Email = "teacher@school.com", Password = "1234", Name = "Prof. Johnson" });
            SaveToFile();
        }

        public static void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(COURSES_FILE, JsonSerializer.Serialize(Courses, options));
                File.WriteAllText(TEACHERS_FILE, JsonSerializer.Serialize(Teachers, options));
                File.WriteAllText(STUDENTS_FILE, JsonSerializer.Serialize(Students, options));
            }
            catch (Exception ex)
            {
                ShowError($"Error saving data: {ex.Message}");
            }
        }

        public static void LoadFromFile()
        {
            try
            {
                LoadCoursesFromFile();
                LoadTeachersFromFile();
                LoadStudentsFromFile();
            }
            catch (Exception ex)
            {
                ShowError($"Error loading data: {ex.Message}");
            }
        }

        private static void LoadCoursesFromFile()
        {
            if (File.Exists(COURSES_FILE))
            {
                string json = File.ReadAllText(COURSES_FILE);
                var loaded = JsonSerializer.Deserialize<List<Course>>(json);
                if (loaded != null && loaded.Count > 0)
                    Courses = loaded;
            }
        }

        private static void LoadTeachersFromFile()
        {
            if (File.Exists(TEACHERS_FILE))
            {
                string json = File.ReadAllText(TEACHERS_FILE);
                var loaded = JsonSerializer.Deserialize<List<Teacher>>(json);
                if (loaded != null && loaded.Count > 0)
                    Teachers = loaded;
            }
        }

        private static void LoadStudentsFromFile()
        {
            if (File.Exists(STUDENTS_FILE))
            {
                string json = File.ReadAllText(STUDENTS_FILE);
                var loaded = JsonSerializer.Deserialize<List<Student>>(json);
                if (loaded != null && loaded.Count > 0)
                    Students = loaded;
            }
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}