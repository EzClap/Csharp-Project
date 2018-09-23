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
            /*                    
             Set up the board in Board class (Board.SetUpBoard)
             Determine number of players - initally play with 2 for testing purposes 
             Create the required players in Game Logic class
              and initialize players for start of a game             
             loop  until game is finished           
                call PlayGame in Game Logic class to play one round
                Output each player's details at end of round
             end loopC:\Users\under\Git repo\cantbegoogled\Space Race\ConsoleInterface.cs
             Determine if anyone has won
             Output each player's details at end of the game
           */

            Board.SetUpBoard();

            //set number for test:
            //SpaceRaceGame.NumberOfPlayers = 3;
            SpaceRaceGame.SetUpPlayers();

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


            DeterminePlayers();


            bool playAgain = true;
            bool gameFinished = false;
            while (playAgain)
            {
                DeterminePlayers();
                while (!gameFinished)
                {
                    //SpaceRaceGame.PlayOneRound();
                    Console.WriteLine("\tYeah woo spacey things! Yeah look at me go!");
                    Console.WriteLine("\tNext Rounds...");
                    if ("y" == Console.ReadLine()) { gameFinished = true; }
                }
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
            Console.WriteLine("Welcome to Space Race.\n");
        } //end DisplayIntroductionMessage

        /// <summary>
        /// Displays a prompt and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnter()
        {
            Console.Write("\nPress Enter to terminate program ...");
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
                    if (playerInput < 2 || playerInput > 6) { Console.WriteLine("Error: invalid number of players entered."); }
                    else { correctInput = true; }
                }
                catch (FormatException) { Console.WriteLine("Error: you must enter a valid number."); }
            }

            //SpaceRaceGame.SetUpPlayers();.
            for (int i = 0; i < playerInput; i++) { Console.WriteLine(SpaceRaceGame.names[i]); }//SpaceRaceGame.Add(new Player(SpaceRaceGame.names[i]); }
        }



    }//end Console class
}
