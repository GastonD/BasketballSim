using System;
using System.Collections.Generic;

namespace BasketballSim
{
    public sealed class PlayerType
    {
        private List<string> types = null;
        public PlayerType(){
            types = new List<string>();

            types.Add("Shooter");
            //types.Add("PostPlayer");
            types.Add("Slasher");
            types.Add("Defender");
        }

        private static readonly object padlock = new object();  
        private static PlayerType instance = null;  
        public static PlayerType Instance{
            get{
                lock(padlock){
                    if(instance == null){
                        instance = new PlayerType();
                    }
                    return instance;
                }
            }
        }


        public string getRandomPlayerType(){
            int i = 0;
            Random rnd = new Random();
            i = rnd.Next(0,types.Count);
            return types[i];
        }
    }
}