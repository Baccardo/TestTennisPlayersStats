using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TennisPlayersWebApi.Models;

namespace TennisPlayersStatsWebApi.Controllers
{
    public class PlayersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            PlayersManagement playersMgt = new PlayersManagement();
            List<Player> allPlayers = playersMgt.GetAllPlayers(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/headtohead.json"));
            if (allPlayers != null)
                allPlayers.Sort((p1, p2) => p1.id.CompareTo(p2.id));
            var sortedPlayersJson = JsonConvert.SerializeObject(allPlayers, Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(sortedPlayersJson, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage Get(int id)
        {
            PlayersManagement playersMgt = new PlayersManagement();
            List<Player> allPlayers = playersMgt.GetAllPlayers(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/headtohead.json"));
            Player playerFound = playersMgt.GetPlayerById(allPlayers, id);
            if (playerFound == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("404", Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            else
            {
                var playerFoundJson = JsonConvert.SerializeObject(playerFound, Formatting.Indented);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(playerFoundJson, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            PlayersManagement playersMgt = new PlayersManagement();
            List<Player> allPlayers = playersMgt.GetAllPlayers(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/headtohead.json"));
            Player playerToDelete = playersMgt.DeletePlayerById(allPlayers, id);
            if (playerToDelete == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("404", Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Player with Id " + id.ToString() + " is deleted", Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
        }
    }
}
