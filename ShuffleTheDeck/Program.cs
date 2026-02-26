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
        static bool[,] drawnCards = new bool[4, 13];
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
                    userPrompt = " If all cards have been drawn\n"
                        + "Press C to draw a Card \n"
                        + " Or press Q to quit";
                    DrawCard(drawnCards);
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
            int padding = 8;
            int prettyNumber = 0;
            string placeHolder = "";
            string columnSeperator = " |";
            string currentRow = "";

            string[] heading = { "spades", "clubs", "hearts", "diamonds" };
            string[] ranks = { "A", "2", "3", "4",  "5", "6", "7", "8",
                       "9", "10", "J", "Q", "K"};

            // print heading row
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + columnSeperator);
            }
            Console.WriteLine();

            for (int rank = 0; rank < 12; rank++)
            // print the rest of the rows
            {
                for (int suit = 0; suit < 4; suit++)
                //assemble the row
                {
                    if (drawnCards[suit, rank])
                    {
                        prettyNumber = rank + suit;
                        //offset the number by the letter column
                        currentRow += prettyNumber.ToString().PadLeft(padding) + columnSeperator; 
                        // if the card is drawn then print the number
                    }
                    else
                    {
                        currentRow += placeHolder.PadLeft(padding) + columnSeperator;
                    }
                }
                Console.WriteLine(currentRow);
                currentRow = "";
                //reset 
            }
        }
        static void DrawCard(bool[,] drawnCards)
        {
            int suit = 0, number = 0;
            do
            {
                suit = RandomNumberZeroTo(4);
                number = RandomNumberZeroTo(14);
            } while (drawnCards[suit, number]); 
            //keep trying until we get a card that hasn't been drawn

            Program.drawnCards[suit, number] = true; 
            // mark the card as been drawn

        }
        static void ClearDrawnCards()
        {
            drawnCards = new bool[4, 13]; 
            // reset the array clearing all drawn cards
        }
        static private int RandomNumberZeroTo(int max)
        {
            int range = max;
            //make max inclusive
            Random rand = new Random();
            return rand.Next(range);
            //returns a random number between 0 and max, inclusive
        }
    }
}