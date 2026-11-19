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
        //LCG - repeats 20 times or until the calculated digit returns to its seed value
        public static string LCG(int seed)
        {
            int count = 0;
            int startSeed = seed;
            int multiplier = 5;
            int increment = 3;
            int modulus = 16;
            string randomNumbers = "";
            do
            {
                seed = (multiplier * seed + increment) % modulus;
                randomNumbers += $"{seed}\n";
                count++;
            }
            while (seed != startSeed && count < 20);
            if (count == 20)
            {
                randomNumbers += "Sequence did not return to start.";
            }
            return randomNumbers;
        }
        //CHeckDigit - decides which conversion to use
        public static string CheckDigit(string code)
        {
            //UPC-A (11 digits)
            if (code.Length == 11)
            {
                return CalculateUPC(code);
            }
            // ISBN-13 (12 digits & starts with 978 or 979)
            else if (code.Length == 12)
            {
                return CalculateEAN13orISBN13(code);
            }
            // EAN-13 (12 digits)
            else
            {
                return "11-12 digits only.";
            }
        }
        //Calculate UPC
        public static string CalculateUPC(string upc)
        {
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < upc.Length; i++)
            {
                int digit = upc[i] - '0';
                //If divisible by 2 = even. Accounting for array indices starting at 0
                if (i % 2 == 0)
                {
                    oddSum += digit;
                }
                else
                {
                    evenSum += digit;
                }
            }
            int total = (oddSum * 3) + evenSum;
            //Formula
            return $"{(10 - (total % 10)) % 10}";
        }

        public static string CalculateEAN13orISBN13(string code)
        {
            int sum = 0;
            for (int i = 0; i < code.Length; i++)
            {
                int digit = code[i] - '0';
                if (i % 2 == 0)
                {
                    sum += digit;
                }
                else
                {
                    sum += digit * 3;
                }
            }
            //Formula
            return $"{(10 - (sum % 10)) % 10}";
        }
    }
}
