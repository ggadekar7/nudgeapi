using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.DAL
{
    public static class DbConnection
    {
        public static string connectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";

        public static SqliteConnection getConnection()
        {
            var masterConnection = new SqliteConnection(connectionString);
            masterConnection.Open();
            return masterConnection;
        }


        public static void CreateTables()
        {
            string connectionString = DbConnection.connectionString;
            var masterConnection = DbConnection.getConnection();
            var createCommand = masterConnection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE RAM (
                    id INTEGER PRIMARY KEY AUTOINCREMENT , type TEXT, price INT
                )
            ";
            createCommand.ExecuteNonQuery();
            using (var firstConnection = new SqliteConnection(connectionString))
            {
                firstConnection.Open();

                var updateCommand = firstConnection.CreateCommand();
                updateCommand.CommandText =
                @"
                    INSERT INTO RAM (type,price)
                    VALUES ('8GB','45.67')
                ";
                updateCommand.ExecuteNonQuery();

                updateCommand.CommandText =
                @"
                    INSERT INTO RAM (type,price)
                    VALUES ('16GB','87.88')
                ";
                updateCommand.ExecuteNonQuery();
            }

            createCommand.CommandText =
            @"
                CREATE TABLE HDD (
                    id INTEGER PRIMARY KEY AUTOINCREMENT , type TEXT, price INT
                )
            ";
            createCommand.ExecuteNonQuery();
            using (var firstConnection = new SqliteConnection(connectionString))
            {
                firstConnection.Open();

                var updateCommand = firstConnection.CreateCommand();
                updateCommand.CommandText =
                @"
                    INSERT INTO HDD (type,price)
                    VALUES ('500 GB','123.34')
                ";
                updateCommand.ExecuteNonQuery();

                updateCommand.CommandText =
                @"
                    INSERT INTO HDD (type,price)
                    VALUES ('1 TB','200.00')
                ";
                updateCommand.ExecuteNonQuery();
            }

            createCommand.CommandText =
            @"
                CREATE TABLE COLOR (
                    id INTEGER PRIMARY KEY AUTOINCREMENT , type TEXT, price INT
                )
            ";
            createCommand.ExecuteNonQuery();
            using (var firstConnection = new SqliteConnection(connectionString))
            {
                firstConnection.Open();

                var updateCommand = firstConnection.CreateCommand();
                updateCommand.CommandText =
                @"
                    INSERT INTO COLOR (type,price)
                    VALUES ('RED','50')
                ";
                updateCommand.ExecuteNonQuery();

                updateCommand.CommandText =
                @"
                    INSERT INTO COLOR (type,price)
                    VALUES ('Blue','34.56')
                ";
                updateCommand.ExecuteNonQuery();
            }

            createCommand.CommandText =
            @"
                CREATE TABLE ShoppingCart (
                    id INTEGER PRIMARY KEY AUTOINCREMENT , Name TEXT, Ram TEXT, Hdd TEXT, Color TEXT, price INT
                )
            ";
            createCommand.ExecuteNonQuery();

            createCommand.CommandText =
            @"
                CREATE TABLE Laptop (
                    id INTEGER PRIMARY KEY AUTOINCREMENT , Name TEXT, price INT
                )
            ";
            createCommand.ExecuteNonQuery();


            string query = "INSERT INTO Laptop (Name,price) VALUES ('Dell','349.87')";
            createCommand.CommandText = query;

            createCommand.ExecuteNonQuery();

            query = "INSERT INTO Laptop (Name,price) VALUES ('Toshiba','345.67')";
            createCommand.CommandText = query;

            createCommand.ExecuteNonQuery();

            query = "INSERT INTO Laptop (Name,price) VALUES ('HP','456.76')";
            createCommand.CommandText = query;

            createCommand.ExecuteNonQuery();
        }
    }
}
