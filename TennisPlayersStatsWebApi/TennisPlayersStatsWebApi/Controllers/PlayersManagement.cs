using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TennisPlayersWebApi.Models;

namespace TennisPlayersStatsWebApi.Controllers
{
    public class PlayersManagement
    {
        public List<Player> GetAllPlayers(string filePath)
        {
            List<Player> loadedPlayers = null;

            try
            {
                var json = File.ReadAllText(filePath);
                TennisPlayers tennisPlayers = JsonConvert.DeserializeObject<TennisPlayers>(json);
                if (tennisPlayers != null)
                    loadedPlayers = tennisPlayers.players;
            }
            catch (JsonReaderException jsonReaderex)
            {
                Console.WriteLine(jsonReaderex.Message);
            }
            catch (FileNotFoundException fileNotFoundex)
            {
                Console.WriteLine(fileNotFoundex.Message);
            }
            return loadedPlayers;
        }

        public Player GetPlayerById(List<Player> playersList, int IdToFind)
        {
            return (playersList?.FirstOrDefault(p => p.id == IdToFind));
        }

        public Player DeletePlayerById(List<Player> playersList, int IdToDelete)
        {
            Player playerToDelete = playersList?.FirstOrDefault(p => p.id == IdToDelete);
            if (playerToDelete != null)
                playersList.Remove(playerToDelete);
            return playerToDelete;
        }
    }
}