using System;
using System.Text.RegularExpressions;

var words = new[]
{
    "family",
    "jiujitsu",
    "chicken",
    "programming",
    "injured"
};

Console.WriteLine("You are now playing HANGMAN!");

var chosenWord = words[new Random().Next(0, words.Length -1)];

var validChars = new Regex("^[a-zA-Z]$");

var lives = 7;

var letters = new List<string>();

while (lives != 0)
{
    var charactersLeft = 0;


foreach(var character in chosenWord)
{
    var letter = character.ToString();

    if(letters.Contains(letter))
    {
        Console.Write(letter);
    }
    else
    {
        Console.Write("_");
        charactersLeft++;
    }
    Console.Write(string.Empty);
    }

if(charactersLeft == 0)
    {
        break;
    }
   
    Console.Write("\n\nType in a letter: ");

    var key = Console.ReadKey().Key.ToString().ToLower();
    Console.WriteLine(string.Empty);

    if(!validChars.IsMatch(key))
    {
        Console.WriteLine($"The letter {key} is not valid. Please try again");
        continue;
    }
if (letters.Contains(key))
    {
        Console.WriteLine("You've already typed this letter.");
    }
    letters.Add(key);

    if(!chosenWord.Contains(key))
    {
        lives--;

        
        if(lives > 0) 
        {
            Console.WriteLine($"The letter {key} is not in the word. You have {lives} {(lives == 1 ? "try" : "tries")} left.");
        }
        else
        {
            Console.WriteLine($"You lost! The right word was {chosenWord}!");
        }
    }


}