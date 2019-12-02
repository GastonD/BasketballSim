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

        public int scheduledDay;

        public Dictionary<Player, int> teamOneBoxScore = null;
        public Dictionary<Player, int> teamTwoBoxScore = null;

        public Game(Team t1, Team t2, int day){
            teamOne = t1;
            teamTwo = t2;
            scheduledDay = day;

            teamOneScore = 0;
            teamTwoScore = 0;

            teamOneBoxScore = new Dictionary<Player, int>();
            
            foreach(Player p in teamOne.players){
                teamOneBoxScore.Add(p,0);
            }

            teamTwoBoxScore = new Dictionary<Player, int>();
            
            foreach(Player p in teamTwo.players){
                teamTwoBoxScore.Add(p,0);
            }
        }

        public static int possession(Team atk, Team def, Dictionary<Player, int> atkBxs){
            Random rnd = new Random();
            
            int index = 0;

            index = rnd.Next(atk.players.Count);
            Player p1 = atk.players[index];

            index = rnd.Next(def.players.Count);
            Player p2 = def.players[index];
            
            if(p1.getTwoPtRtg() > p2.getDefRtg()){
                atkBxs[p1] += 2;
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
            Console.WriteLine(teamOne.getName() + ": " + teamOneScore + " - " + teamTwo.getName() + ": "+teamTwoScore);
            /*Console.WriteLine(teamOne.getName() + ": " + teamOneScore);
            Console.WriteLine("PLANILLA");
            printBoxScore(teamOneBoxScore);
            Console.WriteLine("");
            Console.WriteLine(teamTwo.getName() + ": " + teamTwoScore);
            Console.WriteLine("PLANILLA");
            printBoxScore(teamTwoBoxScore);*/

            if (teamOneScore > teamTwoScore){
                teamOne.addWin();
                teamTwo.addLoss();
            }else{
                teamTwo.addWin();
                teamOne.addLoss();
            }
            
            LeagueSimulation.Instance.addPoints(teamOneBoxScore);
            LeagueSimulation.Instance.addPoints(teamTwoBoxScore);
        }

        private void printBoxScore(Dictionary<Player, int> boxScore){
            foreach (KeyValuePair<Player, int> kvp in boxScore)
                Console.WriteLine(kvp.Key.getName() +" "+ kvp.Value.ToString());
        }

    }
}