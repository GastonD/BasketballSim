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
            
            
            int totalGamesPlayed = 0;
            for(int i = 1; i < 6; i++){
                Game partido = new Game(t1, t2);
                partido.playGame();
                totalGamesPlayed = i;
            }
            Console.WriteLine("Se jugaron: "+totalGamesPlayed.ToString() + " partidos.");
            LeagueSimulation.Instance.showStats(totalGamesPlayed);
            //partido.playGame();
            
        }




    }
}
