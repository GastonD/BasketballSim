using System;
using System.Collections.Generic;

namespace BasketballSim
{
    public class Game
    {

        public Team teamOne;
        public Team teamTwo;

        public int teamOneScore;
        public int teamTwoScore;
        public Dictionary<string, int> teamOneBoxScore = new Dictionary<string, int>();
        public Dictionary<string, int> teamTwoBoxScore = new Dictionary<string, int>();

        public Game(Team t1, Team t2){
            teamOne = t1;
            teamTwo = t2;

            teamOneScore = 0;
            teamTwoScore = 0;

            foreach(Player p in teamOne.players){
                teamOneBoxScore.Add(p.getName(),0);
            }

            foreach(Player p in teamTwo.players){
                teamTwoBoxScore.Add(p.getName(),0);
            }
        }

        public static int possession(Team atk, Team def, Dictionary<string, int> atkBxs){
            Random rnd = new Random();
            
            int index = 0;

            index = rnd.Next(atk.players.Count);
            Player p1 = atk.players[index];

            index = rnd.Next(def.players.Count);
            Player p2 = def.players[index];
            
            if(p1.getTwoPtRtg() > p2.getDefRtg()){
                atkBxs[p1.getName()] += 2;
                return 2;
            }
            else return 0;
            
        }

        public void playGame(){

            for (int i = 0; i < 100; i++){
                teamOneScore += possession(teamOne, teamTwo, teamOneBoxScore);
                teamTwoScore += possession(teamTwo, teamOne, teamTwoBoxScore);
            }

            Console.WriteLine("");
            Console.WriteLine("RESULTADO:");
            Console.WriteLine(teamOne.getName() + ": " + teamOneScore);
            Console.WriteLine("PLANILLA");
            printBoxScore(teamOneBoxScore);
            Console.WriteLine("");
            Console.WriteLine(teamTwo.getName() + ": " + teamTwoScore);
            Console.WriteLine("PLANILLA");
            printBoxScore(teamTwoBoxScore);
            
            LeagueSimulation.Instance.addPoints(teamOneBoxScore);
            LeagueSimulation.Instance.addPoints(teamTwoBoxScore);
        }

        private void printBoxScore(Dictionary<string, int> boxScore){
            foreach (KeyValuePair<string, int> kvp in boxScore)
                Console.WriteLine(kvp.Key +" "+ kvp.Value.ToString());
        }

    }
}