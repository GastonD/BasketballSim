using System;

namespace BasketballSim
{
    public class PlayerMoveAndRating
    {

        string move;

        int rating;

        public PlayerMoveAndRating(){
            move = null;
            rating = 0;
        }

        public void setValues(string s, int i){
            move = s;
            rating = i;
        }

        public string getMove() => move;
        
        public int getRating() => rating;
        
    }
}