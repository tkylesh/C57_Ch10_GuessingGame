internal class Program
{
    private static void Main()
    {
        GuessPrompt();
    }

    static string? userInput;
    static bool guessValid;
    static bool success;
    static readonly int chancesAllowed = 4;
    static int chanceCount = 1;
    static readonly Random random = new Random();
    static readonly int secretNumber = random.Next(1, 100);

    static void GuessPrompt()
    {
        int chancesRemaining = chancesAllowed - (chanceCount - 1);
        Console.WriteLine($"Try to guess the secret number ({chancesRemaining}):");
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

                if (userGuess > secretNumber)
                {
                    Console.WriteLine("<<<< Your guess was too high. >>>>");
                }
                else
                {
                    Console.WriteLine("<<<< Your guess was too low. >>>>");
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