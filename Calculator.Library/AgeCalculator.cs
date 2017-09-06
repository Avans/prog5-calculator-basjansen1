using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Library
{
    public class AgeCalculator : IAgeCalculator
    {
        private DateTime age;

        public void AskInput()
        {
            Console.WriteLine("Enter a date in the follwing format: dd-mm-yyyy: ");
            string dateInput = Console.ReadLine();

            if (ParseInput(dateInput, out age))
                Console.WriteLine("Your age is: " + CalculateAge(age));
            else
                AskInput();
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            var todaysDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            int age = todaysDate.Year - dateOfBirth.Year;

            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age--;

            return age;
        }

        public bool ParseInput(string input, out DateTime result)
        {
            if (DateTime.TryParse(input, out result))
                return true;
            else
            {
                Console.WriteLine("You entered a wrong dateformat!");
                return false;
            }
        }
    }
}
