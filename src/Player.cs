using System;

namespace BasketballSim
{


    public class Player
    {
        private readonly string playerName;
        private readonly int twoPtRtg;
        private readonly int threePtRtg;
        private readonly int defRtg;

        public Player(){
            Random rnd = new Random();
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