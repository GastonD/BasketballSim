using System;

namespace BasketballSim
{
    public sealed class NameGenerator
    {

        private String[] firstNames = null;
        private String[] lastNames = null;
        private String[] teamNames = null;
        NameGenerator(){
            firstNames = new String[25]{"Lucas","Gaston","Juan","Carlos","Santiago","Ezequiel","Matias","Federico","Ignacio","Osvaldo","James","Steph","LeBron","Josh","Michael","Karl","George","Klay","Giannis","Anthony", "Luka", "Luis", "Carmelo","Manu","Andres"};
            lastNames = new String[25]{"Lopez", "Sanchez","Perez","Fernandez","Alvarez","Smith","James","Thompson","Curry","Harden","Jordan","Leonard","Davis","George","Middleton","Doncic","Waiters","Mozo","Milanesio","Scola","Ginobili","Robertson","Davidson","Duncan","Parker"};
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

    public string getRndFirstName(){
        Random rnd = new Random();
        return firstNames[rnd.Next(0,firstNames.Length - 1)];
    }

    public string getRndLastName(){
        Random rnd = new Random();
        return lastNames[rnd.Next(0,lastNames.Length - 1)];
    }

    public string getRndTeamName(){
        Random rnd = new Random();
        return teamNames[rnd.Next(0,teamNames.Length-1)];
    }

    public string getTeamNameByIndex(int i){
        return teamNames[i];
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