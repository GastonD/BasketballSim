using System;

namespace BasketballSim
{


    public class Player
    {
        private readonly string playerName;
        private readonly int twoPtRtg;
        private readonly int threePtRtg;
        private readonly int defRtg;
        //Ofensivas
        private readonly int insideShooting;
        private readonly int perimeterShooting;
        private readonly int threePointShooting;
        private readonly int passing;
        private readonly int freeThrow;

        //Defensiva
        private readonly int onBallDefense;
        private readonly int insideDefense;
        private readonly int stealing;
        private readonly int block;

        private readonly int offRebounding;
        private readonly int defRebounding;

        private int totalPoints;

        public Player(){
            totalPoints = 0;
            Random rnd = new Random();

            string type = PlayerType.Instance.getRandomPlayerType();

            twoPtRtg = rnd.Next(1, 10);
            threePtRtg = rnd.Next(1, 10);
            defRtg = rnd.Next(1, 10);
            playerName = NameGenerator.Instance.getRndPlayerName();
        }

        public int getTwoPtRtg() => twoPtRtg;

        public int getThreePtRtg() => threePtRtg;

        public int getDefRtg() => defRtg;

        public string getName() => playerName;
        public int getOVR(){
            return ((twoPtRtg
                + threePtRtg
                + defRtg)/3);
        }
    }
}