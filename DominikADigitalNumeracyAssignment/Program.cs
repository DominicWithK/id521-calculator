namespace DominikADigitalNumeracyAssignment
{
    public static class Program
    {
        public static void Main(string[] args)
            //Main user interface. Gets user's input. Features a 'help' function to list commands. Typing 'exit' breaks out of the loop and ends the program.
        {
            Console.WriteLine("-=-=-=-=-=-= Command-Prompt Calculator =-=-=-=-=-=-");
            Console.WriteLine("Type 'help' for a list of commands, 'exit' to exit.");
            Console.WriteLine();
            bool quit = false;
            while (quit == false)
            {
                Console.Write(">");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) { continue; }
                if (input.Trim().ToLower() == "exit") { quit = true; }
                if (input.Trim().ToLower() == "help") { Console.WriteLine(Help()); continue; }
                Console.WriteLine(Parser.Process(input));
            }
        }
        // Returns the help text listing every supported command and its syntax.
        // Difficulty: keeping it in sync as commands are added. Solved by ...
        static string Help()
        {
            return """
        === Available Commands ===

        General
          help    Show this list
          exit    Quit the calculator

        Cryptography
          caesarEn
          caesarDe
        """;
        }
    }
}
