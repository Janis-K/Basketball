//-----------------------------------------------------------------------
// <copyright file="InitialData.cs" company="Accenture">
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
    /// Class to store the initial data needed for the game
    /// </summary>
    public class InitialData
    {
        /// <summary>
        /// Gets or sets integer of the height of the field
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets integer of the width of the field
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets integer of antelope count for each field
        /// </summary>
        public int AntelopeCount { get; set; }

        /// <summary>
        /// Gets or sets integer of lion count for each field
        /// </summary>
        public int LionCount { get; set; }

        /// <summary>
        /// Gets or sets integer for field count
        /// </summary>
        public int SavannaCount { get; set; }
    }
}
