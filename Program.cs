internal class Program
{
    private static void Main(string[] args)
    {
        GuessPrompt();
    }

    static string? userInput;
    static readonly int secretNumber = 42;
    static bool guessValid;
    static bool success;
    static readonly int chancesAllowed = 4;
    static int chanceCount = 1;

    static void GuessPrompt()
    {
        Console.WriteLine("Try to guess the secret number:");
        userInput = Console.ReadLine();
        // Console.WriteLine($"You guessed: {userGuess}");
        GameLogic(userInput);
    }

    static void GameLogic(string? userInput)
    {
        guessValid = int.TryParse(userInput, out int userGuess);

        if (guessValid)
        {
            if (userGuess == secretNumber)
            {
                Console.WriteLine($"Your guess is Correct!");
                success = true;
            }
            else
            {
                if (chanceCount < 4)
                {
                    Console.WriteLine($"Your guess is wrong! try again but this time with feeling!");
                }
                success = false;
                while (!success && chanceCount < chancesAllowed)
                {
                    chanceCount++;
                    GuessPrompt();
                }
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number as your guess.");
            GuessPrompt();
        }
    }
}