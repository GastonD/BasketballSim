using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketballSim
{
    public sealed class MyLeague
    {

        private List<Game> leagueGames = null;
        private int leagueYear = 0;
        private List<Team> leagueTeams = null;
        private int numDays;
        private int currentDay = 0;
        private Dictionary<Game, int> gameSchedule = null;
        private Dictionary<Player, int> leaguePlayers = null;

        MyLeague(){
            leagueGames = new List<Game>();
            leagueTeams = new List<Team>();
            gameSchedule = new Dictionary<Game, int>();
            leaguePlayers = new Dictionary<Player, int>();
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
            leagueYear++;

            List<Team> teams = new List<Team>();
            teams.AddRange(leagueTeams);
            teams.RemoveAt(0);

            numDays = (leagueTeams.Count - 1);
            int halfSize = leagueTeams.Count / 2;

            int teamsSize = teams.Count;

            for (int day = 0; day < numDays; day++)
            {
                Console.WriteLine("Day {0}", (day + 1));
                Console.WriteLine("");

                int teamIdx = day % teamsSize;

                Console.WriteLine("    {0} vs {1}", teams[teamIdx].getName(), leagueTeams[0].getName());
                Console.WriteLine("");

                Game g = new Game(teams[teamIdx],leagueTeams[0],day+1);
                leagueGames.Add(g);
                gameSchedule.Add(g,day+1);

                for (int idx = 1; idx < halfSize; idx++)
                {               
                    int firstTeam = (day + idx) % teamsSize;
                    int secondTeam = (day  + teamsSize - idx) % teamsSize;
                    Console.WriteLine("    {0} vs {1}", teams[firstTeam].getName(), teams[secondTeam].getName());
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

        public Team getTeamByID(int id_param){
            return leagueTeams.Find(o => o.ID == id_param);
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

        public void nextYear() => leagueYear++;
        public void displayTeamRecords(){
            List<Team> SortedList = leagueTeams.OrderByDescending(o=>o.getWins()).ToList();
            foreach(Team t in SortedList){
                Console.WriteLine(t.getName()+": "+t.getWins().ToString()+"-"+t.getLosses().ToString());
            }
        }

        public void addPoints(Dictionary<Player, PlayerStats> boxScore){
            foreach (KeyValuePair<Player, PlayerStats> kvp in boxScore){
                if(leaguePlayers.ContainsKey(kvp.Key)){
                    leaguePlayers[kvp.Key] += kvp.Value.points;
                    //leaguePlayers[kvp.Key] += kvp.Value;
                }else{
                    leaguePlayers.Add(kvp.Key,kvp.Value.points);
                }
            }
        }

        public void showStats(int totalGamesPlayed){
            double ppg = 0;
            foreach (KeyValuePair<Player, int> kvp in leaguePlayers){
                ppg = kvp.Value / totalGamesPlayed;
                Console.WriteLine(kvp.Key.getName() + " Anotó un total de: " + kvp.Value.ToString() + ". Promediando: " + ppg.ToString() + " por partido");
            }
                
        }

        public void getTopScorer(){
            Player topScorer = leaguePlayers.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine("{0} is the League's Top Scorer with a total of {1} points and XX PPG", topScorer.getName(),leaguePlayers[topScorer]);
        }



    }
}