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


        public Team(string givenName){
            name = givenName;
            teamWins = 0;
            teamLosses = 0;

            for (int i = 0; i < 5; i++){
                players.Add(new Player());
            }
        }

        public string getName(){
            return name;
        }

        public int getOffRtg(){
            int OffRtg = 0;
            foreach(Player p in players){
                OffRtg = OffRtg + (p.getTwoPtRtg() + p.getThreePtRtg());
            }
            return OffRtg;
        }

        public int getDefRtg(){
            int DefRtg = 0;
            foreach(Player p in players){
                DefRtg = DefRtg + p.getDefRtg();
            }
            return DefRtg;
        }

        public void showRoster(){
            foreach(Player p in players){
                Console.WriteLine(p.getName() + " " + p.getOVR());
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

    }
}