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

            playGame(t1, t2);
            
        }

        public static void playGame(Team t1, Team t2){
            int t1Score = 0;
            int t2Score = 0;

            if (t1Score < 0) t1Score = 0;


            t1Score = t1.getOffRtg() - t2.getDefRtg();
            if (t1Score < 0) t1Score = 0;
            t2Score = t2.getOffRtg() - t1.getDefRtg();
            if (t2Score < 0) t2Score = 0;

            Console.WriteLine("Score: " + t1.getName() + ": " + t1Score + " - " + t2.getName() + ": " + t2Score);

        
        }
    }
}
