using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominikADigitalNumeracyAssignment
{
    public class Binary
    {
        public static string DecimalToBinary(int number)
        {
            if (number == 0)
            {
                return "0";
            }
            string binary = "";
            //Divide by two and save remainders - 0 or 1
            while (number > 0)
            {
                int remainder = number % 2;
                binary = remainder + binary;
                number = number / 2;
            }
            return binary;
        }
        public static int BinaryToDecimal(string binary)
        {
            int decimalNumber = 0;
            int power = 1;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    decimalNumber += power;
                }
                power *= 2;
            }
            return decimalNumber;
        }
        public static string DecimalToHexadecimal(int number)
        {
            //0 unchanged
            if (number == 0)
            {
                return "0";
            }
            string hex = "";
            //Convert a decimal number to it's hexadecimal value
            while (number > 0)
            {
                int remainder = number % 16;
                char digit;
                if (remainder < 10)
                {
                    digit = (char)('0' + remainder);
                }
                else if (remainder == 10)
                {
                    digit = 'A';
                }
                else if (remainder == 11)
                {
                    digit = 'B';
                }
                else if (remainder == 12)
                {
                    digit = 'C';
                }
                else if (remainder == 13)
                {
                    digit = 'D';
                }
                else if (remainder == 14)
                {
                    digit = 'E';
                }
                else
                {
                    digit = 'F';
                }
                hex = digit + hex;
                number /= 16;
            }
            return hex;
        }
        //Convert hex back to it's decimal form
        public static int HexToDecimal(string hex)
        {
            int decimalValue = 0;
            int power = 1;
            for (int i = hex.Length - 1; i >= 0; i--)
            {
                int digitValue = 0;
                if (hex[i] >= '0' && hex[i] <= '9')
                {
                    digitValue = hex[i] - '0';
                }
                else if (hex[i] == 'A')
                {
                    digitValue = 10;
                }
                else if (hex[i] == 'B')
                {
                    digitValue = 11;
                }
                else if (hex[i] == 'C')
                {
                    digitValue = 12;
                }
                else if (hex[i] == 'D')
                {
                    digitValue = 13;
                }
                else if (hex[i] == 'E')
                {
                    digitValue = 14;
                }
                else if (hex[i] == 'F')
                {
                    digitValue = 15;
                }
                else
                {
                    return -1; // Invalid hexadecimal digit
                }
                decimalValue += digitValue * power;
                power *= 16;
            }
            return decimalValue;
        }
        //Convert binary to decimal, then that value to hex
        public static string BinaryToHex(string binary)
        {
            int decimalvalue = BinaryToDecimal(binary);
            return DecimalToHexadecimal(decimalvalue);
        }
        //Convert hex to decimal, then that value to binary
        public static string HexToBinary(string hex)
        {
            int binaryvalue = HexToDecimal(hex);
            return DecimalToBinary(binaryvalue);
        }
        //Converts numbers to their nibble form
        public static string DecimalToBCD(string number)
        {
            string bcd = "";
            foreach (char digit in number)
            {
                if (digit == '0')
                {
                    bcd += "0000 ";
                }
                else if (digit == '1')
                {
                    bcd += "0001 ";
                }
                else if (digit == '2')
                {
                    bcd += "0010 ";
                }
                else if (digit == '3')
                {
                    bcd += "0011 ";
                }
                else if (digit == '4')
                {
                    bcd += "0100 ";
                }
                else if (digit == '5')
                {
                    bcd += "0101 ";
                }
                else if (digit == '6')
                {
                    bcd += "0110 ";
                }
                else if (digit == '7')
                {
                    bcd += "0111 ";
                }
                else if (digit == '8')
                {
                    bcd += "1000 ";
                }
                else if (digit == '9')
                {
                    bcd += "1001 ";
                }
                else
                {
                    return "Error: Invalid decimal number";
                }
            }
            //Trim to take off leading space
            return bcd.Trim();
        }
    }
}
