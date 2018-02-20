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
            GameObjects _gobjs = new GameObjects();

            foreach (var item in _gobjs.Collectables)
            {
                if (item.selected) Console.WriteLine("Selected {0} with value {1}", item.id, item.val);
                else Console.WriteLine("Non-Selected {0} with value {1}", item.id,item.val);
            }

            var selected = _gobjs.Collectables
                                 .Where(s => s.selected == true);
            foreach (var item in selected)
                Console.WriteLine("Collected {0}", item.ToString());

            var orderedSelected = _gobjs.Collectables
                                        .Where(s => s.selected == false)
                                        .OrderByDescending(s => s.val);
            foreach (var item in orderedSelected)
                Console.WriteLine("Ordered descending Not Collected {0}", item.ToString());

            var _playerXPDetails = _gobjs.players
                .Select(p => new {
                                    Name = String.Concat(p.firstName, " ", p.sceondName),
                                    PlayerXP = p.XP });

            foreach (var pxp in _playerXPDetails)
                Console.WriteLine("Player XP is {0}", 
                    String.Concat(pxp.Name, " ", pxp.PlayerXP.ToString()));


            var playerScores = (from p in _gobjs.players
                                join s in _gobjs.scores
                                on p.playerId equals s.PlayerID
                                join g in _gobjs.games
                                on  s.GameID equals g.GameID
                                select new { Game = g.GameName,
                                            Name = String.Concat(p.firstName, " ", p.sceondName),
                                             PlayerScore = s.score});
            foreach (var item in playerScores)
                Console.WriteLine("Player Score for {0} ", String.Concat("Game name ", item.Game," ",item.Name," score ", item.PlayerScore.ToString())  );

            //foreach (var game in _gobjs.games)
            //    Console.WriteLine("Game is {0} ", game.ToString());
            //foreach (var player in _gobjs.players)
            //    Console.WriteLine("Player is {0}", player.ToString());
            //foreach (var score in _gobjs.scores)
            //    Console.WriteLine("Score is {0}", score.ToString());

            Console.WriteLine();
            var scoresGreaterThan500 = (from s in _gobjs.scores.Where(s=> s.score > 500)
                                        select new { ID = s.ScoreID, Scores = s.score });
            foreach (var item in scoresGreaterThan500)
            {
                Console.WriteLine("Score ID {0} : {1}",item.ID,item.Scores);
            }

            var allPlayersWithMoreThan250XP = (from p in _gobjs.players.Where(x => x.XP > 250)
                                               select new { PlayerId = p.playerId, XP = p.XP });


            foreach (var item in allPlayersWithMoreThan250XP)
            {
                Console.WriteLine("Player ID {0} : {1}", item.PlayerId, item.XP);
            }

            var playersWithGamerTagTwinny = _gobjs.players.Where(o => o.GamerTag == "Twinny");

            foreach (var item in playersWithGamerTagTwinny)
            {
                Console.WriteLine("Player ID {0}",item.playerId);
            }

            var scoreForTwinny = (from p in _gobjs.players.Where(o => o.GamerTag == "Twinny")
                                  join s in _gobjs.scores
                                  on p.playerId equals s.PlayerID
                                  select new { PlayerId = p.playerId, GamerTag = p.GamerTag, Score = s.score }
                                  );

            

            foreach (var item in scoreForTwinny)
            {
                Console.WriteLine("Player ID {0} {1} : {2}", item.PlayerId, item.GamerTag,item.Score);
            }



            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
