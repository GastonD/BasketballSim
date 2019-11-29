using System;
using System.Collections.Generic;  

namespace BasketballSim
{
    public class Team
    {
        private string name;
        public List<Player> players = new List<Player>();

        public Team(string givenName){
            name = givenName;

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
    }
}