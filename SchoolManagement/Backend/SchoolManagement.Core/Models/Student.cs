using System;

namespace SchoolManagement.Core.Models
{
    public class Student : Person
    {
        public string StudentId { get; private set; }
        public int Grade { get; private set; }
        public string Class { get; private set; }

        public Student(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string email,
            string studentId,
            int grade,
            string @class) : base(firstName, lastName, dateOfBirth, email)
        {
            if (string.IsNullOrWhiteSpace(studentId))
                throw new ArgumentException("Student ID cannot be empty", nameof(studentId));
            if (grade < 1 || grade > 13)
                throw new ArgumentException("Grade must be between 1 and 13", nameof(grade));
            if (string.IsNullOrWhiteSpace(@class))
                throw new ArgumentException("Class cannot be empty", nameof(@class));

            StudentId = studentId;
            Grade = grade;
            Class = @class;
        }
    }
}