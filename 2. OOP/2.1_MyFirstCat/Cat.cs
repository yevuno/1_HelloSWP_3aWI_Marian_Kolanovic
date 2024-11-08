using System;

namespace _2._1_MyFirstCat
{
    public class Cat
    {
        private string Color { get; set; } = "Keine Farbe";
        private DateTime? Birthdate { get; set; }
        public int Age { get; private set; }

        public void SetColor(string color)
        {
            Color = color;
        }

        public void SetBirthdate(DateTime birthdate)
        {
            Birthdate = birthdate;
        }

        public void CalculateAge()
        {
            if (Birthdate.HasValue)
            {
                Age = DateTime.Now.Year - Birthdate.Value.Year;
                if (DateTime.Now < Birthdate.Value.AddYears(Age))
                    Age--;
            }
            else
            {
                Age = 0;
            }
        }
        public (string, DateTime?) GetCatInfo()
        {
            return (Color, Birthdate);
        }
    }
}