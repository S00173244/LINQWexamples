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
            
            foreach (var game in _gobjs.games)
                Console.WriteLine("Game is {0} ", game.ToString());
            foreach (var player in _gobjs.players)
                Console.WriteLine("Player is {0}", player.ToString());
            foreach (var score in _gobjs.scores)
                Console.WriteLine("Score is {0}", score.ToString());

            Console.ReadKey();
        }
    }
}
