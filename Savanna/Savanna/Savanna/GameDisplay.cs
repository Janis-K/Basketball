//-----------------------------------------------------------------------
// <copyright file="GameDisplay.cs" company="Accenture">
// <author>Janis Kacens</author>
// </copyright>
//-----------------------------------------------------------------------

namespace SavannaGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that outputs the game on display
    /// </summary>
    public class GameDisplay
    {
        /// <summary>
        /// Text to show when asking to specify a lion count
        /// </summary>
        private readonly string promptLionCount = "Specify lion count: ";

        /// <summary>
        /// Text to show when asking to specify an antelope count
        /// </summary>
        private readonly string promptAntelopeCount = "Specify antelope count: ";

        /// <summary>
        /// String to display when offering to save the game
        /// </summary>
        private readonly string notifyToSave = "Press S to save current state";

        /// <summary>
        /// String to display when offering to load a game
        /// </summary>
        private readonly string notifyToLoad = "Press L to load previously saved game";

        /// <summary>
        /// String to display when offering to load a game
        /// </summary>
        private readonly string notifyToWatch = "Press W to watch a single savanna";

        /// <summary>
        /// String to display when offering to load a game
        /// </summary>
        private readonly string notifyToWatchOverview = "Press O to view the savanna overview";

        /// <summary>
        /// String to display when a game has been loaded
        /// </summary>
        private readonly string loadSuccess = "Game has been loaded from disk";

        /// <summary>
        /// String to display when a game has not been loaded
        /// </summary>
        private readonly string loadFail = "Game failed to load from disk" + Environment.NewLine + "Press Any Key to Exit";

        /// <summary>
        /// String to display when asking to start simulation
        /// </summary>
        private readonly string askToSimulate = "Press any key to start simulation!";

        /// <summary>
        /// String to display when asking to enter the number of savannas
        /// </summary>
        private readonly string promptSavannaCount = "Enter the number of savannas: ";

        /// <summary>
        /// String to display when showing the index of the field
        /// </summary>
        private readonly string displayIndex = "Index";

        /// <summary>
        /// String to display when showing the index of the field
        /// </summary>
        private readonly string aliveLions = "Lions";

        /// <summary>
        /// String to display when showing the index of the field
        /// </summary>
        private readonly string aliveAntelopes = "Antelopes";

        /// <summary>
        /// String to display when showing the index of the field
        /// </summary>
        private readonly string currentDay = "Day";

        /// <summary>
        /// String to display when asking for index of a savanna
        /// </summary>
        private readonly string indexPrompt = "Input the index of the savanna you want to observe: ";

        /// <summary>
        /// String to display when prompting to input row count
        /// </summary>
        private readonly string height = "Input initial height of the field: ";

        /// <summary>
        /// String to display when prompting to input column count
        /// </summary>
        private readonly string width = "Input initial width of the field: ";

        /// <summary>
        /// String to display when showing an error
        /// </summary>
        private readonly string error = "There has been an error!";

        /// <summary>
        /// Method to display text to ask field height
        /// </summary>
        public void HeightPrompt()
        {
            Console.Write(this.height);
        }

        /// <summary>
        /// Method to display text to ask field height
        /// </summary>
        public void WidthPrompt()
        {
            Console.Write(this.width);
        }

        /// <summary>
        /// Method to display text to ask for lion count
        /// </summary>
        public void LionCountPrompt()
        {
            Console.Write(this.promptLionCount);
        }

        /// <summary>
        /// Method to display text to ask for antelope count
        /// </summary>
        public void AntelopeCountPrompt()
        {
            Console.Write(this.promptAntelopeCount);
        }

        /// <summary>
        /// Method to inform a user of successful load
        /// </summary>
        public void LoadSuccess()
        {
            Console.WriteLine(this.loadSuccess);
        }

        /// <summary>
        /// Method to display when a file load has not been successful
        /// </summary>
        public void LoadFail()
        {
            Console.WriteLine(this.loadFail);
            Console.ReadLine();
        }

        /// <summary>
        /// Method to output an offer to user to load a game
        /// </summary>
        public void Load()
        {
            Console.WriteLine(this.notifyToLoad);
        }

        /// <summary>
        /// Method to output notification for watching a single field
        /// </summary>
        public void Watch()
        {
            Console.WriteLine(this.notifyToWatch);
        }

        /// <summary>
        /// Method to output notification for watching the overview of fields
        /// </summary>
        public void WatchOverview()
        {
            Console.WriteLine(this.notifyToWatchOverview);
        }

        /// <summary>
        /// Method to output save offer to user
        /// </summary>
        public void Save()
        {
            Console.WriteLine(this.notifyToSave);
        }

        /// <summary>
        /// Method to ask user to input the savanna count
        /// </summary>
        public void SavannaCountPrompt()
        {
            Console.Write(this.promptSavannaCount);
        }

        /// <summary>
        /// Method to ask user for the index of savanna that will be observed
        /// </summary>
        public void SavannaIndexPrompt()
        {
            Console.Write(this.indexPrompt);
        }

        /// <summary>
        /// Method to display text to ask to start simulation
        /// </summary>
        public void AskToStartSimulation()
        {
            Console.WriteLine(this.askToSimulate);
            Console.ReadLine();
        }

        /// <summary>
        /// Method to show the savanna on display
        /// </summary>
        /// <param name="height">height of the field</param>
        /// <param name="width">width of the field</param>
        /// <param name="animals">List of Animal objects</param>
        public void ShowSavanna(Savanna savanna)
        {
            this.AdjustConsoleSize(savanna.SavannaSizeX, savanna.SavannaSizeY);
            
            StringBuilder displayOutput = new StringBuilder();
            for (int i = 0; i < savanna.SavannaSizeX; i++)
            {
                for (int j = 0; j < savanna.SavannaSizeY; j++)
                {
                    var tempAnimal = savanna.SavannaAnimals.Find(x => x.Coordinates.X == i && x.Coordinates.Y == j);
                    if (tempAnimal != null)
                    {
                        bool isAntelope = tempAnimal.GetType() == typeof(Antelope);
                        if (isAntelope)
                        {
                            displayOutput.Append("A");
                        }
                        else
                        {
                            displayOutput.Append("L");
                        }
                    }
                    else
                    {
                        displayOutput.Append("_");
                    }
                }

                displayOutput.AppendLine();
            }

            Console.Clear();
            Console.WriteLine(displayOutput.ToString());
        }

        /// <summary>
        /// Method to adjust the console size to fit the field
        /// </summary>
        /// <param name="width">Field width</param>
        /// <param name="height">Field height</param>
        public void AdjustConsoleSize(int width, int height)
        {
            if (Console.LargestWindowHeight > height && Console.WindowHeight < height)
            {
                Console.WindowHeight = height + 3;
            }

            if (Console.LargestWindowHeight < height)
            {
                Console.WindowHeight = Console.LargestWindowHeight;
            }

            if (Console.LargestWindowWidth > width && Console.WindowWidth < width)
            {
                Console.WindowWidth = width + 3;
            }

            if (Console.LargestWindowWidth < width)
            {
                Console.WindowWidth = Console.LargestWindowWidth;
            }
        }

        /// <summary>
        /// Method that displays overview of one field of cells
        /// </summary>
        /// <param name="savannas">List of Savanna objects</param>
        public void ShowOverview(List<Savanna> savannas)
        {
            Console.Clear();
            if (savannas != null)
            {
                Console.WriteLine(string.Format("|{0,10}|{1,12}|{2,10}|{3,10}|", this.displayIndex, this.aliveAntelopes, this.aliveLions, this.currentDay));
                for (var i = 0; i < savannas.Count(); i++)
                {
                    Console.WriteLine(string.Format("|{0,10}|{1,12}|{2,10}|{3,10}|", i, savannas[i].AntelopeCount, savannas[i].LionCount, savannas[i].DayCount));
                }
            }
            else
            {
                Console.WriteLine(error);
            }
        }
    }
}
