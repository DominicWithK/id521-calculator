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
            try
            {
                //Remove extra spaces
                input = input.Trim();
                //Test for commands first
                //Caesar Encrypt
                if (input.StartsWith("caesarEn "))
                {
                    bool valid = false;
                    //Get text after 'CaesarEn '
                    string text = input.Substring(9);
                    //Get shift amount
                    Console.Write("Shift: ");
                    int caesarenshift = Convert.ToInt32(Console.ReadLine());
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
                    return "ERROR: Negative shift."; //Put this here because otherwise I get an error that not all paths return a value.
                }
                //Caesar Decrypt
                else if (input.StartsWith("caesarDe "))
                {
                    bool valid = false;
                    string text = input.Substring(9);
                    Console.Write("Shift: ");
                    int caesardeshift = Convert.ToInt32(Console.ReadLine());
                    string caesardetext = Cryptography.CaesarEncrypt(text, 26 - caesardeshift);
                    if (caesardeshift >= 0)
                    {
                        valid = true;
                    }
                    if (valid == true)
                    {
                        return caesardetext;
                    }
                    return "ERROR: Negative shift.";
                }
                else if (input.StartsWith("affineEn "))
                {
                    string text = input.Substring(9);
                    bool valid = false;
                    //Valid multipliers only
                    int[] validmultipliers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
                    //Get multiplier + shift
                    Console.Write("Multiplier: ");
                    int multiplier = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Shift: ");
                    int affineenshift = Convert.ToInt32(Console.ReadLine());
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
                else if (input.StartsWith("affineDe "))
                {
                    string text = input.Substring(9);
                    bool valid = false;
                    int[] validmultipliers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
                    Console.Write("Multiplier: ");
                    int multiplier = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Shift: ");
                    int affinedeshift = Convert.ToInt32(Console.ReadLine());
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
                else if (input.StartsWith("affineBf "))
                {
                    string text = input.Substring(9);
                    string bruteforcetext = Cryptography.AffineBruteForce(text);
                    return bruteforcetext;
                }
                else
                {
                    //Test for empty input
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        return "Error: No input provided.";
                    }
                    //Make sure user's input does not start with an operator
                    if ("+*/^%".Contains(input[0]))
                    {
                        return "Error: Equations cannot start with an operator.";
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
                            return "Error: Missing closing bracket.";
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
                        return "Error: Missing opening bracket.";
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
                            numbers.Add(Convert.ToDouble(currentNumber));
                            operators.Add(character);
                            //Reset the current number
                            currentNumber = "";
                        }
                        else if (character != ' ')
                        {
                            return "Error: Invalid character detected.";
                        }
                    }
                    //Check if 'currentNumber' is empty = This shouldn't happen as long as the equation doesn't end with an operator, as it wipes currentNumber.
                    if (currentNumber == "")
                    {
                        return "Error: Equation cannot end with an operator.";
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
                                if (numbers[i + 1] == 0)
                                {
                                    return "Error: Cannot divide by zero.";
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
                                if (numbers[i + 1] == 0)
                                {
                                    return "Error: Cannot divide by zero.";
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
            //Catch: this happens if the user enters an invalid equation that would normally trigger a crash
            catch
            {
                return "Error: Invalid input/equation.";
            }
        }
    }
}