using System;
using System.Drawing;
using System.Windows.Forms;
using Game_Logic_Class;
using Object_Classes;

namespace GUI_Class
{
    public partial class SpaceRaceForm : Form
    {
        // The numbers of rows and columns on the screen.
        const int NUM_OF_ROWS = 7;
        const int NUM_OF_COLUMNS = 8;

        // When we update what's on the screen, we show the movement of a player 
        // by removing them from their old square and adding them to their new square.
        // This enum makes it clear that we need to do both.
        enum TypeOfGuiUpdate { AddPlayer, RemovePlayer };

        // Enum used for a switch in ToggleEnabledObjects.
        enum GameStatus { StartGame, EndGame, FirstRound, StartRound, EndRound, RadioSelection };

        // Dice for single step.
        private static Die die1 = new Die(), die2 = new Die();

        // Declaring variables used between functions.
        bool firstRound;
        bool singleStep;
        int currentPlayer;
        

        public SpaceRaceForm()
        {
            InitializeComponent();

            Board.SetUpBoard();
            ResizeGUIGameBoard();
            SetUpGUIGameBoard();
            SetupPlayersDataGridView();
            DetermineNumberOfPlayers();
            SpaceRaceGame.SetUpPlayers();
            PrepareToPlay();
        }


        /// <summary>
        /// Handle the Exit button being clicked.
        /// Pre:  the Exit button is clicked.
        /// Post: the game is terminated immediately
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


        /// <summary>
        /// Resizes the entire form, so that the individual squares have their correct size, 
        /// as specified by SquareControl.SQUARE_SIZE.  
        /// This method allows us to set the entire form's size to approximately correct value 
        /// when using Visual Studio's Designer, rather than having to get its size correct to the last pixel.
        /// Pre:  none.
        /// Post: the board has the correct size.
        /// </summary>
        private void ResizeGUIGameBoard()
        {
            const int SQUARE_SIZE = SquareControl.SQUARE_SIZE;
            int currentHeight = tableLayoutPanel.Size.Height;
            int currentWidth = tableLayoutPanel.Size.Width;
            int desiredHeight = SQUARE_SIZE * NUM_OF_ROWS;
            int desiredWidth = SQUARE_SIZE * NUM_OF_COLUMNS;
            int increaseInHeight = desiredHeight - currentHeight;
            int increaseInWidth = desiredWidth - currentWidth;
            this.Size += new Size(increaseInWidth, increaseInHeight);
            tableLayoutPanel.Size = new Size(desiredWidth, desiredHeight);

        }// ResizeGUIGameBoard


        /// <summary>
        /// Creates a SquareControl for each square and adds it to the appropriate square of the tableLayoutPanel.
        /// Pre:  none.
        /// Post: the tableLayoutPanel contains all the SquareControl objects for displaying the board.
        /// </summary>
        private void SetUpGUIGameBoard()
        {
            for (int squareNum = Board.START_SQUARE_NUMBER; squareNum <= Board.FINISH_SQUARE_NUMBER; squareNum++)
            {
                Square square = Board.Squares[squareNum];
                SquareControl squareControl = new SquareControl(square, SpaceRaceGame.Players);
                AddControlToTableLayoutPanel(squareControl, squareNum);
            }// end for
        }// end SetupGameBoard


        private void AddControlToTableLayoutPanel(Control control, int squareNum)
        {
            int screenRow = 0;
            int screenCol = 0;

            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            tableLayoutPanel.Controls.Add(control, screenCol, screenRow);
        }// end Add Control


        /// <summary>
        /// For a given square number, tells you the corresponding row and column number
        /// on the TableLayoutPanel.
        /// Pre:  none.
        /// Post: returns the row and column numbers, via "out" parameters.
        /// </summary>
        /// <param name="squareNumber">The input square number.</param>
        /// <param name="rowNumber">The output row number.</param>
        /// <param name="columnNumber">The output column number.</param>
        private static void MapSquareNumToScreenRowAndColumn(int squareNum, out int screenRow, out int screenCol)
        {
            screenRow = 6 - squareNum / 8;
            if (screenRow % 2 == 1) { screenCol = 7 - squareNum % 8; }
            else { screenCol = squareNum % 8; }
        }//end MapSquareNumToScreenRowAndColumn
        

        private void SetupPlayersDataGridView()
        {
            // Stop the playersDataGridView from using all Player columns.
            playerDataGridView.AutoGenerateColumns = false;

            // Tell the playersDataGridView what its real source of data is.
            playerDataGridView.DataSource = SpaceRaceGame.Players;
        }// end SetUpPlayersDataGridView



        /// <summary>
        /// Obtains the current "selected item" from the ComboBox
        ///  and
        ///  sets the NumberOfPlayers in the SpaceRaceGame class.
        ///  Pre: none
        ///  Post: NumberOfPlayers in SpaceRaceGame class has been updated
        /// </summary>
        private void DetermineNumberOfPlayers()
        {
            // Store the SelectedItem property of the ComboBox in a string
            string strNumPlayers = playersComboBox.Text;

            // Parse string to a number
            int numPlayers = int.Parse(strNumPlayers);

            // Set the NumberOfPlayers in the SpaceRaceGame class to that number
            SpaceRaceGame.NumberOfPlayers = numPlayers;

        }//end DetermineNumberOfPlayers

        /// <summary>
        /// The players' tokens are placed on the Start square
        /// </summary>
        private void PrepareToPlay()
        {
            // Toggle objects for starting the game.
            ToggleEnabledObjects(GameStatus.StartGame);

            // Set first round.
            firstRound = true;

            // Update players' gui.
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);

        }//end PrepareToPlay()


        /// <summary>
        /// Tells you which SquareControl object is associated with a given square number.
        /// Pre:  a valid squareNumber is specified; and
        ///       the tableLayoutPanel is properly constructed.
        /// Post: the SquareControl object associated with the square number is returned.
        /// </summary>
        /// <param name="squareNumber">The square number.</param>
        /// <returns>Returns the SquareControl object associated with the square number.</returns>
        private SquareControl SquareControlAt(int squareNum)
        {
            int screenRow;
            int screenCol;

            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            return (SquareControl)tableLayoutPanel.GetControlFromPosition(screenCol, screenRow);
        }


        /// <summary>
        /// Tells you the current square number of a given player.
        /// Pre:  a valid playerNumber is specified.
        /// Post: the square number of the player is returned.
        /// </summary>
        /// <param name="playerNumber">The player number.</param>
        /// <returns>Returns the square number of the player.</returns>
        private int GetSquareNumberOfPlayer(int playerNumber)
        {
            int playerLocation = SpaceRaceGame.Players[playerNumber].Location.Number;
            return playerLocation;
        }//end GetSquareNumberOfPlayer


        /// <summary>
        /// When the SquareControl objects are updated (when players move to a new square),
        /// the board's TableLayoutPanel is not updated immediately.  
        /// Each time that players move, this method must be called so that the board's TableLayoutPanel 
        /// is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the board's TableLayoutPanel shows the latest information 
        ///       from the collection of SquareControl objects in the TableLayoutPanel.
        /// </summary>
        private void RefreshBoardTablePanelLayout()
        {
            // Un.comment the following line once you've added the tableLayoutPanel to your form.
            tableLayoutPanel.Invalidate(true);
        }


        /// <summary>
        /// When the Player objects are updated (location, etc),
        /// the players DataGridView is not updated immediately.  
        /// Each time that those player objects are updated, this method must be called 
        /// so that the players DataGridView is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the players DataGridView shows the latest information 
        ///       from the collection of Player objects in the SpaceRaceGame.
        /// </summary>
        private void UpdatesPlayersDataGridView()
        {
            SpaceRaceGame.Players.ResetBindings();
        }


        /// <summary>
        /// At several places in the program's code, it is necessary to update the GUI board,
        /// so that player's tokens are removed from their old squares
        /// or added to their new squares. E.g. at the end of a round of play or 
        /// when the Reset button has been clicked.
        /// 
        /// Moving all players from their old to their new squares requires this method to be called twice: 
        /// once with the parameter typeOfGuiUpdate set to RemovePlayer, and once with it set to AddPlayer.
        /// In between those two calls, the players locations must be changed. 
        /// Otherwise, you won't see any change on the screen.
        /// 
        /// Pre:  the Players objects in the SpaceRaceGame have each players' current locations
        /// Post: the GUI board is updated to match 
        /// </summary>
        private void UpdatePlayersGuiLocations(TypeOfGuiUpdate typeOfGuiUpdate)
        {
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                SquareControl square = SquareControlAt(SpaceRaceGame.Players[i].Location.Number);
                if (typeOfGuiUpdate == TypeOfGuiUpdate.AddPlayer) { square.ContainsPlayers[i] = true; }
                else { square.ContainsPlayers[i] = false; }
            }

            RefreshBoardTablePanelLayout();

        } //end UpdatePlayersGuiLocations
        
        
        /// <summary>
        /// Plays the game on click. Including rolling dice, moving players tokens and testing if the game has finished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rollDiceButton_Click(object sender, EventArgs e)
        {
            // Not single step mode
            if (!singleStep)
            {
                // Round Toggled Objects
                if (firstRound) { ToggleEnabledObjects(GameStatus.FirstRound); firstRound = false; }
                ToggleEnabledObjects(GameStatus.StartRound);

                // Commence Round
                UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
                SpaceRaceGame.PlayOneRound();
                UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
                UpdatesPlayersDataGridView();

                // Round Toggled Objects
                ToggleEnabledObjects(GameStatus.EndRound);
                
                // Test Players
                TestGameOver();
            }
            
            // Single step mode
            else
            {
                // First Round
                if (firstRound)
                {
                    ToggleEnabledObjects(GameStatus.FirstRound);
                    currentPlayer = 0;
                    firstRound = false;
                }

                // Toggle Objects if Round Start
                if (currentPlayer == 0) { ToggleEnabledObjects(GameStatus.StartRound); }
                
                // Play for currentPlayer
                if (currentPlayer < SpaceRaceGame.NumberOfPlayers)
                {
                    UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
                    SpaceRaceGame.Players[currentPlayer].Play(die1, die2);
                    UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
                    UpdatesPlayersDataGridView();
                }

                // Toggle Objects if Round Ended
                if (currentPlayer == SpaceRaceGame.NumberOfPlayers - 1) { ToggleEnabledObjects(GameStatus.EndRound); }

                // Update currentPlayer
                currentPlayer++;
                currentPlayer %= SpaceRaceGame.NumberOfPlayers;

                // Test Game Over
                TestGameOver();
            }
        }

        /// <summary>
        /// Tests if the game is finished and displays a message if true.
        /// </summary>
        /// <returns></returns>
        private bool TestGameOver()
        {
            SpaceRaceGame.TestPlayers(out bool playersAtFinish, out bool playersLostPower);
            bool gameOver = playersAtFinish | playersLostPower;

            if (gameOver)
            {
                // Toggle Objects
                ToggleEnabledObjects(GameStatus.EndGame);

                // Game Results
                string message = "";
                if (playersAtFinish)
                {
                    for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
                    { if (SpaceRaceGame.Players[i].AtFinish) { message += "\n\t" + SpaceRaceGame.Players[i].Name; } }
                    MessageBox.Show("The following player(s) finished the game\n" + message);
                }
                else
                {
                    MessageBox.Show("All players lost power!");
                }
            }

            return gameOver;
        }

        /// <summary>
        /// Function to toggle form objects depending on game events.
        /// </summary>
        /// <param name="option"></param>
        private void ToggleEnabledObjects(GameStatus option)
        {
            switch (option)
            {
                case GameStatus.StartGame:
                    playerDataGridView.Enabled = true;
                    rollDiceButton.Enabled = true;
                    playersComboBox.Enabled = true;
                    groupBox1.Enabled = true;
                    gameResetButton.Enabled = false;
                    rollDiceButton.Enabled = false;
                    break;

                case GameStatus.EndGame:
                    gameResetButton.Enabled = true;
                    rollDiceButton.Enabled = false;
                    break;

                case GameStatus.FirstRound:
                    playerDataGridView.Enabled = false;
                    playersComboBox.Enabled = false;
                    break;

                case GameStatus.StartRound:
                    gameResetButton.Enabled = false;
                    exitButton.Enabled = false;
                    break;

                case GameStatus.EndRound:
                    gameResetButton.Enabled = true;
                    exitButton.Enabled = true;
                    break;

                case GameStatus.RadioSelection:
                    rollDiceButton.Enabled = true;
                    groupBox1.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Function to update # players when combo box is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update GUI
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            DetermineNumberOfPlayers();
            SpaceRaceGame.SetUpPlayers();
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
        }

        /// <summary>
        /// Button to reset the game to starting conditions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameResetButton_Click(object sender, EventArgs e)
        {
            // Update player positions
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            SpaceRaceGame.SetUpPlayers();
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            UpdatesPlayersDataGridView();

            // Start game logic
            firstRound = true;
            yesRadioButton.Checked = false;
            noRadioButton.Checked = false;
            ToggleEnabledObjects(GameStatus.StartGame);
            playersComboBox.SelectedItem = "6";
        }


        // Yes Radio Button
        private void yesRadioButton_Click(object sender, EventArgs e)
        {
            singleStep = true;
            ToggleEnabledObjects(GameStatus.RadioSelection);
        }

        // No Radio Button
        private void noRadioButton_Click(object sender, EventArgs e)
        {
            singleStep = false;
            ToggleEnabledObjects(GameStatus.RadioSelection);
        }

        /// <summary>
        /// Plays game from start to finish after showing a spooky popup message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spooky Popup Message!");
            groupBox1.Enabled = false;

            bool gameOver = false;
            while (!gameOver)
            {
                // Begin Round ToggleObjects
                if (firstRound) { ToggleEnabledObjects(GameStatus.FirstRound); }
                firstRound = false;
                ToggleEnabledObjects(GameStatus.StartRound);

                // Play game
                UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
                SpaceRaceGame.PlayOneRound();
                UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
                UpdatesPlayersDataGridView();

                // End Round ToggleObjects
                ToggleEnabledObjects(GameStatus.EndRound);

                // Test Game Over
                gameOver = TestGameOver();
            }
        }
    }// end class
}
