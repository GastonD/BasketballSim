using System;

namespace BasketballSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Basketball Simulator!");
            var t1 = new Team("Team One");
            var t2 = new Team("Team Two");

            Console.WriteLine("Hoy se enfrentan:");
            Console.WriteLine(t1.getName());
            Console.WriteLine("Ofensiva: " + t1.getOffRtg());
            Console.WriteLine("Defensiva: " + t1.getDefRtg());
            Console.WriteLine("");
            Console.WriteLine(t2.getName());
            Console.WriteLine("Ofensiva: " + t2.getOffRtg());
            Console.WriteLine("Defensiva: " + t2.getDefRtg());

            Game partido = new Game(t1, t2);
            partido.playGame();
            
        }




    }
}
