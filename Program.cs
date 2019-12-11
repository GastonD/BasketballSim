using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace BasketballSim
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while(showMenu){
                showMenu = MainMenu();
            }
            
        }

        public static void playDay(int Day){
            List<Game> gamesToPlay = new List<Game>();
            gamesToPlay = MyLeague.Instance.gamesInDay(Day);

            foreach(Game g in gamesToPlay){
                g.playGame();
                //Console.ReadKey(); 
            }
        }

        private static void PlayLeague(){
            DataManager.Instance.createTeams();
            DataManager.Instance.populateTeams();
            MyLeague.Instance.setUpSeason();

            int daysPlayed = 0;

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

            Console.ReadKey();
        }

        private static bool MainMenu(){
            Console.Clear();
            Console.WriteLine("Bienvenido a Basketball Simulator!");
            Console.WriteLine("1) Jugar Partido Amistoso");
            Console.WriteLine("2) Simular Liga");
            Console.WriteLine("3) Salir");

            switch(Console.ReadLine()){
                case "1":
                return true;

                case "2":
                PlayLeague();
                return true;

                case "3":
                return false;

                default:
                return true;
            }
        }

    }
}
