using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Models
{
    public class DataStorage
    {
        private string pathToStorage;

        private const string fileNamePlayers = "PlayersStorage.txt";
        private const string fileNameGames = "GamesStorage.txt";

        public DataStorage(string pathToStorage)
        {
            this.pathToStorage = pathToStorage;

            if (!Directory.Exists(pathToStorage))
            {
                Directory.CreateDirectory(pathToStorage);
            }            
        }

        public void Save(List<Game> games, List<Player> players)
        {
            Save(games);
            Save(players);
        }

        public void Save(List<Game> games)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(pathToStorage, fileNameGames)))  // Combine объединение пути (с /)
            {
                sw.WriteLine(JsonConvert.SerializeObject(games));
            }
        }

        public void Save(List<Player> players)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(pathToStorage, fileNamePlayers)))  // Combine объединение пути (с /)
            {
                sw.WriteLine(JsonConvert.SerializeObject(players));
            }
        }

        public void Load(out List<Game> games, out List<Player> players)
        {
            Load(out games);
            Load(out players);
        }

        public void Load(out List<Game> games)
        {
            using (StreamReader sr = new StreamReader(Path.Combine(pathToStorage, fileNameGames)))
            {
                games = JsonConvert.DeserializeObject<List<Game>>(sr.ReadToEnd());  //ReadToEnd - прочитать весь файл
            }
        }

        public void Load(out List<Player> players)
        {
            using (StreamReader sr = new StreamReader(Path.Combine(pathToStorage, fileNamePlayers)))
            {
                players = JsonConvert.DeserializeObject<List<Player>>(sr.ReadToEnd());
            }
        }        
    }
}
