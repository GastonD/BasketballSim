using System;

namespace BasketballSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Basketball Simulator!");
            
            var t1 = new Team(NameGenerator.Instance.getRndTeamName());
            var t2 = new Team(NameGenerator.Instance.getRndTeamName());

            Console.WriteLine("Hoy se enfrentan:");
            Console.WriteLine(t1.getName() + " vs. " + t2.getName());

            Console.WriteLine("");
            
            Game partido = new Game(t1, t2);
            partido.playGame();
            
        }




    }
}
