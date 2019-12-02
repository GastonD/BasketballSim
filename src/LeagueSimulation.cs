using System;
using System.Collections.Generic;

namespace BasketballSim
{
    public sealed class LeagueSimulation
    {
        private Dictionary<Player, int> leaguePlayers = null;
        LeagueSimulation(){
            leaguePlayers = new Dictionary<Player, int>();
        }

        private static readonly object padlock = new object();  
        private static LeagueSimulation instance = null;  
        public static LeagueSimulation Instance{
            get{
                lock(padlock){
                    if(instance == null){
                        instance = new LeagueSimulation();
                    }
                    return instance;
                }
            }
        }

        public void addPoints(Dictionary<Player, int> boxScore){
            foreach (KeyValuePair<Player, int> kvp in boxScore){
                if(leaguePlayers.ContainsKey(kvp.Key)){
                    leaguePlayers[kvp.Key] += kvp.Value;
                }else{
                    leaguePlayers.Add(kvp.Key,kvp.Value);
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

    }
}