using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.CustomValidators
{
    public class LuhnCheck
    {
        public bool PassesLuhnCheck(string creditCardNumber)
        {
            var cleanedNumber = NormalizeString(creditCardNumber);
            if (cleanedNumber.Trim() == "")
            {
                return false;
            }
            return Luhn(cleanedNumber);
        }
        
        /// <summary>
        /// NormalizeString
        /// </summary>
        /// <param name="creditCardNumber">A non-empty string holding a potential credit card number</param>
        /// <returns>That string with the spaces and dashes removed</returns>
        private static string NormalizeString(string creditCardNumber)
        {
            return new string(creditCardNumber.Where(c => c != ' ' && c != '-')
                .ToArray());
        }

        /// <summary>
        /// Uses the Luhn (Mod 10) algorithm to check for typos in credit card numbers
        /// </summary>
        /// <param name="creditCardNumber">A string with a candidate credit card number</param>
        /// <returns>true if the string fulfills the algorithm, false if it doesn't</returns>
        /// <seealso cref="https://en.wikipedia.org/wiki/Luhn_algorithm"/>
        private static bool Luhn(string creditCardNumber)
        {
            return creditCardNumber.All(char.IsDigit) && creditCardNumber.Reverse()
                .Select(c => c - 48) // a char -  48 coerces it into a number.
                .Select((thisNum, i) => i % 2 == 0 // the even index numbers
                    ? thisNum // just used the number (it's even)
                    : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum) // the odd numbers if they are greater than 9, subtract nine, otherwise just that number
                ).Sum() % 10 == 0; // the sum of all these should be evenly divisible by 10.

            // HT to https://stackoverflow.com/questions/21249670/implementing-luhn-algorithm-using-c-sharp
        }
    }
}
