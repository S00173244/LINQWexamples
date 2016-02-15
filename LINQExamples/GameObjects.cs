using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    class GameObjects
    {
        List<Player> players = new List<Player>
        {
            new Player { playerId = Guid.NewGuid().ToString(),
                                         firstName = "Paul",
                                          GamerTag = "Post Dark",
                                             XP = 1000},

            new Player { playerId = Guid.NewGuid().ToString(),
                                         firstName = "Fred",
                                          GamerTag = "Twinny",
                                             XP = 250},
    };
        List<GameData> games = new List<GameData>
        {
            new GameData
            {
                GameID = Guid.NewGuid().ToString(),
                GameName = "Gear Up"
            }
        };
        List<GameScore> scores = new List<GameScore>();
        

            public GameObjects()
        {
            // Create the Game scores here as the Games and players will be created
        }
    }
    public class GameData
    {
        public string GameID { get; set; } // Key Field
        public string GameName { get; set; }

        public override string ToString()
        {
            return String.Concat("Game ID ", GameID, " Game Name ", GameName);
        }
    }

    public class GameScore
    {
        public string ScoreID { get; set; } // Key Field
        public string GameID { get; set; }
        public string PlayerID { get; set; }
        public int score { get; set; }

        public override string ToString()
        {
            return String.Concat(new string[] 
                            {"Score ", ScoreID," Game ID ", GameID," Player ID ",
                                PlayerID, " Score ",score.ToString() });
        }
    }
    public class Player
    {
        public string playerId; // Key Field
        public int XP { get; set; }
        public string GamerTag { get; set; }
        public string firstName { get; set; }

        public override string ToString()
        {
            return String.Concat(new string[]
                            {"PlayerID ", playerId," XP ", XP.ToString()," Gamer Tag ",
                                GamerTag, " first name ",firstName });
        }
    }

}
