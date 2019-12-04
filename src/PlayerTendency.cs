using System;

namespace BasketballSim
{
    public class PlayerTendency
    {

        public int shootInsideTendencyMax;
        public int shootInsideTendencyMin;

        public int shootThreeTendencyMax;
        public int shootThreeTendencyMin;

        public int passBallTendencyMax;
        public int passBallTendencyMin;

        public int stealTendencyMax;
        public int stealTendencyMin;

        public int blockTendencyMax;
        public int blockTendencyMin;

        public int foulTendencyMax;
        public int foulTendencyMin;
        public PlayerTendency(string type){
            switch(type){
                case "Shooter":
                    shootInsideTendencyMax = 10;
                    shootInsideTendencyMin = 0;
                    shootThreeTendencyMax = 70;
                    shootThreeTendencyMin = 10;
                    passBallTendencyMax = 100;
                    passBallTendencyMin = 70;

                    stealTendencyMax = 30;
                    stealTendencyMin = 0;
                    blockTendencyMax = 60;
                    blockTendencyMin = 30;
                    foulTendencyMax = 80;
                    foulTendencyMin = 60;
                break;

                case "Slasher":
                    shootInsideTendencyMax = 60;
                    shootInsideTendencyMin = 0;
                    shootThreeTendencyMax = 70;
                    shootThreeTendencyMin = 60;
                    passBallTendencyMax = 100;
                    passBallTendencyMin = 70;

                    stealTendencyMax = 30;
                    stealTendencyMin = 0;
                    blockTendencyMax = 60;
                    blockTendencyMin = 30;
                    foulTendencyMax = 80;
                    foulTendencyMin = 60;
                break;

                default:
                    //DEFENDER
                    shootInsideTendencyMax = 30;
                    shootInsideTendencyMin = 0;
                    shootThreeTendencyMax = 50;
                    shootThreeTendencyMin = 30;
                    passBallTendencyMax = 100;
                    passBallTendencyMin = 50;

                    stealTendencyMax = 40;
                    stealTendencyMin = 0;
                    blockTendencyMax = 70;
                    blockTendencyMin = 40;
                    foulTendencyMax = 80;
                    foulTendencyMin = 70;
                break;


            }
        }
        public string getOffensiveAction()
        {
            Random rnd = new Random();
            int value = rnd.Next(0,100);

            if (value <= shootThreeTendencyMax || value >= shootThreeTendencyMin) return "Three";
            else if(value <= shootInsideTendencyMax || value >= shootInsideTendencyMin) return "Inside";
            else return "Pass";

        }

        public string getDefensiveAction()
        {
            Random rnd = new Random();
            int value = rnd.Next(0,100);

            if (value <= stealTendencyMax || value >= stealTendencyMin) return "Steal";
            else if(value <= blockTendencyMax || value >= blockTendencyMin) return "Block";
            else return "Foul";

        }
    }
}