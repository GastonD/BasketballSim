using System;

namespace BasketballSim
{


    public class Player
    {
        public readonly string playerName;

        public readonly string firstName;
        public readonly string lastName;

        //Ofensivas
        public readonly int insideShooting;
        public readonly int perimeterShooting;
        public readonly int threePointShooting;
        public readonly int passing;
        public readonly int freeThrow;
        public readonly int handling;

        //Defensiva
        public readonly int onBallDefense;
        public readonly int insideDefense;
        public readonly int stealing;
        public readonly int block;

        public readonly int offRebounding;
        public readonly int defRebounding;

        public int totalPoints;
        public string playerType;
        public PlayerTendency playerTendency = null;

        public PlayerStats stats = null;

        public Player(){
            totalPoints = 0;
            stats = new PlayerStats();

            Random rnd = new Random();

            playerType = PlayerType.Instance.getRandomPlayerType();

            switch(playerType)
            {
                case "Shooter":
                    insideShooting = 10;
                    perimeterShooting = 75;
                    threePointShooting = 90;
                    passing = 30;
                    freeThrow = 90;

                    onBallDefense = 50;
                    insideDefense = 10;
                    stealing = 20;
                    block = 10;

                    offRebounding = 20;
                    defRebounding = 20;
                break;

                case "Slasher":
                    insideShooting = 90;
                    perimeterShooting = 10;
                    threePointShooting = 40;
                    passing = 40;
                    freeThrow = 70;

                    onBallDefense = 50;
                    insideDefense = 10;
                    stealing = 20;
                    block = 10;

                    offRebounding = 40;
                    defRebounding = 40;
                break;

                default:
                    //Defender
                    insideShooting = 50;
                    perimeterShooting = 20;
                    threePointShooting = 30;
                    passing = 40;
                    freeThrow = 90;

                    onBallDefense = 90;
                    insideDefense = 70;
                    stealing = 50;
                    block = 50;

                    offRebounding = 70;
                    defRebounding = 70;
                break;
                
            }

            playerTendency = new PlayerTendency(playerType);
            firstName = NameGenerator.Instance.getRndFirstName();
            lastName = NameGenerator.Instance.getRndLastName();
            playerName = firstName + " " + lastName;
            
        }

        public string getName() => playerName;
        public int getOVR(){
            //TODO REFACTOR para calcular un OVR de un Jugador
            return 100;
        }

        public PlayerMoveAndRating getOffenseMoveAndRating(){
            string action = playerTendency.getOffensiveAction();
            PlayerMoveAndRating actionStats = new PlayerMoveAndRating();
            if (action.Equals("Three")) actionStats.setValues(action, threePointShooting);
            else if (action.Equals("Inside")) actionStats.setValues(action, insideShooting);
            else if (action.Equals("Pass")) actionStats.setValues(action, passing);
            else actionStats.setValues("no action",0);

            return actionStats;
        }

        public PlayerMoveAndRating getDefenseMoveAndRating(string offensiveMove){
            Random rnd = new Random();
            PlayerMoveAndRating actionStats = new PlayerMoveAndRating();
            if (offensiveMove.Equals("Inside")) actionStats.setValues("InsideDef",rnd.Next(0,insideDefense));
            else if (offensiveMove.Equals("Three")) actionStats.setValues("PerimeterDef",rnd.Next(0,onBallDefense));
            else if (offensiveMove.Equals("Pass")) actionStats.setValues("PerimeterDef",rnd.Next(0,stealing));
            else actionStats.setValues("no action",0);

            return actionStats;
        }

        public int getTotalPoints(){
            return totalPoints;
        }

        public void addPoints(int p){
            totalPoints += p;
        }

        public void addAssist(int a){
            stats.assists += a;
        }
    
    }
}