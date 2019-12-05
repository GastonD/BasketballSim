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
                createTableCmd.CommandText = "CREATE TABLE TEAMS(ID int autonumeric primary key, name VARCHAR(50))";
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

    }
}