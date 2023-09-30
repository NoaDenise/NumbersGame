using System;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Noa Denise Ishac NET23

            //Denna kod för att symbolerna ska bli synliga för användaren
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool playAgain = true;

            //skapa loop för att programmet ska köra igen om användaren vill det
            while (playAgain)
            {
                Console.WriteLine("Välkommen till Gissa Talet! \nDu kommer nu att få gissa ett tal mellan 1 till 50");
                Console.WriteLine("Du har 10 chanser att gissa rätt. Börja gissa!");

                //Generera random tal och fastställa antalet gissningar
                Random random = new Random();
                int number = random.Next(1, 50);
                int guesses = 10;

                //for loop för att kontrollera att vi håller oss till 10 gissningar
                for (int i = 0; i < 10; i++)
                {
                    int guess = int.Parse(Console.ReadLine());

                    if (guess == number)
                    {
                        //ändrat textfärgen när användaren svarar rätt samt avslutar om svaret är rätt
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("★ RÄTT SVAR! ★");
                        Console.ResetColor();
                        break;
                    }
                    else if (guess < number)
                    {
                        //ändrat färg på text på utskrift när gissningen är lägre än numret
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("🠗 för lågt 🠗");
                        Console.ResetColor();
                    }
                    else if (guess > number)
                    {
                        //samma som ovan fast för hög gissning och annan färg
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("🠕 för högt 🠕");
                        Console.ResetColor();
                    }

                    //kontrollerar att gissningarna räknas ned för varje svar
                    guesses--;

                    // här har jag anropat min metod, se nedan för beskrivning
                    if (CheckGuess(guess, number))
                    {
                        Console.WriteLine("Men du är riktigt nära!");

                    }
                }
                Console.WriteLine("Tack för att du spelat!");
                // användaren får välja om denne vill spela igen
                Console.WriteLine("Vill du spela igen? (J/N)");
                string playAgainInput = Console.ReadLine();

                //ToLower gör att programmet kan tolka stor och liten bokstav
                if (playAgainInput.ToLower() != "j")
                {
                    playAgain = false;
                }
            }


        }

        //här har jag skapat en metod som kontrollerar om gissningen är 5 ifrån det rätta talet
        static bool CheckGuess(int guess, int number)
        {
            // metoden returnerar detta värde 
            return Math.Abs(guess - number) <= 5;
        }
    }
}
