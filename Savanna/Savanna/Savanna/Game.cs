//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="Accenture">
// <author>Janis Kacens</author>
// </copyright>
//-----------------------------------------------------------------------

namespace SavannaGame
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that handles game logic
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Random object that is used within the class
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Method that sets animal coordinates randomly
        /// </summary>
        /// <param name="animals">List that contains Animal objects</param>
        /// <param name="type">Type instance - Antelope or Lion</param>
        /// <param name="totalCount">Integer of the amount of animals need to be generated</param>
        /// <param name="height">Integer of the height of the field</param>
        /// <param name="width">Integer of the width of the field</param>
        /// <returns>List of Animal objects in their random places</returns>
        public List<Animal> SetAnimalsRandomly(List<Animal> animals, Type type, int totalCount, int height, int width)
        {
            while (this.AnimalCount(animals, type) < totalCount)
            {
                int randomXCoord = this.random.Next(0, height);
                int randomYCoord = this.random.Next(0, width);
                var obj = animals.Any(x => x.Coordinates.X == randomXCoord && x.Coordinates.Y == randomYCoord);
                if (!obj)
                {
                    Animal animal = null;
                    if (type == typeof(Lion))
                    {
                        animal = new Lion();
                    }

                    if (type == typeof(Antelope))
                    {
                        animal = new Antelope();
                    }

                    animal.Coordinates = new System.Drawing.Point(randomXCoord, randomYCoord);
                    animals.Add(animal);
                }
            }

            return animals;
        }

        /// <summary>
        /// Logic behind random animal movement
        /// </summary>
        /// <param name="animals">List of Animal objects</param>
        /// <param name="height">Integer of row count in the field</param>
        /// <param name="width">Integer of column count in the field</param>
        /// <returns>Updated list of Animals</returns>
        public List<Animal> AnimalAction(List<Animal> animals, int height, int width)
        {
            
            foreach (Animal animal in animals.ToList())
            {
                animal.Surroundings = UpdateSurroundingsAsync(animals, animal, height, width);
                this.MovementSelection(animals, animal);
                if (animal.MinEnemyDistance < 1.5 && animal.MinEnemyDistance > 0)
                {
                    this.KillAntelope(animals, animal);
                }
            }
            
            return animals;
        }

        /// <summary>
        /// Method that counts animals by specie
        /// </summary>
        /// <param name="animals">List of Animal objects</param>
        /// <param name="type">Type object</param>
        /// <returns>Integer of the total count of animals from the specie</returns>
        public int AnimalCount(List<Animal> animals, Type type)
        {
            var count = 0;

            if (type == typeof(Lion))
            {
                count = animals.OfType<Lion>().Count();
            }
            else
            {
                count = animals.OfType<Antelope>().Count();
            }

            return count;
        }

        /// <summary>
        /// Method to update Animal object's Surroundings list
        /// </summary>
        /// <param name="allAnimals">List of all of the Animal objects</param>
        /// <param name="animal">Instance of Animal</param>
        /// <param name="height">Integer of the height of the field</param>
        /// <param name="width">Integer of the width of the field</param>
        /// <returns>Instance of Animal with updated Surroundings property</returns>
        private List<Surroundings> UpdateSurroundingsAsync(List<Animal> allAnimals, Animal animal, int height, int width)
        {
            animal.Surroundings = new List<Surroundings>();
            var viewSight = animal.ViewOfSight;
            for (var i = animal.Coordinates.X - viewSight; i <= animal.Coordinates.X + viewSight; i++)
            {
                for (var j = animal.Coordinates.Y - viewSight; j <= animal.Coordinates.Y + viewSight; j++)
                {
                    var tempPoint = new Point(i, j);
                    Surroundings surrounding = new Surroundings();
                    var validField = this.IsAnimalInField(tempPoint, height, width);
                    if (!validField)
                    {
                        surrounding.State = SurroundingState.OutsideOfField;
                    }

                    var obj = allAnimals.Where(x => x.Coordinates.X == i && x.Coordinates.Y == j).FirstOrDefault();
                    if (obj != null)
                    {
                        if (animal is Lion)
                        {
                            if (obj is Antelope)
                            {
                                surrounding.State = SurroundingState.Enemy;
                            }
                            else
                            {
                                surrounding.State = SurroundingState.Friendly;
                            }
                        }
                        else
                        {
                            if (obj is Lion)
                            {
                                surrounding.State = SurroundingState.Enemy;
                            }
                            else
                            {
                                surrounding.State = SurroundingState.Friendly;
                            }
                        }
                    }

                    if (validField && obj == null)
                    {
                        surrounding.State = SurroundingState.Available;
                    }

                    surrounding.Coordinates = tempPoint;
                    animal.Surroundings.Add(surrounding);
                }
            }

            return animal.Surroundings;
        }

        /// <summary>
        /// Method that changes animal's position by one randomly
        /// </summary>
        /// <param name="allAnimals">List of Animal objects</param>
        /// <param name="animal">Animal object</param>
        /// <returns>List of Animal objects with changed coordinates</returns>
        private List<Animal> MovementSelection(List<Animal> allAnimals, Animal animal)
        {
            int enemyCount = this.GetEnemyCount(animal);
            List<Surroundings> availableMoves = new List<Surroundings>();
            availableMoves = this.GetAvailableMoves(animal);
            if (enemyCount == 0)
            {
                animal = this.MovementRandomizer(availableMoves, animal);
            }
            else
            {
                if (animal is Lion)
                {
                    allAnimals = this.CatchPrey(allAnimals, animal);
                }
                else if (animal is Antelope)
                {
                    allAnimals = this.EvadeHunter(availableMoves, allAnimals, animal);
                }
            }

            return allAnimals;
        }

        /// <summary>
        /// Method that makes Antelopes run away from the closest lion
        /// </summary>
        /// <param name="availableMoves">List of Surroundings objects that contains fields that are available to move to</param>
        /// <param name="animals">List of Animal objects</param>
        /// <param name="animal">Animal object</param>
        /// <returns>List of Animal objects with new coordinates</returns>
        private List<Animal> EvadeHunter(List<Surroundings> availableMoves, List<Animal> animals, Animal animal)
        {
            List<Surroundings> hunters = (from p in animal.Surroundings where p.State == SurroundingState.Enemy select p).ToList<Surroundings>();
            hunters = this.CalculateEnemyDistance(hunters, animal);
            var minEnemyDistance = this.GetMinimalDistanceToEnemy(hunters);
            var hunter = animal.Surroundings.FirstOrDefault(x => x.Distance == minEnemyDistance);
            var unitVector = this.CalculateUnitVector(animal, hunter);
            var newPoint = new Point(animal.Coordinates.X - ((int)unitVector.X * animal.MovementSpeed), animal.Coordinates.Y - ((int)unitVector.Y * animal.MovementSpeed));
            if (availableMoves.Any(x => x.Coordinates == newPoint))
            {
                animal.Coordinates = newPoint;
            }

            return animals;
        }

        /// <summary>
        /// Method that finds the closest distance to an enemy in the field of vision
        /// </summary>
        /// <param name="enemiesList">List of Surroundings objects that contain Enemy objects</param>
        /// <returns>Double value that denotes the distance to closest enemy</returns>
        private double GetMinimalDistanceToEnemy(List<Surroundings> enemiesList)
        {
            var minDistance = (from p in enemiesList select p.Distance).Min();
            return minDistance;
        }

        /// <summary>
        /// Method that makes lions catch antelopes if they are within their field of vision
        /// </summary>
        /// <param name="animals">List of Animal objects</param>
        /// <param name="animal">Animal object</param>
        /// <returns>List of Animals after a lion has attempted to catch a antelope</returns>
        private List<Animal> CatchPrey(List<Animal> animals, Animal animal)
        {
            List<Surroundings> preyList = (from p in animal.Surroundings where p.State == SurroundingState.Enemy select p).ToList<Surroundings>();
            preyList = this.CalculateEnemyDistance(preyList, animal);
            animal.MinEnemyDistance = this.GetMinimalDistanceToEnemy(preyList);
            var prey = preyList.FirstOrDefault(x => x.Distance == animal.MinEnemyDistance);
            if (prey.Distance > 1.5)
            {
                var unitVector = this.CalculateUnitVector(animal, prey);
                animal.Coordinates = new Point(animal.Coordinates.X + ((int)unitVector.X * animal.MovementSpeed), animal.Coordinates.Y + ((int)unitVector.Y * animal.MovementSpeed));
            }
            
            return animals;
        }

        /// <summary>
        /// Method that calculates the unit vector
        /// </summary>
        /// <param name="animal">Instance of Animal object</param>
        /// <param name="enemy">Instance of Surroundings object that has the closest enemy</param>
        /// <returns>Point object that contains unit vector in coordinate format</returns>
        private Point CalculateUnitVector(Animal animal, Surroundings enemy)
        {
            var vector = new Point(enemy.Coordinates.X - animal.Coordinates.X, enemy.Coordinates.Y - animal.Coordinates.Y);
            var length = Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
            var unitVector = new Point((int)Math.Round(vector.X / (float)length, 0), (int)Math.Round(vector.Y / (float)length, 0));
            return unitVector;
        }

        /// <summary>
        /// Method that calculates the distance to all of the enemy objects for an animal in its field of vision
        /// </summary>
        /// <param name="enemyList">List of Surroundings objects that has the enemies</param>
        /// <param name="animal">Animal object</param>
        /// <returns>Updated list of Surroundings</returns>
        private List<Surroundings> CalculateEnemyDistance(List<Surroundings> enemyList, Animal animal)
        {
            foreach (Surroundings enemy in enemyList)
            {
                var vector = new Point(enemy.Coordinates.X - animal.Coordinates.X, enemy.Coordinates.Y - animal.Coordinates.Y);
                var length = Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
                enemy.Distance = length;
            }
            
            return enemyList;
        }

        /// <summary>
        /// Method that removes the Antelope from the list if it is dead
        /// </summary>
        /// <param name="allAnimals">List of all Animal objects</param>
        /// <param name="animal">Animal object</param>
        /// <returns>List of Animal objects with a removed Antelope object</returns>
        private List<Animal> KillAntelope(List<Animal> allAnimals, Animal animal)
        {
            List<Surroundings> preyList = (from p in animal.Surroundings where p.State == SurroundingState.Enemy select p).ToList<Surroundings>();
            var prey = preyList.FirstOrDefault(x => x.Distance == animal.MinEnemyDistance);
            if (prey != null)
            {
                var obj = (from p in allAnimals where p.Coordinates == prey.Coordinates select p).First();
                allAnimals.Remove(obj);
            }

            return allAnimals;
        }

        /// <summary>
        /// Method that creates a list that has only the Surrounding objects within walking distance that are available
        /// </summary>
        /// <param name="animal">Animal object</param>
        /// <returns>List of Surroundings objects</returns>
        private List<Surroundings> GetAvailableMoves(Animal animal)
        {
            List<Surroundings> availableMoves = new List<Surroundings>();
            for (var i = animal.Coordinates.X - animal.MovementSpeed; i <= animal.Coordinates.X + animal.MovementSpeed; i++)
            {
                for (var j = animal.Coordinates.Y - animal.MovementSpeed; j <= animal.Coordinates.Y + animal.MovementSpeed; j++)
                {
                    var obj = animal.Surroundings.FirstOrDefault(x => x.Coordinates.X == i && x.Coordinates.Y == j && x.State == SurroundingState.Available);
                    if (obj != null)
                    {
                        availableMoves.Add(obj);
                    }
                }
            }

            return availableMoves;
        }

        /// <summary>
        /// Method that counts the enemies an animal has in its field of vision
        /// </summary>
        /// <param name="animal">Animal object</param>
        /// <returns>Integer of the count of enemies</returns>
        private int GetEnemyCount(Animal animal)
        {
            var count = (from Surroundings in animal.Surroundings where Surroundings.State == SurroundingState.Enemy select Surroundings).Count();
            return count;
        }

        /// <summary>
        /// Method that randomly selects the next position where to move out of a list of available spots
        /// </summary>
        /// <param name="availableMoves">List of available surroundings where Animal object can move to</param>
        /// <param name="animal">Animal object</param>
        /// <returns>Animal object with new coordinates</returns>
        private Animal MovementRandomizer(List<Surroundings> availableMoves, Animal animal)
        {
            int spaceToMoveTo = this.random.Next(availableMoves.Count);
            if (availableMoves.Count != 0)
            {
                animal.Coordinates = availableMoves[spaceToMoveTo].Coordinates;
            }

            return animal;
        }

        /// <summary>
        /// Method that checks whether a point is in the bounds of the field
        /// </summary>
        /// <param name="point">Point object that holds x and y coordinates</param>
        /// <param name="height">Integer of the height of the field</param>
        /// <param name="width">Integer of the width of the field</param>
        /// <returns>Boolean denoting whether the point is in the field</returns>
        private bool IsAnimalInField(Point point, int height, int width)
        {
            if (point.X >= 0 && point.Y >= 0 && point.X < height && point.Y < width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
