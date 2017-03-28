//-----------------------------------------------------------------------
// <copyright file="UserInput.cs" company="Accenture">
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
    /// Class that handles the user inputs
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Method that asks for user input of a number and parses it
        /// </summary>
        /// <returns>Integer, obtained from user</returns>
        public static int GetNumber()
        {
            string number = Console.ReadLine();
            int num;
            if (int.TryParse(number, out num))
            {
                return num;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Method that checks if a key has been pressed
        /// </summary>
        /// <returns>A char representing the key that was pressed</returns>
        public static GameOption SelectOption()
        {
            ConsoleKeyInfo cki;
            if (Console.KeyAvailable)
            {
                cki = Console.ReadKey(true);
                switch (cki.KeyChar)
                {
                    case 's':
                        return GameOption.SaveGame;
                    case 'l':
                        return GameOption.LoadGame;
                    case 'w':
                        return GameOption.ViewSingleSavanna;
                    case 'o':
                        return GameOption.ViewSavannaOverview;
                    default:
                        return GameOption.None;
                }
            }

            return GameOption.None;
        }
    }
}
