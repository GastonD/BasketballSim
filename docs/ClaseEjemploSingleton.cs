using System;

namespace BasketballSim
{
    public sealed class ClaseEjemploSingleton
    {
        ClaseEjemploSingleton(){
        }

    private static readonly object padlock = new object();  
    private static ClaseEjemploSingleton instance = null;  
    public static ClaseEjemploSingleton Instance{
        get{
            lock(padlock){
                if(instance == null){
                    instance = new ClaseEjemploSingleton();
                }
                return instance;
            }
        }
    }

    }
}