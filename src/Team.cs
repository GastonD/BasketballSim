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


        public Team(string givenName){
            name = givenName;
            pointsForSeason = 0;
            pointsAgainstSeason = 0;
            teamWins = 0;
            teamLosses = 0;

            for (int i = 0; i < 5; i++){
                players.Add(new Player());
            }
        }

        public void addPointsTotal(int ptsFor, int ptsAgainst){
            pointsForSeason += ptsFor;
            pointsAgainstSeason += ptsAgainst;
        }

        public string getName(){
            return name;
        }

        public int getOffRtg(){
            /*int OffRtg = 0;
            foreach(Player p in players){
                OffRtg = OffRtg + (p.getTwoPtRtg() + p.getThreePtRtg());
            }
            return OffRtg;*/
            // DEPRECATED TODO NEW
            return 50;
        }

        public int getDefRtg(){
            /*int DefRtg = 0;
            foreach(Player p in players){
                DefRtg = DefRtg + p.getDefRtg();
            }
            return DefRtg;*/
            // DEPRECATED TODO NEW
            return 50;
        }

        public void showRoster(){
            // DEPRECATED TODO NEW
            /*foreach(Player p in players){
                Console.WriteLine(p.getName() + " " + p.getOVR());
            }*/
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

    }
}