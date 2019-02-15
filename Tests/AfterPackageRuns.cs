using System;
using System.Data.OleDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AfterPackageRuns
    {
        [TestMethod]
        public void TestMSSQL_CanRead_bytea()
        {
            byte[] buffer = new byte[50];
            OleDbConnection conn = Fixtures.GetConnection(DBType.MSSQL);
            conn.Open();
            OleDbCommand command = new OleDbCommand("select id,firstname,somekey from tableimage", conn);
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
                //Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)}; somekey len:{reader.GetBytes(2,0,buffer,0,50)};");
                Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)};");
            }
            Assert.AreEqual(i, 1, "in tableimage exactly one row expected.");
            conn.Close();
        }

        [TestMethod]
        public void TestPG_CanRead_bytea()
        {
            byte[] buffer = new byte[50];
            OleDbConnection conn = Fixtures.GetConnection(DBType.PG);
            conn.Open();
            OleDbCommand command = new OleDbCommand("select id,firstname,somekey from table1", conn);
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
                //Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)}; somekey len:{reader.GetBytes(2,0,buffer,0,50)};");
                Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)};");
            }
            Assert.AreEqual(i, 1, "in tbale1 exactly one row expected.");
            conn.Close();
        }

        [TestMethod]
        public void TestPGA_bytea_HasValue()
        {
            byte[] buffer = new byte[50];
            OleDbConnection conn = Fixtures.GetConnection(DBType.PG);
            conn.Open();
            OleDbCommand command = new OleDbCommand("select id,firstname,length(somekey) from table1", conn);
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
                int len = int.Parse(reader.GetValue(2).ToString());
                Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)}; length(somekey):{len}");
                Assert.IsTrue(len > 0, "length(somekey) should be bigger then 0");
            }
            Assert.AreEqual(i, 1, "in tbale1 exactly one row expected.");
            conn.Close();
        }

        [TestMethod]
        public void TestPGA_bytea_HasValue_Image()
        {
            byte[] buffer = new byte[50];
            OleDbConnection conn = Fixtures.GetConnection(DBType.PG);
            conn.Open();
            OleDbCommand command = new OleDbCommand("select id,firstname,length(somekey) from tableimage", conn);
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
                int len = int.Parse(reader.GetValue(2).ToString());
                Console.WriteLine($"id:{reader.GetInt32(0)}; firstname:{reader.GetString(1)}; length(somekey):{len}");
                Assert.IsTrue(len > 0, "length(somekey) should be bigger then 0");
            }
            Assert.AreEqual(i, 1, "in tbale1 exactly one row expected.");
            conn.Close();
        }
    }
}
