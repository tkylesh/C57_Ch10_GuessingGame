﻿internal class Program
{
    private static void Main()
    {
        DifficultyPrompt();
        GuessPrompt();
    }

    // enum DifficultyLevels
    // {
    //     Easy,
    //     Medium,
    //     Hard
    // }
    static string? userInput;
    static string? difficultyInput;
    static bool guessValid;
    static bool difficultyValid;
    static bool success;
    static private int chancesAllowed = 4;
    static int chanceCount = 1;
    static readonly Random random = new Random();
    static readonly int secretNumber = random.Next(1, 100);

    static void DifficultyPrompt()
    {
        Console.WriteLine($"Select Difficulty => Enter 1 for Easy, 2 for Medium, or 3 for Hard");
        difficultyInput = Console.ReadLine();

        difficultyValid = int.TryParse(difficultyInput, out int difficultyLevel);
        switch (difficultyLevel - 1)
        {
            case 0:
                chancesAllowed = 8;
                break;
            case 1:
                chancesAllowed = 6;
                break;
            case 3:
                chancesAllowed = 4;
                break;
            default:
                break;
        }

    }
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