using System;
using Microsoft.Data.Sqlite;

namespace BasketballSim
{
    public sealed class DataManager
    {
        private SqliteConnectionStringBuilder connectionStringBuilder = null;
        DataManager(){
            connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./DB/SqliteDB.db";

        }

        private static readonly object padlock = new object();  
        private static DataManager instance = null;  
        public static DataManager Instance{
            get{
                lock(padlock){
                    if(instance == null){
                        instance = new DataManager();
                    }
                    return instance;
                }
            }
        }

        public void getTeams(){

            using(var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT name FROM TEAMS";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var message = reader.GetString(0);
                        Console.WriteLine(message);
                    }
                }

            }

        }

        public void insertTeams(){
            using(var connection = new SqliteConnection(connectionStringBuilder.ConnectionString)){
                
                connection.Open();

                var delTableCmd = connection.CreateCommand();
                delTableCmd.CommandText = "DROP TABLE IF EXISTS TEAMS";
                delTableCmd.ExecuteNonQuery();

                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = "CREATE TABLE TEAMS(ID int autonumeric primary key, teamWins int, teamLosses int, ptsForSeason int, ptsAgainstSeason int, name VARCHAR(50))";
                createTableCmd.ExecuteNonQuery();

                //Seed some data:
                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    for(int i = 0; i < NameGenerator.Instance.getTeamArrayLength(); i ++){

                        insertCmd.CommandText = "INSERT INTO TEAMS (name) VALUES ('"+NameGenerator.Instance.getTeamNameByIndex(i)+"')";
                        insertCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public void populatePlayers(){
            using(var connection = new SqliteConnection(connectionStringBuilder.ConnectionString)){
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    for(int i = 0; i < 10; i ++){
                        for(int j = 0; j < 5; j ++){

                            Player p = new Player();

                            string temp = p.firstName + ", ";
                            temp += p.lastName + ", ";
                            temp += "20, ";
                            temp += "170, ";
                            temp += p.insideShooting + ", ";
                            temp += p.perimeterShooting + ", ";
                            temp += p.threePointShooting + ", ";
                            temp += p.passing + ", ";
                            temp += p.freeThrow + ", ";
                            temp += p.handling + ", ";
                            temp += p.onBallDefense + ", ";
                            temp += p.insideDefense + ", ";
                            temp += p.stealing + ", ";
                            temp += p.block + ", ";
                            temp += p.offRebounding + ", ";
                            temp += p.defRebounding + ", ";
                            temp += p.totalPoints + ", ";
                            int tempint = i+1;
                            temp += tempint + ", ";
                            temp += p.playerTendency.shootInsideTendencyMax + ", ";
                            temp += p.playerTendency.shootInsideTendencyMin + ", ";
                            temp += p.playerTendency.shootThreeTendencyMax + ", ";
                            temp += p.playerTendency.shootThreeTendencyMin + ", ";
                            temp += p.playerTendency.passBallTendencyMax + ", ";
                            temp += p.playerTendency.passBallTendencyMin + ", ";
                            temp += p.playerTendency.stealTendencyMax + ", ";
                            temp += p.playerTendency.stealTendencyMin + ", ";
                            temp += p.playerTendency.blockTendencyMax + ", ";
                            temp += p.playerTendency.blockTendencyMin + ", ";
                            temp += p.playerTendency.foulTendencyMax + ", ";
                            temp += p.playerTendency.foulTendencyMin;

                            insertCmd.CommandText = "INSERT INTO PLAYERS (FIRST_NAME, LAST_NAME, AGE, HEIGHT, insideShooting, perimeterShooting, threePointShooting, passing, freeThrow, handling, onBallDefense, insideDefense, stealing, block, offRebounding, defRebounding, totalPoints, TEAM, shootInsideTendencyMax, shootInsideTendencyMin, shootThreeTendencyMax, shootThreeTendencyMin, passBallTendencyMax, passBallTendencyMin, stealTendencyMax, stealTendencyMin, blockTendencyMax, blockTendencyMin, foulTendencyMax, foulTendencyMin) VALUES ('"+temp+"')";
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }

            }
        }

    }
}