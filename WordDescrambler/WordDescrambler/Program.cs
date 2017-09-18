using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDescrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter player one name: ");
            string playerOneName = Console.ReadLine();
            Console.Write("Enter player two name: ");
            string playerTwoName = Console.ReadLine();

            int playerOneScore = 0;
            int playerTwoScore = 0;
            int turn = 1;
            while (playerOneScore < 5 && playerTwoScore < 5)
            {
                Console.WriteLine("Current Score");
                Console.WriteLine(playerOneName + ": " + playerOneScore );
                Console.WriteLine(playerTwoName +": " + playerTwoScore);
                Console.WriteLine();
                if (turn % 2 == 0)
                {
                    Console.WriteLine(playerOneName + ", Please enter the word for " + playerTwoName + ": ");
                }
                else
                {
                    Console.WriteLine(playerTwoName + ", Please enter the word for " + playerOneName + ": ");
                }
                Console.WriteLine("Please enter the word for your opponent:");
                string word = Console.ReadLine().ToLower();
                Console.Clear();

                //stored array to check values against this
                char[] givenWordInArray = word.ToCharArray();



                int guessesLeft = 5 + word.Length;
                while (guessesLeft > 0)
                {



                    Console.WriteLine("What is your guess? Number of letters: " + givenWordInArray.Length);
                    Console.WriteLine("You have " + guessesLeft + " guesses left.");


                    //MUST BE EQUAL TO LENGTH OF GUESSED WORD            
                    string guess = Console.ReadLine().ToLower();
                    while (guess.Length != givenWordInArray.Length)
                    {
                        Console.WriteLine("Guess must be as long as word! Please enter again: ");
                        guess = Console.ReadLine();
                    }


                    char[] guessChecker = guess.ToCharArray();

                    char[] wordReturn = new char[guessChecker.Length];


                    //STORE CHAR IF LETTER IS CORRECT



                    for (int i = 0; i < guessChecker.Length; i++)
                    {


                        if (guessChecker[i] == givenWordInArray[i])
                        {
                            wordReturn[i] = guessChecker[i];
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(wordReturn[i]);

                        }
                        else if (givenWordInArray.Contains<char>(guessChecker[i]))
                        {
                            wordReturn[i] = guessChecker[i];
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(wordReturn[i]);
                        }
                        else
                        {
                            wordReturn[i] = guessChecker[i];
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(wordReturn[i]);
                        }


                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    guessesLeft--;

                    string wordThatWasGiven = new string(givenWordInArray);
                    string wordThatWasGuessed = new string(wordReturn);

                    

                    if (wordThatWasGiven == wordThatWasGuessed)
                    {
                        Console.WriteLine("YOU GUESSED CORRECTLY");
                        Console.WriteLine("BALLOONS AND CONFETTI AND STUFF!!!");
                        Console.WriteLine();
                        Console.WriteLine();

                        if (turn % 2 == 0)
                        {
                            playerTwoScore++;
                        } else
                        {
                            playerOneScore++;
                            
                        }
                        turn++;
                        break;
                    }

                    if (guessesLeft == 1)
                    {
                        Console.WriteLine("Sorry you ran out of guesses. Try Again!");
                        Console.WriteLine();
                        Console.WriteLine();
                        turn++;
                        break;
                    }

                }
               

            }

            if (playerOneScore > playerTwoScore)
            {
                Console.WriteLine(playerOneName + " wins!");
            } else
            {
                Console.WriteLine(playerTwoName + " wins!");
            }







        }
    }
}
