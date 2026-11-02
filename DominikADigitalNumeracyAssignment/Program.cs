using System.ComponentModel.Design;

namespace DominikADigitalNumeracyAssignment
{
    public class Program
    {
        static void Main(string[] args)
            //Main user interface. Gets user's input. Features a 'help' function to list commands. Typing 'exit' breaks out of the loop and ends the program.
        {
            Console.WriteLine("-=-=-=- Command-Prompt Calculator -=-=-=-");
            Console.WriteLine("Type 'help' for a list of commands, 'exit' to exit.");
            Console.WriteLine();
            bool quit = false;
            while (quit == false)
            {
                Console.Write(">");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) { }
                if (input.Trim().ToLower() == "exit") { quit = true; }
                if (input.Trim().ToLower() == "help") { Help(); }
            }
        }
        static void Help()
        {

        }
    }
}
