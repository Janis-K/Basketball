//-----------------------------------------------------------------------
// <copyright file="SurroundingState.cs" company="Accenture">
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
    /// Enumeration of the state of the surroundings
    /// </summary>
    public enum SurroundingState
    {
        /// <summary>
        /// Default enumeration
        /// </summary>
        None,

        /// <summary>
        /// Available enumeration
        /// </summary>
        Available,

        /// <summary>
        /// Prey enumeration
        /// </summary>
        Enemy,

        /// <summary>
        /// Hunter enumeration
        /// </summary>
        Friendly,

        /// <summary>
        /// Outside of field enumeration
        /// </summary>
        OutsideOfField,
    }
}
