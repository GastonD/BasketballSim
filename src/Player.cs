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
        }

        public int getTwoPtRtg(){
            return twoPtRtg;
        }

        public int getThreePtRtg(){
            return threePtRtg;
        }

        public int getDefRtg(){
            return defRtg;
        }
    }
}