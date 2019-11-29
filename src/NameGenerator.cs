using System;

namespace BasketballSim
{
    public sealed class NameGenerator
    {

        private String[] firstNames = null;
        private String[] lastNames = null;
        private String[] teamNames = null;
        NameGenerator(){
            firstNames = new String[20]{"Lucas","Gaston","Juan","Carlos","Santiago","Ezequiel","Matias","Federico","Ignacio","Osvaldo","James","Steph","LeBron","Josh","Michael","Karl","George","Klay","Giannis","Anthony"};
            lastNames = new String[15]{"Lopez", "Sanchez","Perez","Fernandez","Alvarez","Smith","James","Thompson","Curry","Harden","Jordan","Leonard","Davis","George","Middleton"};
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
        string name = "";
        name += firstNames[rnd.Next(0,firstNames.Length - 1)];
        name += " ";
        name += lastNames[rnd.Next(0,lastNames.Length - 1)];
        return name;
    }

    public string getRndTeamName(){
        Random rnd = new Random();
        return teamNames[rnd.Next(0,teamNames.Length-1)];
    }

//METODOS PARA DEBUGEAR Y TEST
//TODO: BORRAR?
    public int getPlayerArrayLength(){
        return firstNames.Length;
    }

    public int getTeamArrayLength(){
        return teamNames.Length;
    }

    public void printNames(){
        foreach(string name in firstNames) 
                Console.Write(name + " "); 
    }


    }
}