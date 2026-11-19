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
                string input = Console.ReadLine();
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
          caesaren (text)                      Caesar encryption
          caesarde (text)                      Caesar decryption
          affineen (text)                      Affine encryption
          affinede (text)                      Affine decryption
          affinebf (text)                      Affine decryption brute force

        Number Theory
          isprime (number)                     Check for primes
          lcg (seed)                           Linear congruential method
          checkdigit (code)                    UPC, EAN, ISBN

        Binary
          binadd (binary) (binary)             Binary addition of a signed/unsigned number
          binsub (binary) (binary)             Binary subtraction of an unsigned number
          signedsub (binary) (binary)          Binary subtraction of a signed number
          bcd (BCD) (BCD)                      Addition of BCD numbers
          dectobin (decimal)                   Decimal to binary
          dectohex (decimal)                   Decimal to hexadecimal
          bintodec (binary)                    Binary to decimal
          bintohex (binary)                    Binary to hexadecimal
          hextodec (hexadecimal)               Hexadecimal to decimal
          hextobin (hexadecimal)               Hexadecimal to binary
          dectobcd (decimal)                   Decimal to binary coded decimal
          bcdtodec (BCD)                       Binary coded decimal to decimal

        Operators
          +, -, *, /, %, ^

        Example:
        >binadd 0001 1110
        1111

        """;
        }
    }
}