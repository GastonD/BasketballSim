using System;
using System.Collections.Generic;
using System.Linq;

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