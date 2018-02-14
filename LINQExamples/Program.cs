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

            var selected = _gobjs.Collectables
                                 .Where(s => s.selected == true);
            foreach (var item in selected)
                Console.WriteLine("Collected {0}", item.ToString());

            var orderedSelected = _gobjs.Collectables
                                        .Where(s => s.selected == true)
                                        .OrderBy(s => s.val);
            foreach (var item in orderedSelected)
                Console.WriteLine("Ordered Collected {0}", item.ToString());

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

            Console.ReadKey();
        }
    }
}
