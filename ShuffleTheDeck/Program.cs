/*Luke Groesbeck
Spring 2026
RCET 2265
Project RollOfTheDice
Computer Fundamentals and Introduction to Programming

*/

namespace ShuffleTheDeck
{
    internal class Program
    {
        static bool[,] drawnCards = new bool[5, 15];
        //make this global so it can be accessed by all methods
        static void Main(string[] args)
        {
            bool firstRun = true;
            bool newGame = true;
            string userInput = "";
            int cardCount = 0;
            string userPrompt = "";
            do
            {
                Console.Clear();
                if (newGame)
                {
                    userPrompt = "Wlcome to Shuffle The Deck";
                    newGame = false;
                }
                if (cardCount < 52 && !firstRun)
                {
                    userPrompt = "All Cards have been drawn\n"
                        + "Press C to draw a Card\n"
                        + "Press Q to quit";
                    DrawCard();
                }
                else if (firstRun)
                {
                    firstRun = false;
                    userPrompt = "Press Enter to draw the first ball";
                }

                Display();
                Console.WriteLine(userPrompt);
                userInput = Console.ReadLine();
                //fixed double draw
                if (userInput == "c" || userInput == "C")
                {
                    ClearDrawnCards();
                    cardCount = 0;
                }
            } while (userInput != "Q" && userInput != "q");
            Console.Clear();
            Console.WriteLine("Have a nice day!");
            //pause
            Console.Read();
        }
        static void Display()
        {
            int padding = 4;
            int prettyNumber = 0;
            string placeHolder = "";
            string columnSeperator = " |";
            string currentRow = "";
            //print heading row
            string[] heading = { "spades", "clubs", "hearts", "diamonds" };
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + columnSeperator);
            }
            Console.WriteLine();

            // print the rest of the rows
            for (int number = 1; number <= 13; number++)
            {
                //assemble the row
                for (int letter = 0; letter < 4; letter++)
                {
                    if (drawnCards[letter, number - 1])
                    {
                        prettyNumber = number + letter; //offset the number by the letter column
                        currentRow += prettyNumber.ToString().PadLeft(padding) + columnSeperator;
                    }
                    else
                    {
                        currentRow += placeHolder.PadLeft(padding) + columnSeperator;
                    }
                }
                Console.WriteLine(currentRow);
                currentRow = ""; //reset 
            }
        }
        static void DrawCard()
        {
            int letter = 0, number = 0;
            do
            {
                letter = RandomNumberZeroTo(4);
                number = RandomNumberZeroTo(14);
            } while (drawnCards[letter, number]);

            drawnCards[letter, number] = true;

        }
        static void ClearDrawnCards()
        { 
            drawnCards = new bool[5, 15]; // this is the same as the above two lines, but more concise

        }
        static private int RandomNumberZeroTo(int max)
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range); //returns a random number between 0 and max, inclusive
        }
    }
}
