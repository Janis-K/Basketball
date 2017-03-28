//-----------------------------------------------------------------------
// <copyright file="Animal.cs" company="Accenture">
// <author>Janis Kacens</author>
// </copyright>
//-----------------------------------------------------------------------

using System;

[assembly: CLSCompliant(true)]
namespace SavannaGame
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that describes Animal objects
    /// </summary>
    [DataContract]
    public class Animal 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Animal"/> class.
        /// </summary>
        public Animal()
        {
            this.MovementSpeed = 1;
            this.ViewOfSight = 3;
        }

        /// <summary>
        /// Gets or sets instance of Point class
        /// </summary>
        [DataMember]
        public Point Coordinates { get; set; }

        /// <summary>
        /// Gets or sets list of Surroundings objects
        /// </summary>
        [DataMember]
        public List<Surroundings> Surroundings { get; set; }
        
        /// <summary>
        /// Gets or sets the view sight for the animals
        /// </summary>
        [DataMember]
        public int ViewOfSight { get; set; }

        /// <summary>
        /// Gets or sets the movement speed of the animals
        /// </summary>
        [DataMember]
        public int MovementSpeed { get; set; }

        /// <summary>
        /// Gets or sets the distance to the closest enemy
        /// </summary>
        [DataMember]
        public double MinEnemyDistance { get; set; }
    }
}
