using System;
using System.Collections.Generic;

namespace BasketballSim
{
    public class PlayerStats
    {
        public int points;
        public int twoPtFGA;
        public int twoPtFGM;
        public int threePtFGA;
        public int threePtFGM;
        public int rebounds;
        public int assists;
        public int steals;
        public int blocks;
        public int turnovers;
        public int totalGamesPlayed;

        public PlayerStats(){
            points = 0;
            twoPtFGA = 0;
            twoPtFGM = 0;
            threePtFGA = 0;
            threePtFGM = 0;
            rebounds = 0;
            steals = 0;
            blocks = 0;
            turnovers = 0;
            totalGamesPlayed = 0;
        }

        public string ReturnMessage()
        {
            return "code snippet para crear una clase nueva";
        }
    }
}