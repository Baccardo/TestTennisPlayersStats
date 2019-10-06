using System.Collections.Generic;

namespace TennisPlayersWebApi.Models
{
    public class Player
    {
        public int id;
        public string firstname;
        public string lastname;
        public string shortname;
        public string sex;
        public Country country;
        public string picture;
        public Data data;
    }

    public class Country
    {
        public string picture;
        public string code;
    }

    public class Data
    {
        public int rank;
        public int points;
        public long weight;
        public int height;
        public int age;
        public List<int> last;
    }

    public class TennisPlayers
    {
        public List<Player> players { get; set; }
    }
}