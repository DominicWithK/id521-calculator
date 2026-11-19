namespace DominikADigitalNumeracyAssignment
{
    public static class Program
    {
        public static void Main(string[] args)
            //Main user interface. Gets user's input. Features a 'help' function to list commands. Typing 'exit' breaks out of the loop and ends the program
        {
            Console.WriteLine("-=-=-=-=-=-= Command-Prompt Calculator =-=-=-=-=-=-");
            Console.WriteLine("Type 'help' for a list of commands, 'exit' to exit.");
            Console.WriteLine();
            bool quit = false;
            while (quit == false)
            {
                Console.Write(">");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                }
                else if (input.Trim().ToLower() == "exit")
                {
                    quit = true;
                }
                else if (input.Trim().ToLower() == "help")
                {
                    Console.WriteLine(Help());
                }
                else if (input.Trim().ToLower() == "clear")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(Parser.Process(input));
                }
            }
        }
        //Returns the help text listing every supported command and operator
        static string Help()
        {
            return """

        === Available Commands ===

        General
          help    Show this list
          exit    Quit the calculator
          clear   Clears the calculator of text

        Cryptography
          caesarEn (text)                      Caesar encryption
          caesarDe (text)                      Caesar decryption
          affineEn (text)                      Affine encryption
          affineDe (text)                      Affine decryption
          affineBf (text)                      Affine decryption brute force

        Number Theory
          isPrime    (number)                  Check for primes
          LCG        (seed)                    Linear congruential method
          checkDigit (code)                    UPC, EAN, ISBN

        Binary
          binAdd   (binary) + (binary)         Binary addition of a signed/unsigned number
          binSub   (binary) - (binary)         Binary subtraction of a signed/unsigned number
          BCD      (BCD) + (BCD)               Addition of BCD numbers
          dectoBin (decimal)                   Decimal to binary
          dectoHex (decimal)                   Decimal to hexadecimal
          bintoDec (binary)                    Binary to decimal
          bintoHex (binary)                    Binary to hexadecimal
          hextoDec (hexadecimal)               Hexadecimal to decimal
          hextoBin (hexadecimal)               Hexadecimal to binary
          dectoBCD (decimal)                   Decimal to binary coded decimal

        Operators
          +, -, *, /, %, ^

        """;
        }
    }
}
