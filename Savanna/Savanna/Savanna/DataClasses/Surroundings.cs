//-----------------------------------------------------------------------
// <copyright file="Surroundings.cs" company="Accenture">
// <author>Janis Kacens</author>
// </copyright>
//-----------------------------------------------------------------------

namespace SavannaGame
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that has surroundings of all of the Animal objects
    /// </summary>
    [DataContract]
    public class Surroundings
    {
        /// <summary>
        /// Gets or sets the state of the surroundings, i.e., occupied, available
        /// </summary>
        [DataMember]
        public SurroundingState State { get; set; }

        /// <summary>
        /// Gets or sets point objects denoting the coordinates of the field
        /// </summary>
        [DataMember]
        public Point Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the distance of a field with the Animal object
        /// </summary>
        [DataMember]
        public double Distance { get; set; }
    }
}
