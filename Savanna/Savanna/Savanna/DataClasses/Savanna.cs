//-----------------------------------------------------------------------
// <copyright file="Savanna.cs" company="Accenture">
// <author>Janis Kacens</author>
// </copyright>
//-----------------------------------------------------------------------

namespace SavannaGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that contains information about a single savanna
    /// </summary>
    [DataContract]
    public class Savanna
    {
        /// <summary>
        /// Gets or sets integer that displays the current day in savanna
        /// </summary>
        [DataMember]
        public int DayCount { get; set; }

        /// <summary>
        /// Gets or sets list of all of the Animals in a Savanna
        /// </summary>
        [DataMember]
        public List<Animal> SavannaAnimals { get; set; }

        /// <summary>
        /// Gets or sets list of all of the Animals in a Savanna
        /// </summary>
        [DataMember]
        public int SavannaSizeX { get; set; }

        /// <summary>
        /// Gets or sets list of all of the Animals in a Savanna
        /// </summary>
        [DataMember]
        public int SavannaSizeY { get; set; }

        /// <summary>
        /// Gets or sets list of all of the Animals in a Savanna
        /// </summary>
        [DataMember]
        public int AntelopeCount { get; set; }

        /// <summary>
        /// Gets or sets list of all of the Animals in a Savanna
        /// </summary>
        [DataMember]
        public int LionCount { get; set; }
    }
}
