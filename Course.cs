using System;

namespace Learnify
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public int CreditHours { get; set; }
        public bool IsRegistrationOpen { get; set; }
        public decimal Price { get; set; } = 5000;
        public string TeacherName { get; set; } = "";

        // Validation method for defensive programming
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Category) &&
                   !string.IsNullOrWhiteSpace(Level) &&
                   CreditHours > 0;
        }
    }
}