using System.Drawing;
using System.ComponentModel;
using Object_Classes;


namespace Game_Logic_Class
{
    public static class SpaceRaceGame
    {
        // Minimum and maximum number of players.
        public const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;
   
        private static int numberOfPlayers = 2;  //default value for test purposes only 
        public static int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            set
            {
                numberOfPlayers = value;
            }
        }

        public static string[] names = { "One", "Two", "Three", "Four", "Five", "Six" };  // default values
        
        // Only used in Part B - GUI Implementation, the colours of each player's token
        private static Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Yellow, Brushes.Red,
                                                                       Brushes.Orange, Brushes.White,
                                                                      Brushes.Green, Brushes.DarkViolet};
        /// <summary>
        /// A BindingList is like an array which grows as elements are added to it.
        /// </summary>
        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players
        {
            get
            {
                return players;
            }
        }

        // The pair of die
        private static Die die1 = new Die(), die2 = new Die();
       

        /// <summary>
        /// Set up the conditions for this game as well as
        ///   creating the required number of players, adding each player 
        ///   to the Binding List and initialize the player's instance variables
        ///   except for playerTokenColour and playerTokenImage in Console implementation.
        ///   
        ///     
        /// Pre:  none
        /// Post:  required number of players have been initialsed for start of a game.
        /// </summary>
        public static void SetUpPlayers() 
        {
            // Clear (if any) previous list
            players.Clear();


            // Assign player values
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(names[i]));
                players[i].RocketFuel = Player.INITIAL_FUEL_AMOUNT;
                players[i].Position = Board.StartSquare.Number;
                players[i].HasPower = true;
                players[i].Location = Board.StartSquare;
                players[i].PlayerTokenColour = playerTokenColours[i];

                // debug
                bool debug = false;
                if (debug)
                {
                    players[i].RocketFuel = 2;
                    players[i].Position = Board.Squares[Board.FINISH_SQUARE_NUMBER - 1].Number; players[i].Location = Board.Squares[Board.FINISH_SQUARE_NUMBER - 1];
                }
            }
        }

        /// <summary>
        ///  Plays one round of a game
        /// </summary>
        public static void PlayOneRound() 
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Play(die1, die2);
            }
        }

        /// <summary>
        /// Tests for whether the game is over. Returns true/false whether players are at the finish square as well
        /// as whether all players have lost power. (the two conditions that can cause the game to be over)
        /// </summary>
        /// <param name="playersAtFinish"></param>
        /// <param name="playersLostPower"></param>
        public static void TestPlayers(out bool playersAtFinish, out bool playersLostPower)
        {
            playersAtFinish = false;
            playersLostPower = false;
            int playersHasPower = NumberOfPlayers;

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                if (Players[i].AtFinish) { playersAtFinish = true; }
                if (!Players[i].HasPower) { playersHasPower--; }
            }

            if (playersHasPower == 0) { playersLostPower = true; }
        }
    }//end SnakesAndLadders
}