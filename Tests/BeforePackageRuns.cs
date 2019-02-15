using System;
using System.Data.OleDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BeforePackageRuns
    {
        [TestMethod]
        public void InitPG()
        {
            OleDbConnection conn = Fixtures.GetConnection(DBType.PG);
            conn.Open();

            OleDbCommand command = new OleDbCommand(Constants.CreateTable1PG, conn);
            command.ExecuteNonQuery();

            command = new OleDbCommand(Constants.CreateTableSimplePG, conn);
            command.ExecuteNonQuery();

            command = new OleDbCommand(Constants.CreateTableimagePG, conn);
            command.ExecuteNonQuery();

            command = new OleDbCommand("insert tablesimple (id, firstname) VALUES(1, 'nsb')", conn);
            command.ExecuteNonQuery();

            conn.Close();

            conn = Fixtures.GetConnection(DBType.PG);
            conn.Open();
            command = new OleDbCommand("select * from tablesimple", conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)}");
            }
            conn.Close();
        }
        
        [TestMethod]
        public void InitMSSQL()
        {
            OleDbConnection conn = Fixtures.GetConnection(DBType.MSSQL);
            conn.Open();
            OleDbCommand command = new OleDbCommand(Constants.CreateTable1SQL, conn);
            command.ExecuteNonQuery();

            command = new OleDbCommand(Constants.CreateTableImageSQL, conn);
            command.ExecuteNonQuery();

            command = new OleDbCommand("insert table1 (FirstName,SomeKey) VALUES('nsb', 0x00000000000007D1)", conn);
            command.ExecuteNonQuery();

            command = new OleDbCommand("insert tableimage (FirstName,SomeKey) VALUES('nsb', 0x00000000000007D1)", conn);
            command.ExecuteNonQuery();

            {
                byte[] buffer = new byte[50];
                command = new OleDbCommand("select * from table1", conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)}; somekey len:{reader.GetBytes(2, 0, buffer, 0, 50)};");
                }
            }

            conn.Close();
        }

    }
}
