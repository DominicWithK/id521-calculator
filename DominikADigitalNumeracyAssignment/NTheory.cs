using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominikADigitalNumeracyAssignment
{
    public class NTheory
    {
        public static string isPrime(int number)
        {
            bool isprime = true;
            //If number is less than two, not prime
            if (number < 2)
            {
                isprime = false;
            }
            //Check to see if number is a prime - start at 2 as 1 is not prime
            for (int i = 2; i < number; i++)
            {
                //If no remainder against all numbers before it, number is not a prime (4 % 2 = 0, 4 is not prime)
                if (number % i == 0)
                {
                    isprime = false;
                }
            }
            if (isprime == true)
            {
                return $"{number} > Is a prime";
            }
            return $"{number} > Is not a prime";
        }
    }
}
