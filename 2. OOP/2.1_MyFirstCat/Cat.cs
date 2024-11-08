using System;

namespace _2._1_MyFirstCat
{
    public class Cat
    {
<<<<<<< HEAD
        private string Color { get; set; } = "Unbekannt";
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
=======
        public string Color { get; set; } = "Unbekannt";
        public DateTime? Birthdate { get; set; }
        public int Age { get; private set; }

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
>>>>>>> 615da13c0761a4b2d376fe16400ab15b7fb25119
    }
}
