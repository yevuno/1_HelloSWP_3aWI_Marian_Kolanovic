using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Core.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string RoomNumber { get; private set; }
        public int Seats { get; private set; }
        public double SquareMeters { get; private set; }
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }

        private const double STUDENT_SPACE = 2.0;
        private const double TEACHER_SPACE = 5.0;

        
        protected Classroom()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }

        public Classroom(string roomNumber, int seats, double squareMeters)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
                throw new ArgumentException("Room number cannot be empty", nameof(roomNumber));
            if (seats <= 0)
                throw new ArgumentException("Number of seats must be positive", nameof(seats));
            if (squareMeters <= 0)
                throw new ArgumentException("Square meters must be positive", nameof(squareMeters));

            RoomNumber = roomNumber;
            Seats = seats;
            SquareMeters = squareMeters;
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }

        public bool CanAccommodate(int additionalStudents = 0, int additionalTeachers = 0)
        {
            
            int totalOccupants = Students.Count + Teachers.Count + additionalStudents + additionalTeachers;
            if (totalOccupants > Seats)
                return false;

            
            double occupiedSpace = (Students.Count + additionalStudents) * STUDENT_SPACE +
                                 (Teachers.Count + additionalTeachers) * TEACHER_SPACE;
            return occupiedSpace <= SquareMeters;
        }

        public bool AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (!CanAccommodate(additionalStudents: 1))
                return false;

            Students.Add(student);
            return true;
        }

        public bool AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            if (!CanAccommodate(additionalTeachers: 1))
                return false;

            Teachers.Add(teacher);
            return true;
        }

        public bool RemoveStudent(Student student)
        {
            return Students.Remove(student);
        }

        public bool RemoveTeacher(Teacher teacher)
        {
            return Teachers.Remove(teacher);
        }

        public double GetAvailableSpace()
        {
            double occupiedSpace = Students.Count * STUDENT_SPACE + Teachers.Count * TEACHER_SPACE;
            return SquareMeters - occupiedSpace;
        }

        public int GetAvailableSeats()
        {
            return Seats - (Students.Count + Teachers.Count);
        }
    }
}