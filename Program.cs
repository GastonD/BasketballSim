using System;
using System.Collections.Generic;

namespace BasketballSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Basketball Simulator!");
            createTeams();
            //MyLeague.Instance.listTeams();
            MyLeague.Instance.setUpSeason();

            int daysPlayed = 0;

            //Console.ReadKey();

            for (int i = 0; i<MyLeague.Instance.getLeagueDays();i++){
                Console.WriteLine("Día {0}",i+1);
                playDay(i+1);
                daysPlayed +=1;
            }

            MyLeague.Instance.showStats(daysPlayed);

            Console.WriteLine("");
            Console.WriteLine("");

            MyLeague.Instance.displayTeamRecords();
            MyLeague.Instance.getTopScorer();
            /*var t1 = new Team(NameGenerator.Instance.getRndTeamName());
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
            //partido.playGame();*/


            
        }

        public static void createTeams(){
            for(int i = 0; i < NameGenerator.Instance.getTeamArrayLength();i++){
                Team t = new Team(NameGenerator.Instance.getTeamNameByIndex(i));
                MyLeague.Instance.addTeamToLeague(t);
            }
            //Console.WriteLine("Participan de la liga: "MyLeague.Instance.)
        }

        public static void playDay(int Day){
            List<Game> gamesToPlay = new List<Game>();
            gamesToPlay = MyLeague.Instance.gamesInDay(Day);

            foreach(Game g in gamesToPlay){
                g.playGame();
                //Console.ReadKey(); 
            }
        }




    }
}
