using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace BasketballSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Basketball Simulator!");
            Console.WriteLine("");

            DataManager.Instance.createTeams();
            DataManager.Instance.populateTeams();

            Console.ReadKey();

            MyLeague.Instance.setUpSeason();

            int daysPlayed = 0;

            //Console.ReadKey();

            for (int i = 0; i<MyLeague.Instance.getLeagueDays();i++){
                Console.WriteLine("Día {0}",i+1);
                playDay(i+1);
                daysPlayed +=1;
            }

            Console.WriteLine("Days Played: " + daysPlayed);

            MyLeague.Instance.showStats(daysPlayed);

            Console.WriteLine("");
            Console.WriteLine("");

            MyLeague.Instance.displayTeamRecords();
            MyLeague.Instance.getTopScorer();
            MyLeague.Instance.nextYear();
            
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
