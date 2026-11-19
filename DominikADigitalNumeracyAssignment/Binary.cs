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
            //0 remains the same
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
            int decimalnumber = 0;
            int power = 1;
            //Calculate binary to decimal
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    decimalnumber += power;
                }
                power *= 2;
            }
            return decimalnumber;
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
                    return "Error: ERROR decimal number";
                }
            }
            //Trim to take off leading space
            return bcd.Trim();
        }
        //Adds 2 binary values to each other
        public static string AddBinary(string bin1, string bin2)
        {
            string result = "";
            int carry = 0;
            int i = bin1.Length - 1;
            int j = bin2.Length - 1;
            //Repeat while there are still bits left
            while (i >= 0 || j >= 0 || carry == 1)
            {
                int sum = carry;
                //Add bit from first number
                if (i >= 0)
                {
                    sum += bin1[i] - '0';
                    i--;
                }
                //Second
                if (j >= 0)
                {
                    sum += bin2[j] - '0';
                    j--;
                }
                result = (sum % 2) + result;
                //Calculate carry for next column
                carry = sum / 2;
            }
            return result;
        }
        //Subtracts 2 binary values from each other
        public static string SubtractBinary(string bin1, string bin2)
        {
            string result = "";
            int borrow = 0;
            int i = bin1.Length - 1;
            int j = bin2.Length - 1;
            while (i >= 0)
            {
                int bit1 = (bin1[i] - '0') - borrow;
                int bit2 = 0;
                if (j >= 0)
                {
                    bit2 = bin2[j] - '0';
                    j--;
                }
                //Check if need to borrow
                if (bit1 < bit2)
                {
                    bit1 += 2;
                    borrow = 1;
                }
                else
                //No borrow
                {
                    borrow = 0;
                }
                result = (bit1 - bit2) + result;
                i--;
                j--;
            }
            return result;
        }
        //Signs binary by flipping it
        public static string SignedBinary(string binary)
        {
            char[] bits = binary.ToCharArray();
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                {
                    bits[i] = '1';
                }
                else
                {
                    bits[i] = '0';
                }
            }
            string inverted = new string(bits);
            string result = AddBinary(inverted, "1");
            //Remove overflow bit
            if (result.Length > binary.Length)
            {
                result = result.Substring(1);
            }
            return result;
        }
        //Subtraction of signed binary values
        public static string SignedSub(string bin1, string bin2)
        {
            string negativeBin2 = SignedBinary(bin2);
            string rawResult = AddBinary(bin1, negativeBin2);
            //Check for overflow
            bool overflow = (bin1[0] == negativeBin2[0] && rawResult[rawResult.Length - bin1.Length] != bin1[0]);
            string result = rawResult;
            //Remove overflow bit
            if (result.Length > bin1.Length)
            {
                result = result.Substring(1);
            }
            if (overflow == true)
            {
                result += " (Overflow)";
            }
            return result;
        }
        //Converts BCD to decimal
        public static int BCDToDecimal(string bcd)
        {
            //Remove spaces
            bcd = bcd.Replace(" ", "");
            int result = 0;
            //Repeat for each digit
            for (int i = 0; i < bcd.Length; i += 4)
            {
                //Create nibbles
                string nibble = bcd.Substring(i, 4);
                int digit = BinaryToDecimal(nibble);
                //Safety check for invalid BCD
                if (digit > 9)
                {
                    return -1;
                }
                result = result * 10 + digit;
            }
            return result;
        }
        //Add BCD values together
        public static string AddBCD(string bcd1, string bcd2)
        {
            int decimal1 = BCDToDecimal(bcd1);
            int decimal2 = BCDToDecimal(bcd2);
            //If invalid BCD character (>9)
            if (decimal1 == -1 || decimal2 == -1)
            {
                return "ERROR: Invalid equation";
            }
            int total = decimal1 + decimal2;
            return DecimalToBCD(total.ToString());
        }
    }
}
