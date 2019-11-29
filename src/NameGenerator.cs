using System;

namespace BasketballSim
{
    public sealed class NameGenerator
    {

        private String[] playerNames = null;
        private String[] teamNames = null;
        NameGenerator(){
            playerNames = new String[10]{"Lucas","Gaston","Juan","Carlos","Santiago","Ezequiel","Matias","Federico","Ignacio","Osvaldo"};
            teamNames = new String[10]{"Ateneo","Aglo","Amerika","Triglav","Caballito Heads","Proyecto Basquet B","Sahores","THT","Betam","Sholem"};
        }

    private static readonly object padlock = new object();  
    private static NameGenerator instance = null;  
    public static NameGenerator Instance{
        get{
            lock(padlock){
                if(instance == null){
                    instance = new NameGenerator();
                }
                return instance;
            }
        }
    }

    public string getRndPlayerName(){
        Random rnd = new Random();
        return playerNames[rnd.Next(0,playerNames.Length - 1)];
    }

    public string getRndTeamName(){
        Random rnd = new Random();
        return teamNames[rnd.Next(0,teamNames.Length-1)];
    }

//METODOS PARA DEBUGEAR Y TEST
//TODO: BORRAR?
    public int getPlayerArrayLength(){
        return playerNames.Length;
    }

    public int getTeamArrayLength(){
        return teamNames.Length;
    }

    public void printNames(){
        foreach(string name in playerNames) 
                Console.Write(name + " "); 
    }


    }
}