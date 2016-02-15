using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            GameData game = new GameData
            {
                GameID = Guid.NewGuid().ToString(),
                GameName = "Gear Up"
            };

            Player player = new Player { playerId = Guid.NewGuid().ToString(),
                                         firstName = "Paul",
                                          GamerTag = "Post Dark",
                                             XP = 1000};

            GameScore score =
                        new GameScore
                        {
                            ScoreID = Guid.NewGuid().ToString(),
                            PlayerID = player.playerId,
                            GameID = game.GameID,
                            score = 600
                        };

            Console.WriteLine("Game is {0} ", game.ToString());
            Console.WriteLine("Player is {0}", player.ToString());
            Console.WriteLine("Score is {0}", score.ToString());
            Console.ReadKey();
        }
    }
}
