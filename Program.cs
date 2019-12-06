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

            //DataManager.Instance.insertTeams();
            //DataManager.Instance.getTeams();
            //DataManager.Instance.populatePlayers();

            //createPlayersForLeague();

            DataManager.Instance.createTeams();
            DataManager.Instance.populateTeams();

            Console.ReadKey();

            //createTeams();
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

        /*public static void createPlayersForLeague(){
            for(int i = 0; i < 10; i ++){
                for(int j = 0; j < 5; j ++){

                    Player p = new Player();

                    string temp = p.firstName + ", ";
                    temp += p.lastName + ", ";
                    temp += "20, ";
                    temp += "170, ";
                    temp += p.insideShooting + ", ";
                    temp += p.perimeterShooting + ", ";
                    temp += p.threePointShooting + ", ";
                    temp += p.passing + ", ";
                    temp += p.freeThrow + ", ";
                    temp += p.handling + ", ";
                    temp += p.onBallDefense + ", ";
                    temp += p.insideDefense + ", ";
                    temp += p.stealing + ", ";
                    temp += p.block + ", ";
                    temp += p.offRebounding + ", ";
                    temp += p.defRebounding + ", ";
                    temp += p.totalPoints + ", ";
                    int tempint = i+1;
                    temp += tempint + ", ";
                    temp += p.playerTendency.shootInsideTendencyMax + ", ";
                    temp += p.playerTendency.shootInsideTendencyMin + ", ";
                    temp += p.playerTendency.shootThreeTendencyMax + ", ";
                    temp += p.playerTendency.shootThreeTendencyMin + ", ";
                    temp += p.playerTendency.passBallTendencyMax + ", ";
                    temp += p.playerTendency.passBallTendencyMin + ", ";
                    temp += p.playerTendency.stealTendencyMax + ", ";
                    temp += p.playerTendency.stealTendencyMin + ", ";
                    temp += p.playerTendency.blockTendencyMax + ", ";
                    temp += p.playerTendency.blockTendencyMin + ", ";
                    temp += p.playerTendency.foulTendencyMax + ", ";
                    temp += p.playerTendency.foulTendencyMin;

                    Console.WriteLine(temp);

                }
            }
        }*/

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

        public static void initDB(){
            
        }

    }
}
