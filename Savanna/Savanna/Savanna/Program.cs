//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Accenture">
// <author>Janis Kacens</author>
// </copyright>
//-----------------------------------------------------------------------

namespace SavannaGame
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Application's main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// List that holds all of the Cell objects
        /// </summary>
        private static List<Savanna> savannas;

        /// <summary>
        /// Application's entry point
        /// </summary>
        private static void Main()
        {
            StartGame();
        }

        /// <summary>
        /// Method that starts the game
        /// </summary>
        private static void StartGame()
        {
            var initialData = GetInitialData();
            initialData.SavannaCount = 3;
            savannas = GenerateSavannas(initialData);
            Simulate();
        }

        /// <summary>
        /// Method to get the starting data from the user
        /// </summary>
        /// <returns>InitialData object filled with initial data</returns>
        private static InitialData GetInitialData()
        {
            var display = new GameDisplay();
            var initialData = new InitialData();
            display.HeightPrompt();
            initialData.Height = UserInput.GetNumber();
            display.WidthPrompt();
            initialData.Width = UserInput.GetNumber();
            display.AntelopeCountPrompt();
            initialData.AntelopeCount = UserInput.GetNumber();
            display.LionCountPrompt();
            initialData.LionCount = UserInput.GetNumber();
            return initialData;
        }

        /// <summary>
        /// Method that simulates the game
        /// </summary>    
        private static void Simulate()
        {
            var display = new GameDisplay();
            var status = new GameStatus();
            bool displayOverview = true;
            var index = 0;
            while (true)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                if (displayOverview)
                {
                    display.ShowOverview(savannas);
                }
                else
                {
                    display.ShowSavanna(savannas[index]);
                }

                display.Save();
                display.Load();
                display.Watch();
                display.WatchOverview();

                for (int i = 0; i < 3; i++)
                {
                    Thread thr1 = new Thread(new ThreadStart(ApplyGameLogic(savannas[i])));
                }
                
                var input = UserInput.SelectOption();
                switch (input)
                {
                    case GameOption.SaveGame:
                        SaveCurrentState(savannas);
                        break;
                    case GameOption.ViewSingleSavanna:
                        display.SavannaIndexPrompt();
                        index = UserInput.GetNumber();
                        displayOverview = false;
                        break;
                    case GameOption.ViewSavannaOverview:
                        displayOverview = true;
                        break;
                    case GameOption.LoadGame:
                        if (status.DoesFileExist())
                        {
                            savannas = LoadCurrentState();
                        }
                        else
                        {
                            display.LoadFail();
                            Environment.Exit(0);
                        }

                        break;
                    default:
                        break;
                }
                sw.Stop();
                Debug.WriteLine(sw.Elapsed);
            }
        }

        /// <summary>
        /// Method that applies game logic to a single Savanna object
        /// </summary>
        /// <param name="savanna"></param>
        private static void ApplyGameLogic(Savanna savanna)
        {
            Game game = new Game();
            savanna.SavannaAnimals = game.AnimalAction(savanna.SavannaAnimals, savanna.SavannaSizeY, savanna.SavannaSizeX);
            savanna.AntelopeCount = game.AnimalCount(savanna.SavannaAnimals, typeof(Antelope));
            savanna.LionCount = game.AnimalCount(savanna.SavannaAnimals, typeof(Lion));
            savanna.DayCount++;
        }

        /// <summary>
        /// Method that generates a list of Savanna objects
        /// </summary>
        /// <param name="initialData">InitialData object instance</param>
        /// <returns>List of Savanna objects</returns>
        private static List<Savanna> GenerateSavannas(InitialData initialData)
        {
            Game game = new Game();
            List<Savanna> savannas = new List<Savanna>();
            for (int i = 0; i < initialData.SavannaCount; i++)
            {
                var animals = new List<Animal>();
                animals = game.SetAnimalsRandomly(animals, typeof(Antelope), initialData.AntelopeCount, initialData.Height, initialData.Width);
                animals = game.SetAnimalsRandomly(animals, typeof(Lion), initialData.LionCount, initialData.Height, initialData.Width);
                var savanna = new Savanna() { SavannaAnimals = animals, DayCount = 0, AntelopeCount = initialData.AntelopeCount, LionCount = initialData.LionCount, SavannaSizeX = initialData.Width, SavannaSizeY = initialData.Height };
                savannas.Add(savanna);
            }

            return savannas;
        }

        /// <summary>
        /// Method that handles the event of game being saved
        /// </summary>
        /// <param name="savannas">List of Savanna objects</param>
        private static void SaveCurrentState(List<Savanna> savannas)
        {
            var status = new GameStatus();
            var display = new GameDisplay();
            status.SaveGameJson(savannas);
            display.AskToStartSimulation();
        }

        /// <summary>
        /// Method that loads the a state of game from a file
        /// </summary>
        /// <returns>A list of Cell objects</returns>
        private static List<Savanna> LoadCurrentState()
        {
            var status = new GameStatus();
            var display = new GameDisplay();
            Console.Clear();
            display.LoadSuccess();
            display.AskToStartSimulation();
            return status.LoadGameJson();
        }
    }
}
