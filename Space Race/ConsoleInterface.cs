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

                SpaceRaceGame.TestPlayers(out bool playersAtFinish, out bool playersLostPower);
                if (playersAtFinish || playersLostPower) { gameFinished = true; }

                for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
                {
                    string name = SpaceRaceGame.names[i];
                    string square = "square " + SpaceRaceGame.Players[i].Location.Name;
                    int fuel = SpaceRaceGame.Players[i].RocketFuel;
                    Console.WriteLine("\t{0} on {1} with {2} yottawatt of power remaining", name, square, fuel);
                }

                //debug lost power-.
                //for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++) { SpaceRaceGame.Players[i].RocketFuel = 0; }
                
                round++;
            }
        }

        private static void FinishGame()
        {
            SpaceRaceGame.TestPlayers(out bool playersAtFinish, out bool playersLostPower);
            if (playersLostPower) { Console.WriteLine("\n\tAll players lost power!"); }
            else { Console.WriteLine("\n\tThe following player(s) finished the game"); }

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
                Console.WriteLine("\n\t\t{0} with {1} yottawatt of power at {2}", name, square, fuel);
            }

            Console.Write("\n\tPress Enter to continue...");
            Console.ReadLine();
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

                if ("Y" == input || "y" == input) { playAgain = true; correctInput = true; }
                else if ("N" == input || "n" == input) { playAgain = false; correctInput = true; }
            }

            if (!playAgain) { Console.WriteLine("\n\n\tThanks for playing Space Race.\n"); }

            return playAgain;
        }

        //private static void TestPlayers(out bool playersAtFinish, out bool playersLostPower)
        //{
        //    playersAtFinish = false;
        //    playersLostPower = false;
        //    int playersHasPower = 0;

        //    for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
        //    {
        //        if (SpaceRaceGame.Players[i].AtFinish) { playersAtFinish = true; }
        //        if (!SpaceRaceGame.Players[i].HasPower) { playersHasPower++; }
        //    }

        //    if (playersHasPower == SpaceRaceGame.NumberOfPlayers) { playersLostPower = true; }
        //}

    }//end Console class
}
