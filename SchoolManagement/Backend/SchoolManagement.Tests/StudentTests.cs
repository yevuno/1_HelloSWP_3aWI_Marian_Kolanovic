using System;
using Xunit;
using SchoolManagement.Core.Models;

namespace SchoolManagement.Tests
{
    public class StudentTests
    {
        [Fact]
        public void CreateStudent_WithValidData_ShouldSucceed()
        {
            
            var firstName = "John";
            var lastName = "Doe";
            var dateOfBirth = new DateTime(2000, 1, 1);
            var email = "john.doe@school.com";
            var studentId = "S12345";
            var grade = 10;
            var className = "10A";

            
            var student = new Student(firstName, lastName, dateOfBirth, email, studentId, grade, className);

            
            Assert.Equal(firstName, student.FirstName);
            Assert.Equal(lastName, student.LastName);
            Assert.Equal(dateOfBirth, student.DateOfBirth);
            Assert.Equal(email, student.Email);
            Assert.Equal(studentId, student.StudentId);
            Assert.Equal(grade, student.Grade);
            Assert.Equal(className, student.Class);
        }

        [Theory]
        [InlineData("", "Doe", "Invalid first name")]
        [InlineData("John", "", "Invalid last name")]
        [InlineData("John", "Doe", "Invalid student ID")]
        public void CreateStudent_WithInvalidData_ShouldThrowException(string firstName, string lastName, string expectedError)
        {
            
            var dateOfBirth = new DateTime(2000, 1, 1);
            var email = "john.doe@school.com";
            var studentId = firstName == "" ? "S12345" : (lastName == "" ? "S12345" : "");
            var grade = 10;
            var className = "10A";

            
            var exception = Assert.Throws<ArgumentException>(() =>
                new Student(firstName, lastName, dateOfBirth, email, studentId, grade, className));
            Assert.Contains(expectedError.ToLower(), exception.Message.ToLower());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(14)]
        public void CreateStudent_WithInvalidGrade_ShouldThrowException(int grade)
        {
            
            var firstName = "John";
            var lastName = "Doe";
            var dateOfBirth = new DateTime(2000, 1, 1);
            var email = "john.doe@school.com";
            var studentId = "S12345";
            var className = "10A";

            
            var exception = Assert.Throws<ArgumentException>(() =>
                new Student(firstName, lastName, dateOfBirth, email, studentId, grade, className));
            Assert.Contains("grade", exception.Message.ToLower());
        }
    }
}