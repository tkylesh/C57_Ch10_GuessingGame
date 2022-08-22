// See https://aka.ms/new-console-template for more information

//Phase 1
Console.WriteLine("Try to guess the secret number:");
string? userInput = Console.ReadLine();
// Console.WriteLine($"You guessed: {userGuess}");

//Phase 2
//create a variable to contain secret number
int secretNumber = 42;
/*compare users guess with secret number. display
  a success message if correct, failure message otherwise*/
int userGuess;
bool guessValid = int.TryParse(userInput, out userGuess);

if (guessValid)
{
    if (userGuess == secretNumber)
    {
        Console.WriteLine($"Your guess is Correct!");
    }
    else
    {
        Console.WriteLine($"Your guess is wrong! try again but this time with feeling!");
    }
}
