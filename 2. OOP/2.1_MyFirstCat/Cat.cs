using System;

namespace _2._1_MyFirstCat
{
    public class Cat
    {
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
    }
}
