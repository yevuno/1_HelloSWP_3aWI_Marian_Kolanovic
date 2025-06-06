using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models
{
    public class Teacher : Person
    {
        public string TeacherId { get; private set; }
        public List<string> Subjects { get; private set; }
        public string Room { get; private set; }

        public Teacher(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string email,
            string teacherId,
            List<string> subjects,
            string room) : base(firstName, lastName, dateOfBirth, email)
        {
            if (string.IsNullOrWhiteSpace(teacherId))
                throw new ArgumentException("Teacher ID cannot be empty", nameof(teacherId));
            if (subjects == null || subjects.Count == 0)
                throw new ArgumentException("Teacher must have at least one subject", nameof(subjects));
            if (string.IsNullOrWhiteSpace(room))
                throw new ArgumentException("Room cannot be empty", nameof(room));

            TeacherId = teacherId;
            Subjects = subjects;
            Room = room;
        }
    }
}