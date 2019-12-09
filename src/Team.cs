using System;
using System.Collections.Generic;  

namespace BasketballSim
{
    public class Team
    {
        private string name;
        public List<Player> players = new List<Player>();
        private int teamWins;
        private int teamLosses;
        private int pointsForSeason;
        private int pointsAgainstSeason;
        public int ID;

        public Team(string givenName){
            name = givenName;
            pointsForSeason = 0;
            pointsAgainstSeason = 0;
            teamWins = 0;
            teamLosses = 0;

            /*for (int i = 0; i < 5; i++){
                players.Add(new Player());
            }*/
        }

        public void addPointsTotal(int ptsFor, int ptsAgainst){
            pointsForSeason += ptsFor;
            pointsAgainstSeason += ptsAgainst;
        }

        public void setValues(int id_param, int wins, int losses, int ptsFor, int ptsAgainst){
            ID = id_param;
            teamWins = wins;
            teamLosses = losses;
            pointsForSeason = ptsFor;
            pointsAgainstSeason = ptsAgainst;
        }

        public string getName(){
            return name;
        }

        public int getOffRtg(){
            // DEPRECATED TODO NEW
            return 50;
        }

        public int getDefRtg(){
            // DEPRECATED TODO NEW
            return 50;
        }

        public void showRoster(){
            foreach(Player p in players){
                Console.WriteLine(p.getName());
            }
        }

        public void addWin(){
            teamWins +=1;
        }

        public void addLoss(){
            teamLosses +=1;
        }

        public int getWins(){
            return teamWins;
        }

        public int getLosses(){
            return teamLosses;
        }

        public void addPlayer(Player p){
            players.Add(p);
        }

    }
}