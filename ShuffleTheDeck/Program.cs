/*Luke Groesbeck
Spring 2026
RCET 2265
Project RollOfTheDice
Computer Fundamentals and Introduction to Programming
https://github.com/groeluke/ShuffleTheDeck.git
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
                if (newGame) // 
                {
                    userPrompt = "Wlcome to Shuffle The Deck";
                    newGame = false;
                }
                if (cardCount < 52 && !firstRun)
                {
                    userPrompt = " Welcome to Shuffle The Deck\n"
                        + " If you want to shuffle and restart press C to clear board\n"
                        + " Or press Q to quit";
                    newGame = true;
                    Console.WriteLine("Card Count: " + cardCount++); 
                    // increment the card drawn count
                    DrawCard(drawnCards);
                    // draw a card and mark it as drawn
                }
                if (cardCount >= 52)
                {
                    userPrompt = "All cards have been drawn\n"
                        + "Press C to clear the drawn cards and start a new game\n"
                        + " Or Press Q to quit";

                }
                else if (firstRun) 
                // if this is the first run then prompt the user to draw the first card
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
            string prettyRank = "";
            string placeHolder = "";
            string columnSeperator = " |";
            string currentRow = "";

            string[] heading = { "Spades", "Clubs", "Hearts", "Diamonds" };
            // array of the column heading

            // print heading row
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + columnSeperator);
            }
            Console.WriteLine();

            for (int rank = 1; rank <= 13; rank++)
            // print the rest of the rows
            {
                for (int suit = 0; suit < 4; suit++)
                //assemble the row
                {
                    if (drawnCards[suit, rank - 1])
                    {
                        switch (rank) 
                        // convert the rank number to a letter for face cards and aces
                        {
                            case 1:
                                prettyRank = "A";
                                break;
                            case 11:
                                prettyRank = "J";
                                break;
                            case 12:
                                prettyRank= "Q";
                                break;
                            case 13:
                                prettyRank = "K";
                                break;
                            default:
                                prettyRank = rank.ToString();
                                break;
                        }
                        currentRow += prettyRank.ToString().PadLeft(padding) + columnSeperator; 
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
            int suit = 0, rank = 0;
            do
            {
                suit = RandomNumberZeroTo(4);
                rank = RandomNumberZeroTo(13);
            } while (drawnCards[suit, rank]); 
            //keep trying until we get a card that hasn't been drawn
            Program.drawnCards[suit, rank] = true; 
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