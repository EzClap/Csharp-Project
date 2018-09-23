using System;
//DO NOT DELETE the two following using statements *********************************
using Game_Logic_Class;
using Object_Classes;



namespace Space_Race
{
    class Console_Class
    {
        /// <summary>
        /// Algorithm below currently plays only one game
        /// 
        /// when have this working correctly, add the abilty for the user to 
        /// play more than 1 game if they choose to do so.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {      
            DisplayIntroductionMessage();
            Board.SetUpBoard();

            //set number for test:
            //SpaceRaceGame.NumberOfPlayers = 3;
            //SpaceRaceGame.SetUpPlayers();

            //this is for testing purposes only
            //for (int i = 0; i < Board.Squares.Length; i++)
            //{
            //    Console.WriteLine(Board.Squares[i].Name);
            //}
            //this is for testing purposes only
            //int ctr = 0;
            //bool broke = false;
            //for (int j = 0; j < 50; j++)
            //{

            //    for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            //    {
            //        if (SpaceRaceGame.Players[i].AtFinish)
            //        {
            //            broke = true;
            //            break;

            //        }
            //        Console.Write(SpaceRaceGame.Players[i].RocketFuel + "  ");
            //        Console.WriteLine(SpaceRaceGame.Players[i].Name);
            //        Console.WriteLine(SpaceRaceGame.Players[i].Location.Name);

            //    }
            //    if (broke) { break; }
            //    SpaceRaceGame.PlayOneRound();
            //    ctr++;
            //}

            //Console.WriteLine("round" + (ctr - 1));

            bool playAgain = true;
            while (playAgain)
            {
                DeterminePlayers();
                RunGame();
                FinishGame();
                playAgain = PlayAgain();
            }

            PressEnter();
        }//end Main

   
        /// <summary>
        /// Display a welcome message to the console
        /// Pre:    none.
        /// Post:   A welcome message is displayed to the console.
        /// </summary>
        static void DisplayIntroductionMessage()
        {
            Console.WriteLine("\n\tWelcome to Space Race.\n");
        } //end DisplayIntroductionMessage

        /// <summary>
        /// Displays a prompt and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnter()
        {
            Console.Write("\n\tPress Enter to terminate program ...");
            Console.ReadLine();
        } // end PressAny

        /// <summary>
        /// Asks user for # players and assigns to SpaceRaceGame
        /// </summary>
        private static void DeterminePlayers()
        {
            bool correctInput = false;
            int playerInput = -1;
            while (!correctInput)
            {
                Console.WriteLine("\tThis game is for 2 to 6 players.");
                Console.Write("\tHow many players: ");
                try
                {
                    playerInput = int.Parse(Console.ReadLine());
                    if (playerInput < 2 || playerInput > 6) { Console.WriteLine("\nError: invalid number of players entered.\n"); }
                    else { correctInput = true; }
                }
                catch (FormatException) { Console.WriteLine("\nError: you must enter a valid number.\n"); }
            }

            SpaceRaceGame.NumberOfPlayers = playerInput;
            SpaceRaceGame.SetUpPlayers();
        }

        private static void RunGame()
        {
            bool gameFinished = false;
            int round = 1;
            while (!gameFinished)
            {
                Console.Write("\nPress Enter to play a round ...");
                Console.ReadLine();

                if (round == 1) { Console.WriteLine("\n\tFirst Round\n"); }
                else { Console.WriteLine("\n\tNext Round\n"); }

                SpaceRaceGame.PlayOneRound();

                for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
                {
                    if (SpaceRaceGame.Players[i].AtFinish) { gameFinished = true; }
                    string name = SpaceRaceGame.names[i];
                    string square = "square " + SpaceRaceGame.Players[i].Location.Number;
                    int fuel = SpaceRaceGame.Players[i].RocketFuel;
                    Console.WriteLine("\t" + name + " on " + square + " with " + fuel + " yottawatt of power remaining");
                }

                round++;
            }
        }

        private static void FinishGame()
        {
            Console.WriteLine("\n\tThe following player(s) finished the game");
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                if (SpaceRaceGame.Players[i].AtFinish) { Console.WriteLine("\n\t\t" + SpaceRaceGame.names[i]); }
            }

            Console.WriteLine("\n\tIndividual players finished with the at the locations specified.");
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                string name = SpaceRaceGame.names[i];
                string square = "square " + SpaceRaceGame.Players[i].Location.Number;
                int fuel = SpaceRaceGame.Players[i].RocketFuel;
                Console.WriteLine("\n\t\t" + name + " with " + fuel + " yottawatt of power at " + square);
            }

            Console.Write("\n\tPress Enter to continue...");
        }

        private static bool PlayAgain()
        {
            bool correctInput = false;
            bool playAgain = false;

            Console.WriteLine("\n\n\n\n\n");
            while (!correctInput)
            {
                Console.Write("\tPlay Again? (Y or N): ");
                string input = Console.ReadLine();
                if ("Y" == input) { playAgain = true; correctInput = true; }
                else if ("N" == input) { playAgain = false; correctInput = true; }
            }

            if (!playAgain) { Console.WriteLine("\n\n\tThanks for playing Space Race.\n"); }

            return playAgain;
        }

    }//end Console class
}
