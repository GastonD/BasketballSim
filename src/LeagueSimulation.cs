using System;

namespace BasketballSim
{
    public sealed class LeagueSimulation
    {
        LeagueSimulation(){
            //<>
        }

        private static readonly object padlock = new object();  
        private static LeagueSimulation instance = null;  
        public static LeagueSimulation Instance{
            get{
                lock(padlock){
                    if(instance == null){
                        instance = new LeagueSimulation();
                    }
                    return instance;
                }
            }
        }

    }
}