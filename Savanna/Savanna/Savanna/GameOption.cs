//-----------------------------------------------------------------------
// <copyright file="GameOptions.cs" company="Accenture">
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
    /// Game options
    /// </summary>
    public enum GameOption
    {
        /// <summary>
        /// Default option in game
        /// </summary>
        None,

        /// <summary>
        /// Option to save game
        /// </summary>
        SaveGame,

        /// <summary>
        /// Option to load game
        /// </summary>
        LoadGame,

        /// <summary>
        /// Option to view one savanna
        /// </summary>
        ViewSingleSavanna,

        /// <summary>
        /// Option to view one savanna
        /// </summary>
        ViewSavannaOverview
    }
}
