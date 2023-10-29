using Microsoft.Win32.SafeHandles;

namespace Tasks
{
    public static class MenuHelpers
    {
        public static int MakeChoice(int pMax, int pMin = 0)
        {
            do
            {
                Console.WriteLine($"Enter a number between {pMin} and {pMax}");
                string userInput = Console.ReadLine() ?? "null error";
                int choice;
                try
                {
                    choice = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"You inputted {userInput} which is not a number");
                    continue;
                }
                if(choice < pMin || choice > pMax)
                {
                    Console.WriteLine($"{choice} is not between {pMin} and {pMax}");
                    continue;
                }
                else
                {
                    Console.WriteLine("\n");
                    return choice - 1;
                }
            }while(true);
        }
    }
}