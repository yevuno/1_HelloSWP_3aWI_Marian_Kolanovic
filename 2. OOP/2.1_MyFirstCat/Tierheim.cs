using System;
using System.Collections.Generic;

namespace _2._1_MyFirstCat
{
    class Tierheim
    {
        private List<Cat> _cats;

        public Tierheim()
        {
            _cats = new List<Cat>();
        }

        public void AddCat(Cat cat)
        {
            _cats.Add(cat);
        }

        public void ShowCats()
        {
            foreach (var cat in _cats)
            {
                var catInfo = cat.GetCatInfo();
                Console.WriteLine($"Katze Farbe: {catInfo.Item1}, Alter: {cat.Age} Jahre");
            }
        }
    }
}
