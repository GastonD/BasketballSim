using System;

namespace BasketballSim
{
    public class Game
    {

        public Team teamOne;
        public Team teamTwo;

        public int teamOneScore;
        public int teamTwoScore;

        public Game(Team t1, Team t2){
            teamOne = t1;
            teamTwo = t2;

            teamOneScore = 0;
            teamTwoScore = 0;
        }

        public static int possession(Team atk, Team def){
            Random rnd = new Random();
            int atkVal = rnd.Next(0,atk.getOffRtg());
            int defVal = rnd.Next(0,def.getDefRtg());

            if((atkVal - defVal) > 50) return 3;
            else if (atkVal > defVal) return 2;
            else return 0;
        }

        public void playGame(){

            for (int i = 0; i < 100; i++){
                teamOneScore += possession(teamOne, teamTwo);
                teamTwoScore += possession(teamTwo, teamOne);
            }

            Console.WriteLine("");
            Console.WriteLine("RESULTADO:");
            Console.WriteLine(teamOne.getName() + ": " + teamOneScore + " - " + teamTwo.getName() + ": " + teamTwoScore);
            
        }

    }
}