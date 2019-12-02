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
        private int currentDay = 0;
        private Dictionary<int, Game> gameSchedule = null;

        MyLeague(){
            leagueGames = new List<Game>();
            leagueTeams = new List<Team>();
            leagueStats = new Stats();
            gameSchedule = new Dictionary<int, Game>();
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

        private void setUpSeason(){
            
        }

        public void addTeamToLeague(Team t){
            leagueTeams.Add(t);
        }

        public Team GetTeam(string name){
            int i = leagueTeams.FindIndex(x => x.getName().Equals(name));
            return leagueTeams[i];
        }

    }
}