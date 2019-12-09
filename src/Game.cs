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

        public Dictionary<Player, PlayerStats> teamOneBoxScore = null;
        public Dictionary<Player, PlayerStats> teamTwoBoxScore = null;

        public Game(Team t1, Team t2, int day){
            teamOne = t1;
            teamTwo = t2;
            scheduledDay = day;

            teamOneScore = 0;
            teamTwoScore = 0;

            teamOneBoxScore = new Dictionary<Player, PlayerStats>();
            
            foreach(Player p in teamOne.players){
                PlayerStats ps = new PlayerStats();
                teamOneBoxScore.Add(p,ps);
            }

            teamTwoBoxScore = new Dictionary<Player, PlayerStats>();
            
            foreach(Player p in teamTwo.players){
                PlayerStats ps = new PlayerStats();
                teamTwoBoxScore.Add(p,ps);
            }
        }

        public static int possession(Team atk, Team def, Dictionary<Player, PlayerStats> atkBxs, Dictionary<Player, PlayerStats> defBxs, int passBonus){
            Random rnd = new Random();
            int index = 0;
            index = rnd.Next(atk.players.Count);
            Player p1 = atk.players[index];
            index = rnd.Next(def.players.Count);
            Player p2 = def.players[index];

            int score = 0;
            int passResult = 0;

            PlayerMoveAndRating p1Move = new PlayerMoveAndRating();
            p1Move = p1.getOffenseMoveAndRating();
            p1Move.setValues(p1Move.getMove(), p1Move.getRating()+passBonus);

            PlayerMoveAndRating p2Move = new PlayerMoveAndRating();
            p2Move = p2.getDefenseMoveAndRating(p1Move.getMove());
            
            //<>

            if(p1Move.getRating() > p2Move.getRating() ){
                if (p1Move.getMove().Equals("Inside")){
                    Console.WriteLine(p1.getName() + " scores a layup");
                    score = 2;
                    atkBxs[p1].points += score;
                    atkBxs[p1].twoPtFGA += 1;
                    atkBxs[p1].twoPtFGM += 1;
                }
                else if (p1Move.getMove().Equals("Three")){
                    Console.WriteLine(p1.getName() + " scores a 3 pointer");
                    score = 3;
                    atkBxs[p1].points += score;
                    atkBxs[p1].threePtFGA += 1;
                    atkBxs[p1].threePtFGM += 1;
                }
                else if (p1Move.getMove().Equals("Pass")){
                    Console.WriteLine(p1.getName() + " passes the ball");
                    
                    passResult = possession(atk,def,atkBxs, defBxs, passBonus);

                    if(passResult > 0){
                        atkBxs[p1].assists += 1;
                        Console.WriteLine(p1.getName() + "assisted the field goal");
                        score = passResult;
                    }

                    return passResult;
                }
            }
            else {
                if (p2Move.getMove().Equals("InsideDef")){
                    Console.WriteLine(p2.getName() + " successfully contest the inside shot");
                    atkBxs[p1].twoPtFGA += 1;
                    defBxs[p2].rebounds += 1;
                }
                else if (p2Move.getMove().Equals("PerimeterDef")){
                    Console.WriteLine(p2.getName() + " successfully contest the perimeter shot");
                    atkBxs[p1].threePtFGA += 1;
                }
                else if (p2Move.getMove().Equals("Steal")){
                    atkBxs[p1].turnovers += 1;
                    defBxs[p2].steals += 1;
                    Console.WriteLine(p2.getName() + " steals the ball");
                }
            }

            return score;
        }
            
        public void playGame(){

            for (int i = 0; i < 100; i++){
                teamOneScore += possession(teamOne, teamTwo, teamOneBoxScore, teamTwoBoxScore, 0);
                teamTwoScore += possession(teamTwo, teamOne, teamTwoBoxScore, teamOneBoxScore, 0);
            }

            Console.WriteLine("");
            Console.WriteLine("RESULTADO:");
            Console.WriteLine(teamOne.getName() + ": " + teamOneScore + " - " + teamTwo.getName() + ": "+teamTwoScore);

            if (teamOneScore > teamTwoScore){
                teamOne.addWin();
                teamTwo.addLoss();
            }else{
                teamTwo.addWin();
                teamOne.addLoss();
            }
            
            teamOne.addPointsTotal(teamOneScore, teamTwoScore);
            teamTwo.addPointsTotal(teamTwoScore, teamOneScore);
            
            MyLeague.Instance.addStats(teamOneBoxScore);
            MyLeague.Instance.addStats(teamTwoBoxScore);
        }

        private void printBoxScore(Dictionary<Player, int> boxScore){
            foreach (KeyValuePair<Player, int> kvp in boxScore)
                Console.WriteLine(kvp.Key.getName() +" "+ kvp.Value.ToString());
        }

    }
}