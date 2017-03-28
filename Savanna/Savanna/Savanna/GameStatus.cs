//-----------------------------------------------------------------------
// <copyright file="GameStatus.cs" company="Accenture">
// <author>Janis Kacens</author>
// </copyright>
//-----------------------------------------------------------------------

namespace SavannaGame
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that handles saving and loading of game statuses
    /// </summary>
    public class GameStatus
    {
        /// <summary>
        /// String that contains the file name in which the xml file will be written
        /// </summary>
        private readonly string filenameXML = "safari.xml";

        /// <summary>
        /// String that contains the file name in which the json file will be written
        /// </summary>
        private readonly string filenameJson = "safari.json";

        /// <summary>
        /// Method to save the current game state to a XML file
        /// </summary>
        /// <param name="savannas">List that contains all of the Savanna objects</param>
        public void SaveGameXML(List<Savanna> savannas)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<Savanna>), new[] { typeof(Antelope), typeof(Lion) });
            using (var stream = new FileStream(this.filenameXML, FileMode.Create, FileAccess.Write))
            {
                serializer.WriteObject(stream, savannas);
            }          
        }

        /// <summary>
        /// Method to save the current game state to a Json file
        /// </summary>
        /// <param name="savannas"></param>
        public void SaveGameJson(List<Savanna> savannas)
        {
            var serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(this.filenameJson))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, savannas);
            }
        }

        /// <summary>
        /// Method to load list from a XML file
        /// </summary>
        /// <returns>List of Savanna objects loaded from a file</returns>
        public List<Savanna> LoadGameXML()
        {
            DataContractSerializer myDeserializer = new DataContractSerializer(typeof(List<Savanna>), new[] { typeof(Antelope), typeof(Lion) });
            List<Savanna> loadedData;
            using (FileStream myFileStream = new FileStream(this.filenameXML, FileMode.Open))
            {
                loadedData = (List<Savanna>)myDeserializer.ReadObject(myFileStream);
            }

            return loadedData;
        }

        /// <summary>
        /// Method to load list from a Json file
        /// </summary>
        /// <returns>List of Savanna objects loaded from a file</returns>
        public List<Savanna> LoadGameJson()
        {
            List<Savanna> savanna;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(this.filenameJson))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                savanna = (List<Savanna>)serializer.Deserialize(streamReader, typeof(List<Savanna>));
            }
            
            return savanna;
        }

        /// <summary>
        /// Method that checks if the save game file exists
        /// </summary>
        /// <returns>Boolean value of whether the file exists</returns>
        public bool DoesFileExist()
        {
            if (File.Exists(this.filenameXML) || File.Exists(this.filenameJson))
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
