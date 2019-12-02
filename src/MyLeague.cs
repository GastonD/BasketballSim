using System;
using System.Collections.Generic;

namespace BasketballSim
{
    public sealed class MyLeague
    {

        private List<Game> leagueGames = null;
        private int leagueYear = 0;
        private Stats leagueStats = null;
        private List<Team> leagueTeams = null;
        private int numDays;
        private int currentDay = 0;
        private Dictionary<Game, int> gameSchedule = null;

        MyLeague(){
            leagueGames = new List<Game>();
            leagueTeams = new List<Team>();
            leagueStats = new Stats();
            gameSchedule = new Dictionary<Game, int>();
        }

        private static readonly object padlock = new object();  
        private static MyLeague instance = null;  
        public static MyLeague Instance{
            get{
                lock(padlock){
                    if(instance == null){
                        instance = new MyLeague();
                    }
                    return instance;
                }
            }
        }

        public void setUpSeason(){
            /*if (leagueTeams.Count % 2 != 0)
            {
                leagueTeams.Add("Bye");
            }*/

            List<Team> teams = new List<Team>();
            teams.AddRange(leagueTeams);
            teams.RemoveAt(0);

            numDays = (leagueTeams.Count - 1);
            int halfSize = leagueTeams.Count / 2;

            int teamsSize = teams.Count;

            for (int day = 0; day < numDays; day++)
            {
                Console.WriteLine("Day {0}", (day + 1));

                int teamIdx = day % teamsSize;

                Console.WriteLine("{0} vs {1}", teams[teamIdx].getName(), leagueTeams[0].getName());
                Game g = new Game(teams[teamIdx],leagueTeams[0],day+1);
                leagueGames.Add(g);
                gameSchedule.Add(g,day+1);

                for (int idx = 1; idx < halfSize; idx++)
                {               
                    int firstTeam = (day + idx) % teamsSize;
                    int secondTeam = (day  + teamsSize - idx) % teamsSize;
                    Console.WriteLine("{0} vs {1}", teams[firstTeam].getName(), teams[secondTeam].getName());
                    g = new Game(teams[firstTeam],teams[secondTeam],day+1);
                    leagueGames.Add(g);
                    gameSchedule.Add(g, day+1);
                    Console.WriteLine("");
                }
            }
        }

        public List<Game> gamesInDay(int Day){
            List<Game> gamesScheduledInDay = new List<Game>();
            foreach(KeyValuePair<Game, int> kvp in gameSchedule){
                if(kvp.Value == Day){
                    gamesScheduledInDay.Add(kvp.Key);
                }
            }

            return gamesScheduledInDay;
        } 

        public int getLeagueDays(){
            return numDays;
        }

        public void addTeamToLeague(Team t){
            leagueTeams.Add(t);
        }

        public void listTeams(){
            foreach(Team t in leagueTeams){
                Console.WriteLine(t.getName());
            }
        }

        public Team GetTeam(string name){
            int i = leagueTeams.FindIndex(x => x.getName().Equals(name));
            return leagueTeams[i];
        }

        public void nextDay(){
            Console.WriteLine("Día "+currentDay.ToString());
            Console.WriteLine("Hay" +gameSchedule.Count.ToString()+ " partidos hoy");
            Console.WriteLine("===================");

            foreach(KeyValuePair<Game, int> kvp in gameSchedule){
                kvp.Key.playGame();
            }

            currentDay += 1;
        }

        public void displayTeamRecords(){
            foreach(Team t in leagueTeams){
                Console.WriteLine(t.getName()+": "+t.getWins().ToString()+"-"+t.getLosses().ToString());
            }
        }

    }
}