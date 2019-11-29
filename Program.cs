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
            Console.WriteLine(t1.getName());
            Console.WriteLine("Ofensiva: " + t1.getOffRtg());
            Console.WriteLine("Defensiva: " + t1.getDefRtg());
            Console.WriteLine("Plantilla:");
            t1.showRoster();
            Console.WriteLine("");
            Console.WriteLine(t2.getName());
            Console.WriteLine("Ofensiva: " + t2.getOffRtg());
            Console.WriteLine("Defensiva: " + t2.getDefRtg());
            Console.WriteLine("Plantilla:");
            t2.showRoster();
            Console.WriteLine("");
            
            Game partido = new Game(t1, t2);
            partido.playGame();
            
        }




    }
}
