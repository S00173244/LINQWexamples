using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    public class GameObjects
    {
        public List<Player> players = new List<Player>
        {
            new Player { playerId = Guid.NewGuid().ToString(),
                                         firstName = "Paul",
                                         sceondName = "Powell",
                                          GamerTag = "Post Dark",
                                             XP = 1000},

            new Player { playerId = Guid.NewGuid().ToString(),
                                         firstName = "Fred",
                                         sceondName = "Flinstone",
                                          GamerTag = "Twinny",
                                             XP = 100},

            new Player { playerId = Guid.NewGuid().ToString(),
                                         firstName = "Margaret",
                                         sceondName = "Muldooney",
                                          GamerTag = "Twinny",
                                             XP = 600},
            new Player { playerId = Guid.NewGuid().ToString(),
                                         firstName = "Bill",
                                         sceondName = "Bloggs",
                                          GamerTag = "Mahindy",
                                             XP = 250},
    };
        public List<GameData> games = new List<GameData>
        {
            new GameData
            {
                GameID = Guid.NewGuid().ToString(),
                GameName = "Gear Up"
            },
            new GameData
            {
                GameID = Guid.NewGuid().ToString(),
                GameName = "Game on"
            }
        };
        public List<GameScore> scores = new List<GameScore>();
        

            public GameObjects()
        {
            // Create the Game scores here as the Games and players will be created
            Random _randomScore = new Random();

            foreach (var g in games)
            {
                var randomPlayer = players
                        .Select(p => new { p.playerId, gid = Guid.NewGuid() })
                        .OrderBy(o => o.gid).Take(3).ToList();

                foreach (var p in randomPlayer)
                {
                    scores.Add(new GameScore
                    {
                        ScoreID = Guid.NewGuid().ToString(),
                        GameID = g.GameID,
                        PlayerID = p.playerId,
                        score = _randomScore.Next(5, 600)
                    });
                }

            }

        }
    }
    public class GameData
    {
        public string GameID { get; set; } // Key Field
        public string GameName { get; set; }

        public override string ToString()
        {
            return String.Concat(" Game Name ", GameName);
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
                            {" Game ID ", GameID," Player ID ",
                                PlayerID, " Score ",score.ToString() });
        }
    }
    public class Player
    {
        public string playerId; // Key Field
        public int XP { get; set; }
        public string GamerTag { get; set; }
        public string firstName { get; set; }
        public string sceondName { get; set; }

        public override string ToString()
        {
            return String.Concat(new string[]
                            {" XP ", XP.ToString()," Gamer Tag ",
                                GamerTag, " first name ",firstName });
        }
    }

}
