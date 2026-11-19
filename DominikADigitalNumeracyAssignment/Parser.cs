using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominikADigitalNumeracyAssignment
{
    public class Parser
    {
        //Processes basic equations with BEDMAS - features brackets, exponents, modulus, division, multiplication, addition and subtraction. Checks for special commands and hands over to the correct method. I was not able to find a solution in making my parser handle negative numbers.
        public static string Process(string input)
        {
            //Remove extra spaces
            input = input.Trim();
            //Test for commands first
            //Caesar encrypt
            if (input.StartsWith("caesaren "))
            {
                bool valid = false;
                //Get text after 'CaesarEn '
                string text = input.Substring(9);
                //Get shift amount
                Console.Write("Shift: ");
                string inputshift = Console.ReadLine();
                //Make sure user's input is a number
                if (!int.TryParse(inputshift, out int caesarenshift))
                {
                    return "ERROR: Invalid equation";
                }
                string caesarentext = Cryptography.CaesarEncrypt(text, caesarenshift);
                //Test for negative shift
                if (caesarenshift >= 0)
                {
                    valid = true;
                }
                if (valid == true)
                {
                    return caesarentext;
                }
                return "ERROR: Invalid equation";
            }
            //Caesar decrypt
            else if (input.StartsWith("caesarde "))
            {
                bool valid = false;
                string text = input.Substring(9);
                Console.Write("Shift: ");
                string inputshift = Console.ReadLine();
                if (!int.TryParse(inputshift, out int caesardeshift))
                {
                    return "ERROR: Invalid equation";
                }
                string caesardetext = Cryptography.CaesarEncrypt(text, 26 - caesardeshift);
                if (caesardeshift >= 0)
                {
                    valid = true;
                }
                if (valid == true)
                {
                    return caesardetext;
                }
                return "ERROR: Invalid equation";
            }
            //Affine encrypt
            else if (input.StartsWith("affineen "))
            {
                string text = input.Substring(9);
                bool valid = false;
                //Valid multipliers only
                int[] validmultipliers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
                //Get multiplier + shift
                Console.Write("Multiplier: ");
                string inputmultiplier = Console.ReadLine();
                if (!int.TryParse(inputmultiplier, out int multiplier))
                {
                    return "ERROR: Invalid equation";
                }
                Console.Write("Shift: ");
                string inputshift = Console.ReadLine();
                if (!int.TryParse(inputshift, out int affineenshift))
                {
                    return "ERROR: Invalid equation";
                }
                //Check to make sure valid multiplier entered & positive shift
                for (int i = 0; i < validmultipliers.Length; i++)
                {
                    if (multiplier == validmultipliers[i] && affineenshift >= 0)
                    {
                        valid = true;
                    }
                }
                if (valid == false)
                {
                    return "ERROR: Invalid multiplier or negative shift. Available multipliers: 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25";
                }
                string affineentext = Cryptography.AffineEncrypt(text, multiplier, affineenshift);
                return affineentext;
            }
            //Affine decrypt
            else if (input.StartsWith("affinede "))
            {
                string text = input.Substring(9);
                bool valid = false;
                int[] validmultipliers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
                Console.Write("Multiplier: ");
                string inputmultiplier = Console.ReadLine();
                if (!int.TryParse(inputmultiplier, out int multiplier))
                {
                    return "ERROR: Invalid equation";
                }
                Console.Write("Shift: ");
                string inputshift = Console.ReadLine();
                if (!int.TryParse(inputshift, out int affinedeshift))
                {
                    return "ERROR: Invalid equation";
                }
                for (int i = 0; i < validmultipliers.Length; i++)
                {
                    if (multiplier == validmultipliers[i] && affinedeshift >= 0)
                    {
                        valid = true;
                    }
                }
                if (valid == false)
                {
                    return "ERROR: Invalid multiplier or negative shift. Available multipliers: 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25";
                }
                string affinedetext = Cryptography.AffineDecrypt(text, multiplier, affinedeshift);
                return affinedetext;
            }
            //Affine brute force
            else if (input.StartsWith("affinebf "))
            {
                string text = input.Substring(9);
                string bruteforcetext = Cryptography.AffineBruteForce(text);
                Console.WriteLine($"Decrypting: {text}");
                return bruteforcetext;
            }
            //Check for primes
            else if (input.StartsWith("isprime "))
            {
                string usernumber = input.Substring(8);
                if (!int.TryParse(usernumber, out int number))
                {
                    return "ERROR: Invalid equation";
                }
                string isaprime = NTheory.isPrime(number);
                return isaprime;
            }
            //Linear congruential method
            else if (input.StartsWith("lcg "))
            {
                string number = input.Substring(4);
                if (!int.TryParse(number, out int seed))
                {
                    return "ERROR: Invalid equation";
                }
                string randomnumbers = NTheory.LCG(seed);
                return randomnumbers;
            }
            //UPC, EAN and ISBN
            else if (input.StartsWith("checkdigit "))
            {
                string code = input.Substring(11);
                //Check to make sure numbers only
                foreach (char character in code)
                {
                    if (!char.IsDigit(character))
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                return NTheory.CheckDigit(code);
            }
            //Decimal to binary
            else if (input.StartsWith("dectobin "))
            {
                string userinput = input.Substring(9);
                if (!int.TryParse(userinput, out int number))
                {
                    return "ERROR: Invalid equation";
                }
                string binary = Binary.DecimalToBinary(number);
                return binary;
            }
            //Decimal to hexadecimal
            else if (input.StartsWith("dectohex "))
            {
                string userinput = input.Substring(9);
                if (!int.TryParse(userinput, out int number))
                {
                    return "ERROR: Invalid equation";
                }
                string hex = Binary.DecimalToHexadecimal(number);
                return hex;
            }
            //Decimal to BCD
            else if (input.StartsWith("dectobcd "))
            {
                string userinput = input.Substring(9);
                if (!int.TryParse(userinput, out int number))
                {
                    return "ERROR: Invalid equation";
                }
                string bcd = Binary.DecimalToBCD(userinput);
                return bcd;
            }
            //Binary to decimal
            else if (input.StartsWith("bintodec "))
            {
                string userinput = input.Substring(9);
                if (!int.TryParse(userinput, out int number))
                {
                    return "ERROR: Invalid equation";
                }
                int dec = Binary.BinaryToDecimal(userinput);
                return $"{dec}";
            }
            //Binary to hexadecimal
            else if (input.StartsWith("bintohex "))
            {
                string userinput = input.Substring(9);
                if (!int.TryParse(userinput, out int number))
                {
                    return "ERROR: Invalid equation";
                }
                string hex = Binary.BinaryToHex(userinput);
                return hex;
            }
            //Hexadecimal to decimal
            else if (input.StartsWith("hextodec "))
            {
                string userinput = input.Substring(9);
                if (!int.TryParse(userinput, out int number))
                {
                    return "ERROR: Invalid equation";
                }
                int dec = Binary.HexToDecimal(userinput);
                return $"{dec}";
            }
            //Hexadecimal to binary
            else if (input.StartsWith("hextobin "))
            {
                string userinput = input.Substring(9);
                //Check to make sure characters input are valid (0-9, A-F)
                foreach (char character in userinput)
                {
                    if (!(char.IsDigit(character) || (character >= 'A' && character <= 'F') || (character >= 'a' && character <= 'f')))
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                string binary = Binary.HexToBinary(userinput.ToUpper());
                return binary;
            }
            //Binary addition
            else if (input.StartsWith("binadd "))
            {
                string[] parts = input.Split(' ');
                //Make sure input is valid ("binadd" "0111" "011001" = 3)
                if (parts.Length != 3)
                {
                    return "ERROR: Invalid equation";
                }
                string bin1 = parts[1];
                string bin2 = parts[2];
                foreach (char character in bin1)
                {
                    //Only allow 0 and 1 in both bin1 and bin2
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                //Make sure only 1 and 0s are entered
                foreach (char character in bin2)
                {
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                string result = Binary.AddBinary(bin1, bin2);
                return result;
            }
            //Signed binary subtraction
            else if (input.StartsWith("signedsub "))
            {
                string[] parts = input.Split(' ');
                //Make sure input is valid ("binadd" "0111" "011001" = 3)
                if (parts.Length != 3)
                {
                    return "ERROR: Invalid equation";
                }
                string bin1 = parts[1];
                string bin2 = parts[2];
                foreach (char character in bin1)
                {
                    //Only allow 0 and 1 in both bin1 and bin2
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                foreach (char character in bin2)
                {
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                //Make sure binary values are the same length, otherwise signed subtraction gives incorrect results - instead will give an error
                if (bin1.Length != bin2.Length)
                {
                    return "ERROR: Binary numbers must have the same number of bits";
                }
                string result = Binary.SignedSub(bin1, bin2);
                return result;
            }
            //Unsigned binary subtraction
            else if (input.StartsWith("binsub "))
            {
                string[] parts = input.Split(' ');
                //Make sure input is valid ("binsub" "0111" "011001" = 3)
                if (parts.Length != 3)
                {
                    return "ERROR: Invalid equation";
                }
                string bin1 = parts[1];
                string bin2 = parts[2];
                foreach (char character in bin1)
                {
                    //Only allow 0 and 1 in both bin1 and bin2
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                foreach (char character in bin2)
                {
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                string result = Binary.SubtractBinary(bin1, bin2);
                return result;
            }
            //BCD Addition
            else if (input.StartsWith("bcd "))
            {
                string[] parts = input.Split(' ');
                //Check to make sure each nibble has 4 length
                if (parts.Length != 3)
                {
                    return "ERROR: Invalid equation";
                }
                string bcd1 = parts[1];
                string bcd2 = parts[2];
                //Check the first bcd value to make sure only 1 and 0s are entered
                foreach (char character in bcd1)
                {
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                //Check the first bcd value to make sure only 1 and 0s are entered
                foreach (char character in bcd2)
                {
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                //Check to make sure both nibbles have a length of 4
                if (bcd1.Length % 4 != 0 || bcd2.Length % 4 != 0)
                {
                    return "ERROR: Invalid equation";
                }
                string result = Binary.AddBCD(bcd1, bcd2);
                return result;
            }
            //BCD to decimal
            else if (input.StartsWith("bcdtodec "))
            {
                string bcd = input.Substring(9);
                //Remove any potential spacing between nibbles
                bcd = bcd.Replace(" ", "");
                //Make sure only 1 and 0s are entered
                foreach (char character in bcd)
                {
                    if (character != '0' && character != '1')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                //4 bits only
                if (bcd.Length % 4 != 0)
                {
                    return "ERROR: BCD must be in groups of 4 bits";
                }
                int result = Binary.BCDToDecimal(bcd);
                return result.ToString();
            }
            //Basic calculations
            else
            {
                //Make sure user's input does not start with an operator
                if ("+*/^%".Contains(input[0]))
                {
                    return "ERROR: Invalid equation";
                }
                //Create a list. The numbers list holds numbers (e.g. '8', '629') and operators holds operators (^, *, /, %, +, -)
                List<double> numbers = new List<double>();
                List<char> operators = new List<char>();
                //currentNumber holds onto the number. When a number is found in the user's equation, it adds it to this string. This is so that it treats numbers next to each other as one whole number (e.g. 4, 3, 7, *, 6, 2 -> 437 * 62)
                string currentNumber = "";
                //Solves brackets first
                while (input.Contains('('))
                {
                    int open = input.LastIndexOf('(');
                    int close = input.IndexOf(')', open);
                    if (close == -1)
                    {
                        return "ERROR: Invalid equation";
                    }
                    //Get the numbers inside the bracket
                    string inside = input.Substring(open + 1, close - open - 1);
                    //Process them first
                    string result = Process(inside);
                    //Test that the equation inside brackets are valid
                    if (result.StartsWith("Error"))
                    {
                        return result;
                    }
                    //Change the input to the new input with solved brackets
                    input = input.Substring(0, open) + result + input.Substring(close + 1);
                }
                //Check if input has a closing bracket - this shouldn't happen as brackets are deleted when the input string is rewritten
                if (input.Contains(')'))
                {
                    return "ERROR: Invalid equation";
                }
                for (int i = 0; i < input.Length; i++)
                {
                    char character = input[i];
                    if (char.IsDigit(character) || character == '.')
                    {
                        //Add character to the currentNumber - this is so that if a user enters 8 then 7, it is treated as 87.
                        currentNumber += character;
                    }
                    //Check for operators
                    else if ("+-*/^%".Contains(character))
                    {
                        //Check for negative number as long as '-' is the first character in a 'currentNumber'
                        if (character == '-' &&
                            (i == 0 || "+-*/^%".Contains(input[i - 1])))
                        {
                            currentNumber += '-';
                        }
                        //Add to the current number
                        else
                        {
                            numbers.Add(Convert.ToDouble(currentNumber));
                            operators.Add(character);
                            currentNumber = "";
                        }
                    }
                    else if (character != ' ')
                    {
                        return "ERROR: Invalid equation";
                    }
                }
                //Check if 'currentNumber' is empty = This shouldn't happen as long as the equation doesn't end with an operator, as it wipes currentNumber.
                if (currentNumber == "")
                {
                    return "ERROR: Invalid equation";
                }
                numbers.Add(Convert.ToDouble(currentNumber));
                //Calculate exponents
                for (int i = 0; i < operators.Count;)
                {
                    if (operators[i] == '^')
                    {
                        double result = Math.Pow(numbers[i], numbers[i + 1]);
                        //Replace the calculated result with the result
                        numbers[i] = result;
                        //Remove the number it was to the power of and remove the '^' operator
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
                //Multiplication, division and modulus
                for (int i = 0; i < operators.Count;)
                {
                    if (operators[i] == '*' || operators[i] == '/')
                    {
                        double result;
                        //Modulus
                        if (operators[i] == '%')
                        {
                            //Division by zero check
                            if (numbers[i + 1] == 0)
                            {
                                return "ERROR: Invalid equation";
                            }
                            result = numbers[i] % numbers[i + 1];
                        }
                        //Multiplication
                        if (operators[i] == '*')
                        {
                            result = numbers[i] * numbers[i + 1];
                        }
                        //Division
                        else
                        {
                            //Another division by zero check
                            if (numbers[i + 1] == 0)
                            {
                                return "ERROR: Invalid equation";
                            }
                            result = numbers[i] / numbers[i + 1];
                        }
                        //Remove number/operator from list and change number to result
                        numbers[i] = result;
                        //Remove the number multiplied/divided by
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                    }
                    //No mult/div
                    else
                    {
                        i++;
                    }
                }
                //Addition and subtraction
                double total = numbers[0];
                for (int i = 0; i < operators.Count; i++)
                {
                    //Addition
                    if (operators[i] == '+')
                    {
                        total += numbers[i + 1];
                    }
                    //Subtraction
                    else
                    {
                        total -= numbers[i + 1];
                    }
                }
                return ($"{total}");
            }
        }
    }
}