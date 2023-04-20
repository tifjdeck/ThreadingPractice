//Title: Threading Practice
//Date: 03/06/2023
//Name: Tiffany Decker
//File: FindPiThread

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingPractice
{
    internal class FindPiThread
    {
        private int dartsToThrow;
        private int dartsInside;
        private Random randomizer;

        public FindPiThread(int dartsToThrow)
        {
            this.dartsToThrow = dartsToThrow;
            this.randomizer = new Random();
        }

        public int DartsInside
        {
            get { return dartsInside; }
        }

        public void throwDarts()
        {
            double x = 0.0;
            double y = 0.0;
            double hypotenuse = 0.0;
            for(int i = 0; i < dartsToThrow; i++)
            {
                x = randomizer.NextDouble();
                y = randomizer.NextDouble();
                hypotenuse = Math.Sqrt((x*x) + (y*y));
                if ( hypotenuse <= 1.0 ) { dartsInside++; }
            }
        }
    }
}
